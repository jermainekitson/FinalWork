namespace Assignment6_Server
{
    partial class Welcome
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
            this.lblGeneratedCode = new System.Windows.Forms.Label();
            this.lblInviteUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasteCodeHere = new System.Windows.Forms.TextBox();
            this.btnEnterMeeting = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGeneratedCode
            // 
            this.lblGeneratedCode.AutoSize = true;
            this.lblGeneratedCode.Location = new System.Drawing.Point(142, 41);
            this.lblGeneratedCode.Name = "lblGeneratedCode";
            this.lblGeneratedCode.Size = new System.Drawing.Size(38, 15);
            this.lblGeneratedCode.TabIndex = 0;
            this.lblGeneratedCode.Text = "label1";
            // 
            // lblInviteUser
            // 
            this.lblInviteUser.AutoSize = true;
            this.lblInviteUser.Location = new System.Drawing.Point(142, 95);
            this.lblInviteUser.Name = "lblInviteUser";
            this.lblInviteUser.Size = new System.Drawing.Size(38, 15);
            this.lblInviteUser.TabIndex = 1;
            this.lblInviteUser.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copy and Paste Code below to proceed";
            // 
            // txtPasteCodeHere
            // 
            this.txtPasteCodeHere.Location = new System.Drawing.Point(109, 164);
            this.txtPasteCodeHere.Name = "txtPasteCodeHere";
            this.txtPasteCodeHere.Size = new System.Drawing.Size(100, 23);
            this.txtPasteCodeHere.TabIndex = 2;
            // 
            // btnEnterMeeting
            // 
            this.btnEnterMeeting.Location = new System.Drawing.Point(179, 211);
            this.btnEnterMeeting.Name = "btnEnterMeeting";
            this.btnEnterMeeting.Size = new System.Drawing.Size(93, 23);
            this.btnEnterMeeting.TabIndex = 3;
            this.btnEnterMeeting.Text = "Enter Meeting";
            this.btnEnterMeeting.UseVisualStyleBackColor = true;
            this.btnEnterMeeting.Click += new System.EventHandler(this.btnEnterMeeting_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(57, 211);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(93, 23);
            this.btnDecline.TabIndex = 3;
            this.btnDecline.Text = "Decline Invite";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 288);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnEnterMeeting);
            this.Controls.Add(this.txtPasteCodeHere);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInviteUser);
            this.Controls.Add(this.lblGeneratedCode);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGeneratedCode;
        private System.Windows.Forms.Label lblInviteUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPasteCodeHere;
        private System.Windows.Forms.Button btnEnterMeeting;
        private System.Windows.Forms.Button btnDecline;
    }
}