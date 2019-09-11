using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace LokiTime
{
    public partial class Form1 : Form
    {

        // Create timer
        System.Timers.Timer t;

        // Create integers for hours, minutes, seconds.
        int h, m, s;
        
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            // Create notification object.
            var popupNotifier = new PopupNotifier();

            //var test = txtResult.Text;
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                txtResult.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                //Compare txtResult.Text with expected time period  txtResult.Text %60 == 0
                if (txtResult.Text == "00:30:00")
                {
                    popupNotifier.TitleText = "Study session complete!";
                    popupNotifier.ContentText = $"Congratulation on studying for {m} minutes!";
                    popupNotifier.IsRightToLeft = false;
                    popupNotifier.Popup();
                }
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Stop();
            Application.DoEvents();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            t.Enabled = false;
            s = 0;
            m = 0;
            h = 0;
            txtResult.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            t.Start();
            t.Enabled = true;

            // Create notification object.
            var popupNotifier = new PopupNotifier();
            popupNotifier.TitleText = "Study session complete!";
            popupNotifier.ContentText = $"Congratulation on studying for {m} minutes!";
            popupNotifier.IsRightToLeft = false;
            //var test = txtResult.Text;
            


            //if (s == 10)

            // fire notification.
            //popupNotifier.Popup();
            
            //DateTime notificationTracker = DateTime.Now;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}
