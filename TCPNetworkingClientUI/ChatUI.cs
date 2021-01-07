using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TCPNetworkingClientUI
{
    public partial class ChatUI:Form
    {
        private static Regex nums = new Regex("^[0-9]+$");
        private bool Connected = false;
        public static string username;
        public static ChatUI instance;

        private static string defaultProfilePicturePath = $"{AppDomain.CurrentDomain.BaseDirectory}AimcrossRed.png";
        public static Image profilePicture = Image.FromFile(@defaultProfilePicturePath);
        private string selectedProfilePicturePath;
        public ChatUI(Save lastSave)
        {
            InitializeComponent();
            PortError.Hide();

            IP.Click += ColorChange;
            Port.Click += ColorChange;
            ConnectButton.Click += Connect;
            SendButton.Click += Send;
            Connections.KeyPress += CancelEdit;
            PrivateSendButton.Click += PrivateChatSend;

            Port.KeyPress += new KeyPressEventHandler(AllowOnlyNums);

            Client.onConnect += onConnect;

            ClientHandle.onReceive += onReceive;

            OtherClient.onDisconnect += onClientDisconnect;
            OtherClient.onLogin += onClientLogin;
            OtherClient.UpdateChat += UpdateChat;
            Client.onDisconnect += onDisconnect;

            Connections.SelectedIndexChanged += onPrivateChatChange;

            UserInput.KeyPress += CheckEnter;
            PrivateUserInput.KeyPress += CheckEnter;

            SendButton.Enabled = false;
            UserInput.Enabled = false;

            instance = this;
            LoadSave(lastSave);

            
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            int code = Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0];
            if (code == 13)
            {
                e.Handled = true;
                TextBox tb = ((TextBox) sender);
                Send(tb.Equals(UserInput));
            }
        }

        private void LoadSave(Save s)
        {
            IP.Text = s.adress;
            Port.Text = s.port;
            Username.Text = s.Username;
        }

        private void PrivateChatSend(object sender, EventArgs e)
        {
            Send(false);
        }

        private void CancelEdit(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BrowseForPicture(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "png files (*.png) | *.png";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedProfilePicturePath = ofd.FileName;
                }
            }
        }

        public Save getSave()
        {
            Save s = new Save();
            s.adress = IP.Text;
            s.port = Port.Text;
            s.Username = Username.Text;
            return s;
        }

        public void onPrivateChatChange(object sender, EventArgs e)
        {

            if (Connections.SelectedItem == null)
                return;
            string chat = OtherClient.otherClientsUsername[(string) Connections.SelectedItem].chat;
            PrivateChat.Text = chat;
        }

        private void UpdateChat()
        {
            instance.Invoke(new Action(() =>
            {
                instance.onPrivateChatChange(null, null);
            }));
        }

        public void onReceive(int id, string msg)
        {
            string name = OtherClient.otherClients[id].username;
            msg = $"{name}: {msg}";
            WriteMessage(msg);
        }

        public void onClientLogin(string username, bool newLogin)
        {
            if (newLogin)
                WriteMessage($"{username} logged in!");
            if(username != Username.Text)
                Connections.Invoke(new Action(() =>
                {
                    Connections.Items.Add(username);
                }));
        }

        public void onDisconnect()
        {
            OtherClient.otherClients.Clear();
            OtherClient.otherClientsUsername.Clear();
            instance.Invoke(new Action(() => instance.ReEnable()));
        }

        private void WriteMessage(string msg)
        {
            Messages.Invoke(new Action(() =>
            {
                Messages.AppendText(msg + System.Environment.NewLine);                
            }));
        }

        private void ReEnable()
        {
            Connections.Items.Clear();
            Messages.Text = "";
            ConnectButton.Text = "Connect";
            SendButton.Enabled = false;
            UserInput.Enabled = false;
            Port.Enabled = true;
            IP.Enabled = true;
            Username.Enabled = true;
        }

        private void Disable()
        {
            SendButton.Enabled = true;
            UserInput.Enabled = true;
            Port.Enabled = false;
            IP.Enabled = false;
            Username.Enabled = false;
        }

        public void onClientDisconnect(string username)
        {
            Connections.Invoke(new Action(() =>
            {
                Connections.Items.Remove(username);
                WriteMessage($"{username} disconnected!");
            }));
        }

        private void AllowOnlyNums(object sender, KeyPressEventArgs e)
        {
            char[] c = { e.KeyChar };
            if (Encoding.ASCII.GetBytes(c)[0] == 8)
                return;
            if (!nums.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
            if (Port.TextLength + 1 > 5)
                e.Handled = true;
        }

        private void Send(object sender, EventArgs e)
        {
            //Its kinda weird
            Send(true);
        }

        private void Send(bool chat)
        {
            if (string.IsNullOrWhiteSpace(UserInput.Text) && chat)
                return;
            if (string.IsNullOrWhiteSpace(PrivateUserInput.Text) && !chat)
                return;
            if (Connected)
            {
                if (chat)
                {
                    ClientSend.SendMessage(UserInput.Text);
                    WriteMessage($"(You) {UserInput.Text}");
                    UserInput.Text = "";
                } else
                {
                    if (Connections.SelectedItem == null)
                        return;
                    OtherClient current = OtherClient.otherClientsUsername[(string) Connections.SelectedItem];
                    string msg = PrivateUserInput.Text + System.Environment.NewLine;
                    ClientSend.SendPrivateMessage(current.id, msg);
                    current.AppendToChat("(You) " + msg);
                    PrivateUserInput.Text = "";
                }
            }
        }

        private void Connect(object sender, EventArgs e)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(IP.Text))
            {
                IP.BackColor = Color.FromArgb(255, 100, 100);
                valid = false;
            }
            if (string.IsNullOrEmpty(Port.Text))
            {
                Port.BackColor = Color.FromArgb(255, 100, 100);
                valid = false;
            }
            if (Port.Text != "")
            {
                if (Int32.Parse(Port.Text) > 65535)
                {
                    PortError.Show();
                    Port.BackColor = Color.FromArgb(255, 100, 100);
                    valid = false;
                }
            }
            Console.WriteLine(valid);
            if (!valid) return;


            if (!Connected)
            {
                UseWaitCursor = true;
                username = Username.Text;
                Client.instance.ip = IP.Text;
                Client.instance.port = Int32.Parse(Port.Text);
                Client.instance.tcp.Connect();

                Disable();
                ConnectButton.Text = "Disconnect";
            } else
            {
                Client.instance.Disconnect();
                Connected = false;
                ConnectButton.Text = "Connect";
            }
        }

        private void onConnect(bool success)
        {
            UseWaitCursor = false;
            Connected = success;
        }


        private void ColorChange(object sender, EventArgs args)
        {
            ((TextBox) sender).BackColor = Color.White;
            PortError.Hide();
        }
    }
}
