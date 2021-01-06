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
        public ChatUI()
        {
            InitializeComponent();
            PortError.Hide();

            IP.Click += ColorChange;
            Port.Click += ColorChange;
            ConnectButton.Click += Connect;
            SendButton.Click += Send;

            Port.KeyPress += new KeyPressEventHandler(AllowOnlyNums);


            Client.onConnect += onConnect;

            ClientHandle.onReceive += onReceive;
        }


        private void onReceive(string msg)
        {
            Message.Invoke(new Action(() => 
            {
                Message.Text = msg;
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
            if (Connected)
                ClientSend.SendString("If this works imma be real happy");
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

            UseWaitCursor = true;
            username = Username.Text;
            Client.instance.tcp.Connect();
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
