using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Simple_CountDown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int hours, mins, secs;

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("No correct inputs");
            }
            else
            {
                hours = int.Parse(textBox1.Text);
                mins = int.Parse(textBox2.Text);
                secs = int.Parse(textBox3.Text);
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = true;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hours == 0 && mins == 0 && secs == 0)
            {
                timer1.Stop();
                MessageBox.Show(new Form() { TopMost = true }, "Hết giờ!!!", "nhấn OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "00";
                textBox2.Text = "00";
                textBox3.Text = "00";
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = true;
                button1.Enabled = true;
                lblHr.Text = "00";
                lblMin.Text = "00";
                lblSec.Text = "00";
                Form2 ss = new Form2();
                ss.Show();
            }
            else
            {
                if (secs < 1)
                {
                    secs = 59;
                    if (mins < 1)
                    {
                        mins = 59;
                        if (hours != 0)
                            hours -= 1;
                    }
                    else mins -= 1;

                }
                else secs -= 1;
                if (hours > 9)
                    lblHr.Text = hours.ToString();
                else lblHr.Text = "0" + hours.ToString();
                if (mins > 9)
                    lblMin.Text = mins.ToString();
                else lblMin.Text = "0" + mins.ToString();
                if (secs > 9)
                    lblSec.Text = secs.ToString();
                else lblSec.Text = "0" + secs.ToString();
            }
        }
    }
}
