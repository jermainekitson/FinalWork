
namespace Assignment6_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbIPAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoginusername = new System.Windows.Forms.TextBox();
            this.txtPrivateMessage = new System.Windows.Forms.TextBox();
            this.btnPublicChat = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstRead = new System.Windows.Forms.ListBox();
            this.btnShareScreen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 15;
            this.lstMessages.Location = new System.Drawing.Point(17, 26);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(503, 109);
            this.lstMessages.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnConnect.FlatAppearance.BorderSize = 5;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.ForeColor = System.Drawing.Color.Blue;
            this.btnConnect.Location = new System.Drawing.Point(122, 160);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbIPAddress
            // 
            this.cmbIPAddress.FormattingEnabled = true;
            this.cmbIPAddress.Location = new System.Drawing.Point(120, 32);
            this.cmbIPAddress.Name = "cmbIPAddress";
            this.cmbIPAddress.Size = new System.Drawing.Size(189, 23);
            this.cmbIPAddress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP ADDRESS";
            // 
            // btnSend
            // 
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSend.FlatAppearance.BorderSize = 5;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSend.ForeColor = System.Drawing.Color.Green;
            this.btnSend.Location = new System.Drawing.Point(726, 161);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 23);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(509, 161);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(211, 23);
            this.txtMessage.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtHostName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbIPAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(318, 146);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REMOTE SYSTEM DETAILS";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(120, 113);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(189, 23);
            this.txtPort.TabIndex = 10;
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(120, 72);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(189, 23);
            this.txtHostName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "HOST NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "PORT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstMessages);
            this.groupBox2.Location = new System.Drawing.Point(362, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(545, 146);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MESSAGES";
            // 
            // btnSendFile
            // 
            this.btnSendFile.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSendFile.FlatAppearance.BorderSize = 5;
            this.btnSendFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendFile.ForeColor = System.Drawing.Color.Blue;
            this.btnSendFile.Location = new System.Drawing.Point(802, 161);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(80, 23);
            this.btnSendFile.TabIndex = 13;
            this.btnSendFile.Text = "SEND FILE";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnLogin);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtLoginusername);
            this.groupBox3.Location = new System.Drawing.Point(3, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 135);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Credentials";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(118, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 15);
            this.label4.TabIndex = 49;
            this.label4.Text = "Must Login in to send a message";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnLogin.FlatAppearance.BorderSize = 5;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.Blue;
            this.btnLogin.Location = new System.Drawing.Point(227, 91);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 23);
            this.btnLogin.TabIndex = 35;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "username";
            // 
            // txtLoginusername
            // 
            this.txtLoginusername.Location = new System.Drawing.Point(118, 60);
            this.txtLoginusername.Name = "txtLoginusername";
            this.txtLoginusername.Size = new System.Drawing.Size(189, 23);
            this.txtLoginusername.TabIndex = 33;
            // 
            // txtPrivateMessage
            // 
            this.txtPrivateMessage.Location = new System.Drawing.Point(509, 311);
            this.txtPrivateMessage.Name = "txtPrivateMessage";
            this.txtPrivateMessage.Size = new System.Drawing.Size(211, 23);
            this.txtPrivateMessage.TabIndex = 44;
            // 
            // btnPublicChat
            // 
            this.btnPublicChat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnPublicChat.FlatAppearance.BorderSize = 5;
            this.btnPublicChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPublicChat.ForeColor = System.Drawing.Color.Green;
            this.btnPublicChat.Location = new System.Drawing.Point(778, 310);
            this.btnPublicChat.Name = "btnPublicChat";
            this.btnPublicChat.Size = new System.Drawing.Size(104, 23);
            this.btnPublicChat.TabIndex = 45;
            this.btnPublicChat.Text = "SEND";
            this.btnPublicChat.UseVisualStyleBackColor = true;
            this.btnPublicChat.Click += new System.EventHandler(this.btnPublicChat_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(362, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 15);
            this.label11.TabIndex = 47;
            this.label11.Text = "Read Host Messages";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Crimson;
            this.label12.Location = new System.Drawing.Point(362, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 15);
            this.label12.TabIndex = 48;
            this.label12.Text = "Send message to Users";
            // 
            // lstRead
            // 
            this.lstRead.FormattingEnabled = true;
            this.lstRead.ItemHeight = 15;
            this.lstRead.Location = new System.Drawing.Point(512, 209);
            this.lstRead.Name = "lstRead";
            this.lstRead.Size = new System.Drawing.Size(370, 94);
            this.lstRead.TabIndex = 49;
            // 
            // btnShareScreen
            // 
            this.btnShareScreen.Location = new System.Drawing.Point(623, 452);
            this.btnShareScreen.Name = "btnShareScreen";
            this.btnShareScreen.Size = new System.Drawing.Size(97, 23);
            this.btnShareScreen.TabIndex = 50;
            this.btnShareScreen.Text = "Send Screen";
            this.btnShareScreen.UseVisualStyleBackColor = true;
            this.btnShareScreen.Click += new System.EventHandler(this.btnShareScreen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(368, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 138);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            //this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 487);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnShareScreen);
            this.Controls.Add(this.lstRead);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPublicChat);
            this.Controls.Add(this.txtPrivateMessage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoginusername;
        private System.Windows.Forms.TextBox txtPrivateMessage;
        private System.Windows.Forms.Button btnPublicChat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstRead;
        private System.Windows.Forms.Button btnShareScreen;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

