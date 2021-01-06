
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
            this.TestPicture = new System.Windows.Forms.PictureBox();
            this.Connections = new System.Windows.Forms.ListBox();
            this.ProfilePictureBrowse = new System.Windows.Forms.Button();
            this.UseProfile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TestPicture)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(56, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(121, 63);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(100, 35);
            this.Port.TabIndex = 4;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(107, 145);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(126, 38);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            // 
            // PortError
            // 
            this.PortError.AutoSize = true;
            this.PortError.Location = new System.Drawing.Point(227, 66);
            this.PortError.Name = "PortError";
            this.PortError.Size = new System.Drawing.Size(188, 30);
            this.PortError.TabIndex = 6;
            this.PortError.Text = "Max. port is 65.535";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(713, 394);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(105, 64);
            this.SendButton.TabIndex = 7;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(121, 104);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(100, 35);
            this.Username.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 107);
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
            // TestPicture
            // 
            this.TestPicture.Location = new System.Drawing.Point(80, 248);
            this.TestPicture.Name = "TestPicture";
            this.TestPicture.Size = new System.Drawing.Size(168, 166);
            this.TestPicture.TabIndex = 14;
            this.TestPicture.TabStop = false;
            // 
            // Connections
            // 
            this.Connections.FormattingEnabled = true;
            this.Connections.ItemHeight = 30;
            this.Connections.Location = new System.Drawing.Point(295, 248);
            this.Connections.Name = "Connections";
            this.Connections.Size = new System.Drawing.Size(120, 154);
            this.Connections.TabIndex = 16;
            // 
            // ProfilePictureBrowse
            // 
            this.ProfilePictureBrowse.Location = new System.Drawing.Point(109, 420);
            this.ProfilePictureBrowse.Name = "ProfilePictureBrowse";
            this.ProfilePictureBrowse.Size = new System.Drawing.Size(112, 43);
            this.ProfilePictureBrowse.TabIndex = 17;
            this.ProfilePictureBrowse.Text = "Browse";
            this.ProfilePictureBrowse.UseVisualStyleBackColor = true;
            // 
            // UseProfile
            // 
            this.UseProfile.AutoSize = true;
            this.UseProfile.Checked = true;
            this.UseProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseProfile.Location = new System.Drawing.Point(109, 469);
            this.UseProfile.Name = "UseProfile";
            this.UseProfile.Size = new System.Drawing.Size(100, 34);
            this.UseProfile.TabIndex = 18;
            this.UseProfile.Text = "Default";
            this.UseProfile.UseVisualStyleBackColor = true;
            // 
            // ChatUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 514);
            this.Controls.Add(this.UseProfile);
            this.Controls.Add(this.ProfilePictureBrowse);
            this.Controls.Add(this.Connections);
            this.Controls.Add(this.TestPicture);
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
            ((System.ComponentModel.ISupportInitialize)(this.TestPicture)).EndInit();
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
        private System.Windows.Forms.PictureBox TestPicture;
        private System.Windows.Forms.ListBox Connections;
        private System.Windows.Forms.Button ProfilePictureBrowse;
        private System.Windows.Forms.CheckBox UseProfile;
    }
}