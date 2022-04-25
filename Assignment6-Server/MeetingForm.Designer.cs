namespace Assignment6_Server
{
    partial class MeetingForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnShareScreen = new System.Windows.Forms.Button();
            this.btnRequestControl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 370);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            //this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnShareScreen
            // 
            this.btnShareScreen.Location = new System.Drawing.Point(691, 388);
            this.btnShareScreen.Name = "btnShareScreen";
            this.btnShareScreen.Size = new System.Drawing.Size(97, 23);
            this.btnShareScreen.TabIndex = 1;
            this.btnShareScreen.Text = "Share Screen";
            this.btnShareScreen.UseVisualStyleBackColor = true;
            this.btnShareScreen.Click += new System.EventHandler(this.btnShareScreen_Click);
            // 
            // btnRequestControl
            // 
            this.btnRequestControl.Location = new System.Drawing.Point(561, 388);
            this.btnRequestControl.Name = "btnRequestControl";
            this.btnRequestControl.Size = new System.Drawing.Size(109, 23);
            this.btnRequestControl.TabIndex = 2;
            this.btnRequestControl.Text = "Request Control";
            this.btnRequestControl.UseVisualStyleBackColor = true;
            this.btnRequestControl.Click += new System.EventHandler(this.btnRequestControl_Click);
            // 
            // MeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRequestControl);
            this.Controls.Add(this.btnShareScreen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MeetingForm";
            this.Text = "MeetingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnShareScreen;
        private System.Windows.Forms.Button btnRequestControl;
    }
}