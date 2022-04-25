using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6_Server
{
    public partial class Welcome : Form
    {
        Image u = null;
        public Welcome(string s, string g)
        {
            InitializeComponent();
            lblGeneratedCode.Text = g;
            lblInviteUser.Text = s;
        }

        private void btnEnterMeeting_Click(object sender, EventArgs e)
        {
            if (lblGeneratedCode.Text != txtPasteCodeHere.Text)
                MessageBox.Show("Incorrect Code !!");
            else
            {
                MeetingForm frm = new MeetingForm(u);
                frm.ShowDialog();   
            }

        }
        private void btnDecline_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
