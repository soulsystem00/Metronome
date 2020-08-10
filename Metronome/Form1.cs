using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Metronome
{
    public partial class HB_Metronome : Form
    {
        int bpm;
        Thread thread;
        bool start;
        public HB_Metronome()
        {
            InitializeComponent();
            txt_BPM.Text = "60";
            start = false;
        }

        static void SoundPlay(object args)
        {
            
            while (true)
            {
                Console.Beep(880, 100);
                Thread.Sleep((int)args);
                Console.Beep(440, 100);
                Thread.Sleep((int)args);
                Console.Beep(440, 100);
                Thread.Sleep((int)args);
                Console.Beep(440, 100);
                Thread.Sleep((int)args);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            start = true;
            if (String.IsNullOrEmpty(txt_BPM.Text) || Convert.ToInt32(txt_BPM.Text) <= 0 )
                MessageBox.Show("Please input valid text", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(Convert.ToInt32(txt_BPM.Text) > 360)
            {
                MessageBox.Show("Max BPM is 360", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                btn_end.Visible = true;
                btn_start.Visible = false;
                thread = new Thread(new ParameterizedThreadStart(SoundPlay));
                bpm = Convert.ToInt32(txt_BPM.Text);
                int Duration = 1000 * 60 / bpm - 100;
                thread.Start(Duration);
            }
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            btn_end.Visible = false;
            btn_start.Visible = true;
            start = false;
            thread.Abort();
        }

        private void txt_BPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (btn_start.Visible == true)
                {
                    btn_start.PerformClick();
                    btn_end.Focus();
                }
                else if (btn_end.Visible == true)
                {
                    btn_end.PerformClick();
                    btn_start.Focus();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(start)
                thread.Abort();
        }
    }
}
