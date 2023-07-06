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
using System.Globalization;
using static System.Windows.Forms.DataFormats;

namespace Interface_Lab3
{
    public partial class Form1 : Form
    {
        SerialPort port;
        string current_frame = "";
        bool frame_stared = false;

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
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataReceived += Port_DataReceived;
            port.ReadTimeout = 2000;
            frame_stared = false;
            try
            {
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
            catch (Exception ex)
            {
                label2.Text = "Failed";
                label2.ForeColor = Color.Red;
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /*var p = (SerialPort)sender;
            string rx_data = p.ReadExisting();
            int idx_start = rx_data.IndexOf('@');
            int idx_end = rx_data.IndexOf(';');

            if (idx_end >= 0 && frame_stared)
            {
                frame_stared = false;
                current_frame += rx_data.Substring(0, idx_end);
                string ret_val = current_frame.Substring(4, 3);//@RR:xxx;
                textBox2.BeginInvoke(() => { if (comboBox2.Text == "Read") textBox2.Text = ret_val; });
                    //textBox2.Text = ret_val;
            }
            if(frame_stared)
            {
                current_frame += rx_data;
            }
            if(idx_start >= 0 && !frame_stared)
            {
                current_frame = "";
                frame_stared = true;

                if(rx_data.Length > idx_start + 1)
                {
                    current_frame += rx_data.Substring(idx_start + 1);
                }
            }*/
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Read")
            {
                // Read
                textBox2.Text = "";
                textBox2.ReadOnly = true;
                button1.Text = "Read";
            }
            else
            {
                // Write
                textBox2.Text = "";
                textBox2.ReadOnly = false;
                button1.Text = "Write";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string address = textBox1.Text;
            if (comboBox2.Text == "Read")
            {
                // Read
                if (port.IsOpen)
                {
                    port.DiscardInBuffer();
                    port.Write("@R" + address + "000;");
                    char[] buffer = new char[8];
                    //int len = port.Read(buffer, 0, 8);
                    int len = 0;
                    string buff = "";
                    bool start = false;
                    bool end = false;
                    while (true)
                    {
                        try
                        {
                            len = port.Read(buffer, 0, 8);
                        }
                        catch
                        {
                            start = end = false;
                            break;
                        }
                        for (int i = 0; i < len; i++)
                        {
                            if (buffer[i] == '@')
                                start = true;
                            if (start)
                                buff += buffer[i];
                            if (start && buffer[i] == ';') //end
                            {
                                end = true;
                                break;
                            }
                        }
                        if (end) break;
                    }

                    if (!start && !end)
                    {
                        textBox2.Text = "Failed to read";
                        return;
                    }

                    //if(len == 8)
                    //{
                    string ret_val = new string(buff).Substring(4, 3);
                    textBox2.Text = int.Parse(ret_val).ToString();
                    //}
                }
            }
            else
            {
                // Write
                if (textBox2.TextLength > 0)
                {
                    int value = int.Parse(textBox2.Text);
                    if (value >= 0 && value <= 255)
                    {
                        if (port.IsOpen)
                            port.Write("@W" + address + value.ToString("000") + ";");
                    }
                }
            }
        }
    }
}
