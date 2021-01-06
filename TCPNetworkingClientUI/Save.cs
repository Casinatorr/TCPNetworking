using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TCPNetworkingClientUI
{
    [Serializable]
    public class Save : ISerializable
    {
        public string adress = "";
        public string port = "";
        public string Username = "";

        public Save()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Adress", adress);
            info.AddValue("Port", port);
            info.AddValue("Username", Username);
        }

        public Save(SerializationInfo info, StreamingContext context)
        {
            adress = info.GetString("Adress");
            port = info.GetString("Port");
            Username = info.GetString("Username");
        }
    }
}
