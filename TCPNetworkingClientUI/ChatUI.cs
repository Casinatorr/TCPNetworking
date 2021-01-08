using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using TCPNetworkingClientUI.Audio;
using NAudio.Wave;
using System.IO;
using System.Threading;

namespace TCPNetworkingClientUI
{
    public partial class ChatUI:Form
    {
        private static Regex nums = new Regex("^[0-9]+$");
        private bool Connected = false;
        public static string username;
        public static ChatUI instance;
        public byte[] lastAudio;

        public Recorder recorder;
        private bool isRecording = false;
        private Audio.Encoder encoder;

        private Packet currentAudio;

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
            encoder = new Audio.Encoder();
            recorder = new Recorder();
            RecordingButton.Click += Record;
            PlayAudio.Click += HandleSound;

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
            RecordingButton.Enabled = false;
            PlayAudio.Enabled = false;

            instance = this;
            LoadSave(lastSave);

            
        }

        //Testing
        public void Record(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                recorder.StartRecording();
                isRecording = true;
                RecordingButton.Text = "Stop";
            } else
            {
                RecordingButton.Enabled = false;
                isRecording = false;
                Packet p = recorder.StopRecording();
                currentAudio = p;
            }
        }

        public void SetAudioMessage(string msg)
        {
            LastAudioMessage.Text = msg;
            PlayAudio.Enabled = true;
        }

        public void HandleSound(object sender, EventArgs e)
        {
            if (lastAudio == null)
                return;
            byte[] data = lastAudio;
            data = encoder.Decode(data, 0, data.Length);
            IWaveProvider provider = new RawSourceWaveStream(
                         new MemoryStream(data), new WaveFormat());

            WaveOut wo = new WaveOut();
            wo.Init(provider);
            wo.Play();
        }

        //calling textboxes trigger something by pressing Enter
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

        //enters saved values into fields
        private void LoadSave(Save s)
        {
            IP.Text = s.adress;
            Port.Text = s.port;
            Username.Text = s.Username;
        }

        //sends private chat message
        private void PrivateChatSend(object sender, EventArgs e)
        {
            Send(false);
        }

        //completely cancel interaction with listboxes/textboxes
        private void CancelEdit(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //returns current saveable values
        public Save getSave()
        {
            Save s = new Save();
            s.adress = IP.Text;
            s.port = Port.Text;
            s.Username = Username.Text;
            return s;
        }

        //gets called when user changes private chat
        public void onPrivateChatChange(object sender, EventArgs e)
        {

            if (Connections.SelectedItem == null)
                return;
            string chat = OtherClient.byUsername((string)Connections.SelectedItem).chat;
            PrivateChat.Text = chat;
        }

        //Updates the currently open private chat
        private void UpdateChat()
        {
            instance.Invoke(new Action(() =>
            {
                instance.onPrivateChatChange(null, null);
            }));
        }

        //gets called on receive
        public void onReceive(int id, string msg)
        {
            string name = OtherClient.otherClients[id].username;
            msg = $"{name}: {msg}";
            WriteMessage(msg);
        }

        //gets called by ServerHandle when a login packet arrives, newLogin is for identification purposes
        public void onClientLogin(int id, bool newLogin)
        {
            if (newLogin)
                WriteMessage($"{OtherClient.otherClients[id].username} logged in!");
            if(id != Client.instance.myid)
                Connections.Invoke(new Action(() =>
                {
                    Connections.Items.Add(OtherClient.otherClients[id].username);
                }));
        }

        //gets called when the client disconnects
        public void onDisconnect()
        {
            OtherClient.otherClients.Clear();
            instance.Invoke(new Action(() => instance.ReEnable()));
        }

        //invokes a call that changes the public chat box
        private void WriteMessage(string msg)
        {
            Messages.Invoke(new Action(() =>
            {
                Messages.AppendText(msg + System.Environment.NewLine);                
            }));
        }

        //enables buttons and textboxes
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
            PrivateSendButton.Enabled = false;
            PrivateUserInput.Enabled = false;
            PlayAudio.Enabled = false;
            RecordingButton.Enabled = false;
        }

        //disables buttons and textboxes
        private void Disable()
        {
            SendButton.Enabled = true;
            UserInput.Enabled = true;
            Port.Enabled = false;
            IP.Enabled = false;
            Username.Enabled = false;
            PrivateUserInput.Enabled = true;
            PrivateSendButton.Enabled = true;
            RecordingButton.Enabled = true;
        }

        //gets called when an OtherClients disconnect method gets called
        public void onClientDisconnect(string username)
        {
            Connections.Invoke(new Action(() =>
            {
                Connections.Items.Remove(username);
                WriteMessage($"{username} disconnected!");
            }));
        }

        //allows only numbers in called textboxes
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

        //gets called by send button, calls the other send function
        private void Send(object sender, EventArgs e)
        {
            //Its kinda weird
            Send(true);
        }

        //Send public and private messages, boolean tells which type of message
        private void Send(bool chat)
        {
            if (Connected)
            {
                RecordingButton.Enabled = true;
                RecordingButton.Text = "Record";
                if (currentAudio != null)
                {
                    ClientSend.SendAudioMessage(UserInput.Text, currentAudio.ReadBytes(currentAudio.Length()));
                    currentAudio = null;
                    UserInput.Text = "";
                }
                if (string.IsNullOrWhiteSpace(UserInput.Text) && chat)
                    return;
                if (string.IsNullOrWhiteSpace(PrivateUserInput.Text) && !chat)
                    return;
                if (chat)
                {
                    ClientSend.SendMessage(UserInput.Text);
                    WriteMessage($"(You) {UserInput.Text}");
                    UserInput.Text = "";
                } else
                {
                    if (Connections.SelectedItem == null)
                        return;
                    OtherClient current = OtherClient.byUsername((string)Connections.SelectedItem);
                    string msg = PrivateUserInput.Text + System.Environment.NewLine;
                    ClientSend.SendPrivateMessage(current.id, msg);
                    current.AppendToChat("(You) " + msg);
                    PrivateUserInput.Text = "";
                }
            }
        }

        //Connecting
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

        //connect callback from client class
        private void onConnect(bool success)
        {
            UseWaitCursor = false;
            Connected = success;
        }

        //calling textboxes return to default color on click
        private void ColorChange(object sender, EventArgs args)
        {
            ((TextBox) sender).BackColor = Color.White;
            PortError.Hide();
        }
    }
}
