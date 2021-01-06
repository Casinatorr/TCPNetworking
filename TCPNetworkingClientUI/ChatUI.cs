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
            Connections.SelectedIndexChanged += onConnectionSelectionChange;
            Connections.KeyPress += CancelEdit;
            ProfilePictureBrowse.Click += BrowseForPicture;

            Port.KeyPress += new KeyPressEventHandler(AllowOnlyNums);

            Client.onConnect += onConnect;

            ClientHandle.onReceive += onReceive;
            ClientHandle.onImageReceive += onImageReceive;

            OtherClient.onDisconnect += onClientDisconnect;
            OtherClient.onLogin += onClientLogin;
            Client.onDisconnect += onDisconnect;

            SendButton.Enabled = false;
            UserInput.Enabled = false;

            instance = this;
            LoadSave(lastSave);

            
        }

        private void LoadSave(Save s)
        {
            IP.Text = s.adress;
            Port.Text = s.port;
            Username.Text = s.Username;
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

        private void onConnectionSelectionChange(object sender, EventArgs e)
        {
            ListBox lb = (ListBox) sender;
            if (lb.SelectedItem == null)
                return;
            TestPicture.Image = OtherClient.otherClientsUsername[(string)lb.SelectedItem].profilePicture;
        }

        public void onImageReceive(Image image)
        {
            TestPicture.Image = image;
            TestPicture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void onReceive(string msg)
        {
            Message.Invoke(new Action(() => 
            {
                Messages.Text += $"{msg}" + System.Environment.NewLine;
            }));
        }

        public void onClientLogin(string username)
        {
            Connections.Invoke(new Action(() =>
            {
                Connections.Items.Add(username);
            }));
        }

        public void onDisconnect()
        {
            OtherClient.otherClients.Clear();
            OtherClient.otherClientsUsername.Clear();
            Connections.Invoke(new Action(() =>
            {
                Connections.Items.Clear();
            }));
            Messages.Invoke(new Action(() => 
            {
                Messages.Text = "";
            }));
            ConnectButton.Text = "Connect";

            SendButton.Enabled = false;
            UserInput.Enabled = false;
            ProfilePictureBrowse.Enabled = true;
        }

        public void onClientDisconnect(string username)
        {
            Connections.Invoke(new Action(() =>
            {
                Connections.Items.Remove(username);
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
            if (Connected && !string.IsNullOrWhiteSpace(UserInput.Text))
            {
                ClientSend.SendString(UserInput.Text);
                Messages.Text += $"(You) {UserInput.Text}";
                Messages.Text += System.Environment.NewLine;
            } else
            {
                Messages.Text += $"(You) {UserInput.Text}";
                Messages.Text += System.Environment.NewLine;
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

                SendButton.Enabled = true;
                UserInput.Enabled = true;
                ProfilePictureBrowse.Enabled = false;
                if (!UseProfile.Checked && selectedProfilePicturePath != null)
                    profilePicture = Image.FromFile(@selectedProfilePicturePath);
                else
                    profilePicture = Image.FromFile(@defaultProfilePicturePath);
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
