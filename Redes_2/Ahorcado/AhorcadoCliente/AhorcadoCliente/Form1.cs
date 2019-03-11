using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AhorcadoCliente
{
    public partial class Form1 : Form
    {
       

        //Declare and Initialize the IP Adress
        IPAddress ipAd = IPAddress.Parse("127.0.0.1");

        //Declare and Initilize the Port Number;
        int PortNumber = 65432;

        Byte[] data = new Byte[256];
        public string aux = string.Empty;
        // String to store the response ASCII representation.
        String responseData = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_string("med");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void get_string(String mod)
        {
            Console.WriteLine("Connecting.....");
            try
            {
                // Create a TcpClient.
                TcpClient tcpclnt = new TcpClient();
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                tcpclnt.Connect(ipAd, PortNumber);

                // Translate the passed message into ASCII and store it as a Byte array.
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
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                aux = string.Empty;
                // Close everything.
                stream.Close();
                tcpclnt.Close();
                aux = "";
                foreach (var item in responseData)
                {
                    aux += "_ ";
                }
                wrd.Text = aux;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ez_Click(object sender, EventArgs e)
        {
            get_string("ez");
        }

        private void hrd_Click(object sender, EventArgs e)
        {
            get_string("hrd");
        }

        private void snd_Click(object sender, EventArgs e)
        {
            Char c = ch.Text[0];
            Console.WriteLine(c);
            StringBuilder sb = new StringBuilder(aux);

            for (int i = 0; i < responseData.Length; i++)
                if (responseData[i] == c)
                    sb[i*2] = c;
            aux = sb.ToString();
            wrd.Text = aux;

            if (!aux.Contains('_'))
                wrd.Text = "Felicidades has gaando";
        }
    }
}
