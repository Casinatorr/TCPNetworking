
namespace TCPNetworkingClientUI
{
    partial class ChatUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.PortError = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.Label();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.Messages = new System.Windows.Forms.TextBox();
            this.Connections = new System.Windows.Forms.ListBox();
            this.PrivateChat = new System.Windows.Forms.TextBox();
            this.PrivateUserInput = new System.Windows.Forms.TextBox();
            this.PrivateSendButton = new System.Windows.Forms.Button();
            this.RecordingButton = new System.Windows.Forms.Button();
            this.PlayAudio = new System.Windows.Forms.Button();
            this.LastAudioMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(121, 11);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(100, 35);
            this.IP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(121, 52);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(100, 35);
            this.Port.TabIndex = 4;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(109, 134);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(126, 38);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            // 
            // PortError
            // 
            this.PortError.AutoSize = true;
            this.PortError.Location = new System.Drawing.Point(227, 55);
            this.PortError.Name = "PortError";
            this.PortError.Size = new System.Drawing.Size(188, 30);
            this.PortError.TabIndex = 6;
            this.PortError.Text = "Max. port is 65.535";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(713, 406);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(97, 41);
            this.SendButton.TabIndex = 7;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(121, 93);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(100, 35);
            this.Username.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Username:";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(43, 323);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 30);
            this.Message.TabIndex = 10;
            // 
            // UserInput
            // 
            this.UserInput.Location = new System.Drawing.Point(447, 408);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(260, 35);
            this.UserInput.TabIndex = 12;
            // 
            // Messages
            // 
            this.Messages.AcceptsReturn = true;
            this.Messages.Location = new System.Drawing.Point(447, 14);
            this.Messages.Multiline = true;
            this.Messages.Name = "Messages";
            this.Messages.ReadOnly = true;
            this.Messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Messages.Size = new System.Drawing.Size(337, 350);
            this.Messages.TabIndex = 13;
            // 
            // Connections
            // 
            this.Connections.FormattingEnabled = true;
            this.Connections.ItemHeight = 30;
            this.Connections.Location = new System.Drawing.Point(295, 105);
            this.Connections.Name = "Connections";
            this.Connections.Size = new System.Drawing.Size(120, 364);
            this.Connections.TabIndex = 16;
            // 
            // PrivateChat
            // 
            this.PrivateChat.Location = new System.Drawing.Point(5, 178);
            this.PrivateChat.Multiline = true;
            this.PrivateChat.Name = "PrivateChat";
            this.PrivateChat.ReadOnly = true;
            this.PrivateChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrivateChat.Size = new System.Drawing.Size(277, 291);
            this.PrivateChat.TabIndex = 17;
            // 
            // PrivateUserInput
            // 
            this.PrivateUserInput.Location = new System.Drawing.Point(5, 477);
            this.PrivateUserInput.Name = "PrivateUserInput";
            this.PrivateUserInput.Size = new System.Drawing.Size(277, 35);
            this.PrivateUserInput.TabIndex = 18;
            // 
            // PrivateSendButton
            // 
            this.PrivateSendButton.Location = new System.Drawing.Point(295, 475);
            this.PrivateSendButton.Name = "PrivateSendButton";
            this.PrivateSendButton.Size = new System.Drawing.Size(97, 41);
            this.PrivateSendButton.TabIndex = 19;
            this.PrivateSendButton.Text = "Send";
            this.PrivateSendButton.UseVisualStyleBackColor = true;
            // 
            // RecordingButton
            // 
            this.RecordingButton.Location = new System.Drawing.Point(816, 408);
            this.RecordingButton.Name = "RecordingButton";
            this.RecordingButton.Size = new System.Drawing.Size(103, 37);
            this.RecordingButton.TabIndex = 21;
            this.RecordingButton.Text = "Record";
            this.RecordingButton.UseVisualStyleBackColor = true;
            // 
            // PlayAudio
            // 
            this.PlayAudio.Location = new System.Drawing.Point(713, 465);
            this.PlayAudio.Name = "PlayAudio";
            this.PlayAudio.Size = new System.Drawing.Size(90, 36);
            this.PlayAudio.TabIndex = 23;
            this.PlayAudio.Text = "Play";
            this.PlayAudio.UseVisualStyleBackColor = true;
            // 
            // LastAudioMessage
            // 
            this.LastAudioMessage.Location = new System.Drawing.Point(447, 466);
            this.LastAudioMessage.Name = "LastAudioMessage";
            this.LastAudioMessage.ReadOnly = true;
            this.LastAudioMessage.Size = new System.Drawing.Size(260, 35);
            this.LastAudioMessage.TabIndex = 24;
            // 
            // ChatUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 524);
            this.Controls.Add(this.LastAudioMessage);
            this.Controls.Add(this.PlayAudio);
            this.Controls.Add(this.RecordingButton);
            this.Controls.Add(this.PrivateSendButton);
            this.Controls.Add(this.PrivateUserInput);
            this.Controls.Add(this.PrivateChat);
            this.Controls.Add(this.Connections);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.PortError);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ChatUI";
            this.Text = "ChatUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label PortError;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.TextBox UserInput;
        private System.Windows.Forms.TextBox Messages;
        private System.Windows.Forms.ListBox Connections;
        private System.Windows.Forms.TextBox PrivateChat;
        private System.Windows.Forms.TextBox PrivateUserInput;
        private System.Windows.Forms.Button PrivateSendButton;
        private System.Windows.Forms.Button RecordingButton;
        private System.Windows.Forms.Button PlayAudio;
        private System.Windows.Forms.TextBox LastAudioMessage;
    }
}