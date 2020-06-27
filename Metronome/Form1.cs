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
        public HB_Metronome()
        {
            InitializeComponent();
        }

        static void SoundPlay(object args)
        {
            int BPM = (int)args;

            while(true)
            {
                Console.Beep(440, 100);
                Thread.Sleep(1000 * 60 / BPM - 100);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_BPM.Text) || Convert.ToInt32(txt_BPM.Text) <= 0 )
                MessageBox.Show("Please input valid text", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(Convert.ToInt32(txt_BPM.Text) > 600)
            {
                MessageBox.Show("Max BPM is 600", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                btn_end.Visible = true;
                btn_start.Visible = false;
                bpm = Convert.ToInt32(txt_BPM.Text);
                thread = new Thread(new ParameterizedThreadStart(SoundPlay));
                thread.Start(bpm);
            }
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            btn_end.Visible = false;
            btn_start.Visible = true;
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
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
    }
}
