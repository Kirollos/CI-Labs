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

namespace Interface_Lab2
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("I");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("D");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null && port.IsOpen)
                port.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("F");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("R");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("S");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("o");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Write("f");
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
    }
}
