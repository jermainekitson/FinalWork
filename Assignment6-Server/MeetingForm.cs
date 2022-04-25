using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpHook;
using SharpHook.Reactive;

namespace Assignment6_Server
{
    public partial class MeetingForm : Form
    {
        Socket sendsocket;
        BackgroundWorker bgw = new BackgroundWorker();
        Bitmap screenshot;
        Graphics screenGraph;
        double xRatio;
        double yRatio;
        int winWidth;
        int winHeight;
        Image i;
        public MeetingForm(Image img)
        {
            InitializeComponent();
            i = img;
            
        }

        private void btnShareScreen_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = i;
        }

        private void btnRequestControl_Click(object sender, EventArgs e)
        {
            int xPos = 50;
            int yPos = 50;

            Win32.POINT p = new Win32.POINT(xPos, yPos);

            Win32.ClientToScreen(this.Handle, ref p);
            Win32.SetCursorPos(p.x, p.y);
        }
    }
}

