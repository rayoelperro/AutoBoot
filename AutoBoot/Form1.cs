using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AutoBoot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startConnectionAndSendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient(textBox1.Text.Split(':')[0],int.Parse(textBox1.Text.Split(':')[1]));
            NetworkStream sm = client.GetStream();
            StreamWriter sw = new StreamWriter(sm);
            sw.Write(richTextBox1.Text);
            sw.Close();
            sm.Close();
        }
    }
}
