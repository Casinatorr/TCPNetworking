using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TCPNetworkingClientUI
{
    class OtherClient
    {
        public static Dictionary<int, OtherClient> otherClients = new Dictionary<int, OtherClient>();
        public static Action<string> onDisconnect;
        public static Action<int, bool> onLogin;
        public static Action UpdateChat;

        public string chat = "";
        public string username;
        public int id;

        public OtherClient(string username, int id, bool newLogin)
        {
            this.id = id;
            this.username = username;
            otherClients.Add(id, this);
            onLogin(id, newLogin);
        }
        public static void init(string username, int id, bool newLogin)
        {
            if (otherClients.ContainsKey(id))
                return;
            OtherClient c = new OtherClient(username, id, newLogin);
        }

        public void Disconnect()
        {
            otherClients.Remove(id);
            onDisconnect(username);
        }

        public void AppendToChat(string msg)
        {
            chat += msg;
            UpdateChat();
        }

        public static OtherClient byUsername(string username)
        {
            foreach(KeyValuePair<int, OtherClient> kv in otherClients)
            {
                if (kv.Value.username == username)
                    return kv.Value;
            }
            return null;
        }

    }
}
