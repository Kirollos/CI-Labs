using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Interface_Lab4
{
    public partial class Form1 : Form
    {
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //port = new SerialPort("COM10", 9600);
            //port.Open();
            comboBox1.DataSource = SerialPort.GetPortNames();
            label2.Text = "Disconnected";
            label2.ForeColor = Color.Red;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null && port.IsOpen)
                port.Close();
        }



        private void button8_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                label2.Text = "Disconnected";
                label2.ForeColor = Color.Red;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (port != null)
                if (port.IsOpen)
                    port.Close();
            port = new SerialPort(comboBox1.Text, 9600);
            port.Open();
            if (port.IsOpen)
            {
                label2.Text = "Connected";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = "Disconnected";
                label2.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(port.IsOpen)
            {
                int idx = comboBox2.SelectedIndex;
                int amp = int.Parse(textBox1.Text);
                int freq = int.Parse(textBox2.Text);
                string frame = "";
                frame = "@" + idx + amp.ToString("00") + freq.ToString("000") + ";";

                port.Write(frame);
            }
        }
    }
}
