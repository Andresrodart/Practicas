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
    public partial class Form2 : Form
    {
        IPAddress ipAd = IPAddress.Parse("127.0.0.1");
        int PortNumber = 65432;
        Byte[] data = new Byte[256];
        public string userName = "userHolder";
        public Form2(String usuario, String topic)
        {
            InitializeComponent();
            //crear posts 
            getTopics(topic);
            Topico a = new Topico();
            a.usuario = "jonatan";
            a.titulo = "Test";
            a.texto = "uffffffffff una prubea";
            a.imagen = "e.png";
            a.fecha = "12/3/2019";

            Topico b = new Topico();
            b.usuario = "andres";
            b.titulo = "tengo un perro";
            b.texto = "es un perro maltes";
            b.imagen = "e.png";
            b.fecha = "12/3/2019";

            Topico c = new Topico();
            c.usuario = "andres";
            c.titulo = "tengo un perro";
            c.texto = "Fin";
            c.imagen = "e.png";
            c.fecha = "12/3/2019";

            Topico[] array = new Topico[5];
            array[0] = a;
            array[1] = b;
            array[2] = a;
            array[3] = b;
            array[4] = c;
            //termina de crear posts

            string prueba = JsonConvert.SerializeObject(array);//convierte a json
            
            System.Console.WriteLine(prueba);// desplegar el json en consola para comprobar
            Topico[] jsonRecibidoArray = new Topico[100];//se crea el arreglo que va a guardar los objetos sacados del json

            jsonRecibidoArray = JsonConvert.DeserializeObject<Topico[]>(prueba);//convierte el json a objetos y los guarda en el arreglo

            foreach (Topico t in jsonRecibidoArray)//por cada uno de los objetos del arreglo
            {
                AddItem(t);
                /*PictureBox p = new PictureBox();//se crea un picturebox para la imagen falta poner el sourec
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Name = "alo";
                p.Size =  new Size(250, 250);
                Bitmap MyImage = new Bitmap("C:/Users/andre/Pictures/io.jpg");
                p.Image = (Image) MyImage;

                Label usr = new Label();//el label usuario
                usr.Text = "Usuario: " + t.usuario;

                Label txt = new Label();//el label texto
                txt.Text = t.texto;
                txt.Location = new Point(21,30);

                Panel pa = new Panel();//el tableLayoutPanel tiene dos columnas, en su segunda tiene un panel
                pa.Controls.Add(usr);
                pa.Controls.Add(txt);//se agregan los dos labels al panel
                

                PanelTopicos.RowCount += 1;//se añade un row
                PanelTopicos.RowStyles.Add(new RowStyle());//no se :v copy paste)
                PanelTopicos.Controls.Add(p, 0, PanelTopicos.RowCount - 1);//agrega la imagen en la columna0
                PanelTopicos.Controls.Add(pa, 0, PanelTopicos.RowCount - 1);//se agrega el panel en columna1*/


            }



           

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void AddItem(Topico t)
        {
            Label usr = new Label();//el label usuario
            usr.Text = "Usuario: " + t.usuario;

            Label txt = new Label();//el label texto
            txt.Text = t.texto;
            txt.Location = new Point(21, 30);

            Panel pa = new Panel();//el tableLayoutPanel tiene dos columnas, en su segunda tiene un panel
            pa.Controls.Add(usr);
            pa.Controls.Add(txt);//se agregan los dos labels al panel
            //get a reference to the previous existent 
            //RowStyle temp = PanelTopicos.RowStyles[panel.RowCount - 1];
            //increase panel rows count by one
            PanelTopicos.RowCount++;
            //add a new RowStyle as a copy of the previous one
            //PanelTopicos.RowStyles.Add(new RowStyle());
            //add your three controls
            //PanelTopicos.Controls.Add(p, 0, PanelTopicos.RowCount - 1);//agrega la imagen en la columna0
            PanelTopicos.Controls.Add(pa, 0, PanelTopicos.RowCount - 1);//se agrega el panel en columna1
            if (t.imagen != "")
                AddImage(t.imagen);
        }

        private void AddImage(string imagen)
        {
            PictureBox p = new PictureBox();//se crea un picturebox para la imagen falta poner el sourec
            p.Size = new Size(250, 250);
            p.SizeMode = PictureBoxSizeMode.Zoom;
            p.Name = "alo";
            Bitmap MyImage = new Bitmap("C:/Users/andre/Pictures/io.jpg");
            p.Image = (Image)MyImage;
            PanelTopicos.RowCount++;
            //PanelTopicos.RowStyles.Add(new RowStyle());
            PanelTopicos.Controls.Add(p, 0, PanelTopicos.RowCount - 1);//agrega la imagen en la columna0
        }


        private void getTopics(string topic)
        {
            Console.WriteLine("Connecting.....");
            try
            {
                NetworkStream stream = tcpclnt.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("1");
                stream.Write(data, 0, data.Length);

                string mod = topic;
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(ipAd, PortNumber);
                data = System.Text.Encoding.ASCII.GetBytes(mod);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

               
                
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
