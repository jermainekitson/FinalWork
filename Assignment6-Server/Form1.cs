using ForFileName;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


namespace Assignment6_Server
{
    public partial class Form1 : Form
    {
        public static int _ticks;
        public static int port = 5000;
        TcpListener listener;
        ClientManager mngr;
        public static List<ClientManager> lstClients = new List<ClientManager>();

        public string HostName { get; set; }
        string generator = "";

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbIPAddress.DataSource = Dns.GetHostEntry(SystemInformation.ComputerName).AddressList
                .Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToList();
            IPHostEntry _host = Dns.GetHostEntry(Dns.GetHostName());
            this.txtHostName.Text = _host.HostName.ToString();
            this.txtPort.Text = port.ToString();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress serverName = (IPAddress)cmbIPAddress.SelectedValue;
                listener = new TcpListener(serverName, port);
                listener.Start();
                timer1.Start();
                //TODO: Come back and create a log for starting the server

                mngr = new ClientManager(listener);
                mngr.NewClientConnected += Mngr_NewClientConnected;
                mngr.ClientDisconnected += Mngr_ClientDisconnected;
                mngr.ReceivedMessage += Mngr_ReceivedMessage;
                mngr.ReceivedFile += Mngr_ReceivedFile;
                mngr.ReceivedCustomFile += Mngr_ReceivedCustomFile;
                mngr.ClientReceiveFile += Mngr_ClientReceiveFile;
                mngr.GetRequestedFile += Mngr_GetRequestedFile;
                mngr.ClientSendMessageWithLoginName += Mngr_ClientSendMessageWithLoginName;
                mngr.GetRequestedImage += Mngr_GetRequestedImage;
                lstMessages.Items.Add(">>>>Server has started");
            }
            catch
            {
                throw;
            }
        }

        private void Mngr_ClientSendMessageWithLoginName(ClientToServer c)
        {
            listBox2.Items.Add(c.clientName);
            listBox1.Items.Add(c.clientName + ": " + c.clientMessage);
        }

        private void Mngr_GetRequestedFile(FileNameCustom fc)
        {
            string docPath = @"C:\Users\Jermaine\source\repos\Ab\Assignment6-Client\bin\Debug\net5.0-windows\" + fc.Filename;
            File.WriteAllBytes(docPath, fc.arr);
            MessageBox.Show("Data has been written");
        }

        private void Mngr_ReceivedCustomFile(FileNameCustom file)
        {
            File.WriteAllBytes(file.Filename, file.arr);
            MessageBox.Show("Data has been written");
        }
        private void Mngr_ClientReceiveFile(string a, List<string> fileH)
        {
            string docPath = @"C:\Users\Jermaine\source\repos\Ab\Assignment6-Client\bin\Debug\net5.0-windows\ClientList.txt";
            File.WriteAllLines(docPath, fileH);
            MessageBox.Show("Client Receive files");
        }
        private void RelayAllMessages(ClientManager sendClient, string message)
        {
            foreach (ClientManager cli in lstClients)
            {
                cli.SendMessage(sendClient.name + ": " + message);
            }
        }
        private void RelayAllFiles(object message)
        {
            foreach (ClientManager client in lstClients)
            {
                client.SendMessage(message);
            }
        }
        private void Mngr_ReceivedMessage(ClientManager client, string message)
        {
            //RelayAllMessages(client, message);
            lstMessages.Items.Add(client.name + ":" + message);
        }

        private void Mngr_ClientDisconnected(ClientManager client)
        {
            //disconnect was called, remove it from the list
            lstClients.Remove(client);
            RelayAllMessages(client, client.name + " has disconnected");
        }

        private void Mngr_NewClientConnected(ClientManager client)
        {
            //Add whatever client connected to our list
            lstClients.Add(client);
            string msg = ">>>>" + client.name + " has connected!";
            //Inform every client in the lsit that a new client connected
            foreach (ClientManager cli in lstClients)
            {
                cli.SendMessage(msg);
            }
            lstMessages.Items.Add(msg);

            //Need to support multiple connection
            mngr = new ClientManager(listener);
            mngr.NewClientConnected += Mngr_NewClientConnected;
            mngr.ClientDisconnected += Mngr_ClientDisconnected;
            mngr.ReceivedCustomFile += Mngr_ReceivedCustomFile;
            mngr.ReceivedMessage += Mngr_ReceivedMessage;
            mngr.ReceivedFile += Mngr_ReceivedFile;
            mngr.ClientReceiveFile += Mngr_ClientReceiveFile;
            mngr.GetRequestedFile += Mngr_GetRequestedFile;
            mngr.GetRequestedImage += Mngr_GetRequestedImage;

            //TODO:Might need to wire up events
        }

        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        private void Mngr_GetRequestedImage(FileNameCustom fc)
        {
            //byteArrayToImage(fc.arr);
            MeetingForm form = new MeetingForm(byteArrayToImage(fc.arr));
            form.ShowDialog();

            throw new NotImplementedException();
        }

        private void Mngr_ReceivedFile(ClientManager client, byte[] message)
        {
            File.WriteAllBytes(client.name, message);
            RelayAllFiles(message);

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            _ticks++;
            lblTime.Text = "Server uptime is " + _ticks + " seconds ";
        }

        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            //if (lowerCase)
            return builder.ToString().ToUpper();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoginusername.Text))
            {
                HostName = txtLoginusername.Text;
                this.Text = "Log in as " + HostName;
            }

            else
                MessageBox.Show("Please log in ");

            txtLoginusername.Text = "";
        }

        private void btnSendHost_Click(object sender, EventArgs e)
        {
            mngr.SendMessage(txtSend.Text, HostName);
            listBox1.Items.Add(HostName + ": " + txtSend.Text);
            txtSend.Text = "";
        }

        private void btnDeleUser_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count != 0)
            {
                while (listBox2.SelectedIndex != -1)
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
            }
        }

        private void btnInvite_Click_1(object sender, EventArgs e)
        {
            string name = "";
            try
            {
                if (listBox2.SelectedItems != null)
                { 
                    name = listBox2.SelectedItem.ToString();
                    Welcome w = new Welcome(name, generator);
                    w.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void btnGenerateCode_Click_1(object sender, EventArgs e)
        {
            generator = RandomString(7);
        }
    }
}
