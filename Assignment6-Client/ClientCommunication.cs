using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.IO;
//I don't like this cause now we are bound to windows forms
using System.Windows.Forms;
using ForFileName;
using Assignment6_Server;

namespace Assignment6_Client
{
    public class ClientCommunication
    {
        public string clientName = SystemInformation.ComputerName;
        public string servername;
        public int port = 5000;
        private TcpClient client;
        private NetworkStream nStream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private BackgroundWorker bgw = new BackgroundWorker();
        ClientToServer c;

        public event ConnectedEventHandler Connected;
        public delegate void ConnectedEventHandler(string servername, int port);

        public event ConnectionFailedEventHandler ConnectionFailed;
        public delegate void ConnectionFailedEventHandler(string servername, int port);

        public event ReceivedMessageEventHandler ReceivedMessage;
        public delegate void ReceivedMessageEventHandler(string message);

        public event ReceivedFileEventHandler ReceivedFile;
        public delegate void ReceivedFileEventHandler(object message);
        public event ReceivedFileWithFileNameEventHandler ReceivedFileWithFileName;
        public delegate void ReceivedFileWithFileNameEventHandler(FileNameCustom file);
        public event ReceivedMessageFromServerHostEventHandler ReceivedMessageFromServerHost;
        public delegate void ReceivedMessageFromServerHostEventHandler(ClientToServer f);

        public ClientCommunication(string servername)
        {
            this.servername = servername;
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;

            bgw.DoWork += Bgw_DoWork;
            bgw.ProgressChanged += Bgw_ProgressChanged;

            bgw.RunWorkerAsync();
        }
        public void SendMessage(string msg)
        {
           
           IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writer.BaseStream, msg);
        }
        public void SendMessage(string msg, byte[] a)
        {
            FileNameCustom fc = new FileNameCustom(msg, a);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writer.BaseStream, fc);
        }
        public void ClientSendMessageToServer(string msg, string clientname)
        {
            ClientToServer fc = new ClientToServer(msg, clientname);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writer.BaseStream, fc);
        }
        public void SendMessage(object msg)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writer.BaseStream, msg);
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                //CLient connected
                if (e.ProgressPercentage == 0)
                {
                    ReceivedMessageFromServerHost((ClientToServer)e.UserState);
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
                client = new TcpClient();
                client.Connect(this.servername, this.port);
                nStream = client.GetStream();
                reader = new BinaryReader(nStream);
                writer = new BinaryWriter(nStream);

                Connected(this.servername, this.port);
                try
                {
                    while (true)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        
                        object o = (object)formatter.Deserialize(nStream);
                        if(o is string)
                        {
                            ReceivedMessage((string)o);
                        }
                        else if(o is byte[])
                        {
                            ReceivedFile(o);
                        }
                        else if (o is FileNameCustom)
                        {
                            ReceivedFileWithFileName((FileNameCustom)o);
                        }
                        else if (o is ClientToServer)
                        {
                            ReceivedMessageFromServerHost((ClientToServer)o);
                        }
                        //TODO: Receive a byte[] for a file
                    }
                } catch
                {
                    throw;
                }
            } catch
            {
                ConnectionFailed(this.servername, this.port);
            }
        }
    }
}
