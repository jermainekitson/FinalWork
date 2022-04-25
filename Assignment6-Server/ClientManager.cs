using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;
using ForFileName;

namespace Assignment6_Server
{
    public class ClientManager
    {
        public string name = "";
        //Keep a string around for the latest message
        string latest = "";
        public string filename { get; set; }
        public byte[] arrName { get; set; }
        FileNameCustom file;
        ClientToServer f;
        string result = "";
        public static TcpListener listener;
        public static int clientCounter = 0;

        private BackgroundWorker bgw = new BackgroundWorker();
        private Socket connection;
        private NetworkStream socketStream;
        private BinaryReader reader;
        private BinaryWriter writer;

        public event NewClientConnectedEventHandler NewClientConnected;
        public delegate void NewClientConnectedEventHandler(ClientManager client);

        public event ReceivedMessageEventHandler ReceivedMessage;
        public delegate void ReceivedMessageEventHandler(ClientManager client, string message);

        public event ReceivedFileEventHandler ReceivedFile;
        public delegate void ReceivedFileEventHandler(ClientManager client, byte[] message);

        public event ReceivedCustomFileEventHandler ReceivedCustomFile;
        public delegate void ReceivedCustomFileEventHandler(FileNameCustom file);

        public event ClientDisconnectedEventHandler ClientDisconnected;
        public delegate void ClientDisconnectedEventHandler(ClientManager client);

        public event ClientSendMessageWithLoginNameEventHandler ClientSendMessageWithLoginName;
        public delegate void ClientSendMessageWithLoginNameEventHandler(ClientToServer c);

        public event ClientReceiveFileEventHandler ClientReceiveFile;
        public delegate void ClientReceiveFileEventHandler(string a, List<string> f);

        public event GetRequestedFileEventHandler GetRequestedFile;
        public delegate void GetRequestedFileEventHandler(FileNameCustom fc);

        public event GetRequestedImageEventHandler GetRequestedImage;
        public delegate void GetRequestedImageEventHandler(FileNameCustom fc);



        public ClientManager(TcpListener listener)
        {
            ClientManager.listener = listener;
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += Bgw_DoWork;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.RunWorkerAsync();
        }

        public void SendMessage(object message)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writer.BaseStream, message);
            }
            catch
            {
                throw;
            }
        }
        public void SendMessage(string clientname, string msg)
        {
            ClientToServer fc = new ClientToServer(msg, clientname);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writer.BaseStream, fc);
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string rec = "";
            string contain = "!get";
            string[] exc = new[] { ".json", ".dll", ".pdb", ".exe" };
            List<string> files = Directory.GetFiles(Environment.CurrentDirectory).Where(x => !exc.Any(a => x.EndsWith(a, StringComparison.OrdinalIgnoreCase))).ToList();
            List<string> f = new List<string>();
            //loop through every file in the file storage directory
            foreach (string file1 in files)
            {
                rec = file1.Split('\\').LastOrDefault();
                f.Add(rec);
            }

            try
            {
                //CLient connected
                if (e.ProgressPercentage == 0)
                {
                    NewClientConnected(this);
                }
                //String message
                else if (e.ProgressPercentage == 1)
                {
                    ReceivedMessage(this, (string)e.UserState);
                    //if the message is !list
                    if (latest == "!list")
                    {
                        ClientReceiveFile(rec, f);
                    }
                    else if (latest.Contains(contain))
                    {
                        string sub = latest.Split("").LastOrDefault();
                        sub = sub.Remove(0, 5);
                        string ans = f.Where(x => x.Contains(sub)).FirstOrDefault();
                        file.Filename = ans;
                        file.arr = Encoding.ASCII.GetBytes(ans);
                        GetRequestedFile(file);
                    }
                }

                else if (e.ProgressPercentage == 2)
                {
                    ReceivedFile(this, (byte[])e.UserState);
                }
                else if (e.ProgressPercentage == 3)
                {
                    ReceivedCustomFile((FileNameCustom)e.UserState);
                    GetRequestedImage((FileNameCustom)e.UserState);
                }
                else if (e.ProgressPercentage == 4)
                {
                    ClientSendMessageWithLoginName((ClientToServer)e.UserState);
                }
            }
            catch
            {
                throw;
            }
        }
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //THis will wait for a enw connection
                connection = listener.AcceptSocket();
                clientCounter++;
                //Give them a name with thier index
                this.name = "Client" + clientCounter;

                //Use the BGW to report progress (usually percent progress) is going to indicate the type of event 
                //0 - new client connected
                bgw.ReportProgress(0);

                //Set up our network connection
                socketStream = new NetworkStream(connection);
                reader = new BinaryReader(socketStream);
                writer = new BinaryWriter(socketStream);
                file = new FileNameCustom(filename, arrName);

                //When connection cease this will become true
                bool done = false;
                while (!done)
                {
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        object o = (object)formatter.Deserialize(reader.BaseStream);


                        //Here we check for the type of object
                        if (o is string)
                        {
                            latest = (string)o;
                            bgw.ReportProgress(1, latest);
                        }

                        if (o is FileNameCustom)
                        {
                            file = (FileNameCustom)o;
                            bgw.ReportProgress(3, file);
                        }
                        if (o is byte[])
                        {
                            //identifer 2 == byte[]
                            bgw.ReportProgress(2, o);
                        }
                        if (o is ClientToServer)
                        {
                            f = (ClientToServer)o;
                            bgw.ReportProgress(4, f);
                        }
                    }
                    catch
                    {
                        done = true;
                        throw;
                    }
                }
            }
            catch
            {
                //Client is no longer connected, fire event
                ClientDisconnected(this);
            }
        }
    }
}
