using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO;
using ForFileName;
using Assignment6_Server;
using System.Net;
using SharpHook;
using SharpHook.Reactive;
using System.Drawing.Imaging;
using System.Threading;
using System.Net.Sockets;

namespace Assignment6_Client
{
    public partial class Form1 : Form
    {
        Socket hostSocket;
        ClientCommunication serv;
        ConcurrentQueue<string> msgQ = new ConcurrentQueue<string>();
        public static int port = 5000;
        string LoggedInUsr = "";
        BackgroundWorker bgw = new BackgroundWorker();
        Bitmap screenshot;
        Graphics screenGraph;
        double xRatio;
        double yRatio;
        int winWidth;
        int winHeight;
        Socket sendsocket;

        private void DisplayMessages()
        {
            while (msgQ.Count > 0)
            {
                string tmp;
                msgQ.TryDequeue(out tmp);
                lstMessages.Items.Add(tmp);
                // lstMessages.DisplayMember = "";
            }
        }
        public Form1()
        {
            InitializeComponent();
            
            IPHostEntry _host = Dns.GetHostEntry(Dns.GetHostName());
            this.txtHostName.Text = _host.HostName.ToString();
            this.txtPort.Text = port.ToString();
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerAsync();
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;

           sendsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Get reference to the first screen on the pc
            Screen s1 = Screen.AllScreens[1];
            winWidth = s1.Bounds.Width;
            winHeight = s1.Bounds.Height;
            while (true)
            {
                try
                {
                    Rectangle bounds = s1.Bounds;
                    screenshot = new Bitmap(bounds.Width, bounds.Height);
                    screenGraph = Graphics.FromImage(screenshot);
                    screenGraph.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    pictureBox1.Image = screenshot;

                    Bitmap bmp = new Bitmap(screenshot.Clone() as Bitmap);
                    bmp.Save("myScreen.jpg", ImageFormat.Jpeg);
                    bmp.Dispose();
                    //screenshot.Save("myScreen.jpg", ImageFormat.Jpeg);
                    System.Threading.Thread.Sleep(100);
                    //Clean up anything that is no longer referenced
                    GC.Collect();
                }
                catch
                {

                }
            }
        }
       
        private void btnConnect_Click(object sender, EventArgs e)
        {
            serv = new ClientCommunication(cmbIPAddress.Text);
            
            serv.ReceivedMessage += Serv_ReceivedMessage;
            serv.Connected += Serv_Connected;
            serv.ConnectionFailed += Serv_ConnectionFailed;
            serv.ReceivedFile += Serv_ReceivedFile;
            serv.ReceivedFileWithFileName += Serv_ReceivedFileWithFileName;
            serv.ReceivedMessageFromServerHost += Serv_ReceivedMessageFromServerHost;

        }
        private void Serv_ReceivedMessageFromServerHost(ClientToServer f)
        {
            lstRead.Items.Add(f.clientName +": "+ f.clientMessage);
        }

        private void Serv_ReceivedFileWithFileName(FileNameCustom file)
        {
            string path = Environment.CurrentDirectory + "/Files/" + file.Filename;
            file.SetPath(path);
            File.WriteAllBytes(path, file.arr);
        }

        private void Serv_ReceivedFile(object message)
        {
            File.WriteAllBytes("clientFile.txt", (byte[])message);
        }

        private void Serv_ConnectionFailed(string servername, int port)
        {
            //throw new NotImplementedException();
            msgQ.Enqueue("Connection Failed: " + servername + ", " + port);
            this.BeginInvoke(new MethodInvoker(DisplayMessages));
        }

        private void Serv_Connected(string servername, int port)
        {
            string incomingConnectionMessage = ">>>>" + servername + "@" + port + " connected";
            msgQ.Enqueue(incomingConnectionMessage);
        }

        private void Serv_ReceivedMessage(string message)
        {
            //throw new NotImplementedException();
            //DisplayMessages();
            msgQ.Enqueue(message);
            this.BeginInvoke(new MethodInvoker(DisplayMessages));
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            serv.SendMessage(txtMessage.Text);
            txtMessage.Text = "";
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            byte[] fileContents;
            OpenFileDialog diag = new OpenFileDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                fileContents = File.ReadAllBytes(diag.FileName);
                FileNameCustom file = new FileNameCustom(diag.FileName.Split('\\').LastOrDefault(), fileContents);
                serv.SendMessage(file);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoginusername.Text))
                serv.SendMessage(txtLoginusername.Text);
            else
                MessageBox.Show("Please log in ");

            LoggedInUsr = txtLoginusername.Text;
            this.Text = "Logged in as " + LoggedInUsr;

            txtLoginusername.Text = "";

        }
        private void btnPublicChat_Click(object sender, EventArgs e)
        {
            serv.ClientSendMessageToServer(LoggedInUsr, txtPrivateMessage.Text);
            txtPrivateMessage.Text = "";
        }
        private Bitmap GetScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            return bitmap;
        }
       
        private void trreadimage()
        {
            int dataSize;
            string imageName = "Image-" + System.DateTime.Now.Ticks + ".JPG";
            try
            {

                dataSize = 0;
                byte[] b = new byte[1024 * 10000];  //Picture of great
                dataSize = hostSocket.Receive(b);
                if (dataSize > 0)
                {
                    MemoryStream ms = new MemoryStream(b);
                    Image img = Image.FromStream(ms);
                    img.Save(imageName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    pictureBox1.Image = img;
                    ms.Close();
                }

            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message);
                //thread.Abort();
            }
            System.Threading.Thread.Sleep(1500);
            trreadimage();
        }
        private void connectSocket()
        {
            Socket receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint hostIpEndPoint = new IPEndPoint(IPAddress.Parse(cmbIPAddress.Text), 10001);
            //Connection node
            receiveSocket.Bind(hostIpEndPoint);
            receiveSocket.Listen(10);
            MessageBox.Show("start");
            hostSocket = receiveSocket.Accept();
            Thread thread = new Thread(new ThreadStart(trreadimage));

            thread.IsBackground = true;
            thread.Start();
        }
        private byte[] threadimage()
        {
            byte[] b = new byte[] { };
            try
            {
                MemoryStream ms = new MemoryStream();
                GetScreen().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);   //Here I use the BMP format
                b = ms.ToArray();
                sendsocket.Send(b);
                ms.Close();
            }
            catch
            {

            }
            Thread.Sleep(1000);
            threadimage();
            return b;
        }

        private void btnShareScreen_Click(object sender, EventArgs e)
        {
            serv.SendMessage(txtLoginusername.Text, threadimage());
        }

    }
}
