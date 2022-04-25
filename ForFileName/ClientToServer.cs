using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForFileName
{[Serializable]
    public class ClientToServer
    {
        public string clientName { get; set; }
        public string clientMessage { get; set; }
        public ClientToServer(string a, string b)
        {
            clientName = a;
            clientMessage = b;
        }
    }
}
