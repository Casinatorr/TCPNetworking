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
        public static Dictionary<string, OtherClient> otherClientsUsername = new Dictionary<string, OtherClient>();
        public static Action<string> onDisconnect;
        public static Action<string, bool> onLogin;
        public static Action UpdateChat;

        public string chat = "";
        public string username;
        public int id;
        public Image profilePicture;

        public OtherClient(string username, int id, bool newLogin)
        {
            this.id = id;
            this.username = username;
            otherClients.Add(id, this);
            otherClientsUsername.Add(username, this);
            onLogin(username, newLogin);
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
            otherClientsUsername.Remove(username);
            onDisconnect(username);
        }

        public void AppendToChat(string msg)
        {
            chat += msg;
            UpdateChat();
        }
    }
}
