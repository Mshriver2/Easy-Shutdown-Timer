using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Timer
{
    public partial class Form1 : Form
    {

        int h;
        int m;
        int s;
        bool selectedMethod;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {

            s = s - 1;

            if (s == -1)
            {
                m -= 1;
                s = 59;
            }

            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }

            //tests if it should shutdown or restart
            if (h == 0 && m == 0 && s == 0)
            {

                if (selectedMethod == true)
                {
                    System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                }
                else
                {
                    System.Diagnostics.Process.Start("restart", "/r /t 0");
                }

                
                timer1.Stop();
                button1.Enabled = true;
            }

            string hh = Convert.ToString(h);
            string mm = Convert.ToString(m);
            string ss = Convert.ToString(s);

            label1.Text = hh;
            label2.Text = mm;
            label3.Text = ss;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //looks to see which option is selected shutdown/restart
            if (comboBox1.SelectedIndex == 0)
            {
                selectedMethod = true;
            }
            else
            {
                selectedMethod = false;
            }

            //disables the start button after being pressed
            button1.Enabled = false;

            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }

            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }

            h = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);
            s = Convert.ToInt32(textBox3.Text);

            timer1.Start();
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Shutdown";
        }
    }
}
