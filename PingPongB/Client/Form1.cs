using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        string serverIp = "localhost";
        int port = 11000;
        public Form1()
        {
            InitializeComponent();
        }
        private void submit_Click(object server, EventArgs e)
        {
            TcpClient client = new TcpClient(serverIp, port);
            int bytecount = Encoding.ASCII.GetByteCount(textBox1.Text);
            byte[] sendata = new byte[bytecount];
            sendata = Encoding.ASCII.GetBytes(textBox1.Text);

            NetworkStream stream = client.GetStream();
            stream.Write(sendata, 0 , sendata.Length);

            stream.Close();
            client.Close();
        }
    }
}
