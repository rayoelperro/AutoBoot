using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AutoBoot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void send(string msg)
        {
            try
            {
                TcpClient client = new TcpClient(textBox1.Text.Split(':')[0], int.Parse(textBox1.Text.Split(':')[1]));
                NetworkStream sm = client.GetStream();
                StreamWriter sw = new StreamWriter(sm);
                sw.Write(msg);
                sw.Close();
                sm.Close();
            }
            catch (Exception) { MessageBox.Show("Error de conexión remota", "Error enviando a -> " + textBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void startConnectionAndSendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            send(richTextBox1.Text);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            send("c#");
        }

        private void vbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            send("vb");
        }

        private void pythonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            send("python");
        }
    }
}
