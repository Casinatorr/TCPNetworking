
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
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(66, 43);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(100, 35);
            this.IP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(66, 93);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(100, 35);
            this.Port.TabIndex = 4;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(66, 134);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 38);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            // 
            // PortError
            // 
            this.PortError.AutoSize = true;
            this.PortError.Location = new System.Drawing.Point(172, 96);
            this.PortError.Name = "PortError";
            this.PortError.Size = new System.Drawing.Size(188, 30);
            this.PortError.TabIndex = 6;
            this.PortError.Text = "Max. port is 65.535";
            // 
            // ChatUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 514);
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
    }
}