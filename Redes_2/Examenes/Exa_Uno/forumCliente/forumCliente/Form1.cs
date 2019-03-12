using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace forumCliente
{
    public partial class Form1 : Form
    {
        
        IPAddress ipAd = IPAddress.Parse("127.0.0.1");
        int PortNumber = 65432;
        Byte[] data = new Byte[256];
        public string userName = "userHolder";
        public Form1()
        {
            InitializeComponent();
            userName = Prompt.ShowDialog("Ingrese su nombre de usuario", "Forum");
            System.Console.WriteLine(userName);
            
            //getTopics();
        }

        private void getTopics(string topic)
        {
            Console.WriteLine("Connecting.....");
            try
            {
                string mod = "topic to searh";
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(ipAd, PortNumber);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(mod);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = tcpclnt.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", mod);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];


                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                // Close everything.
                stream.Close();
                tcpclnt.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void perritos_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form2 f2 = new Form2(userName,"json");
            f2.ShowDialog();
            
        }

        private void tecno_Click(object sender, EventArgs e)
        {

        }
    }
}
