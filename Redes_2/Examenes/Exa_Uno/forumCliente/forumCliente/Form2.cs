using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string json="";
        IPAddress ipAd = IPAddress.Parse("127.0.0.1");
        int PortNumber = 65435;
        Byte[] data = new Byte[256];
        public string userName = "userHolder";
        Topico[] jsonRecibidoArray = new Topico[100];//se crea el arreglo que va a guardar los objetos sacados del json
        int[] auxPostExist = new int[100];
        string root = @"C:\imagesServer";
        string sourceFile = "";
        string topic = "";
        public Form2(String usuario, String topic)
        {
            InitializeComponent();
            userName = usuario;
            this.topic = topic;
            getTopics();                           //Obtener posts 
        }
        private void AddItem(Topico t)
        {
            Label usr = new Label();//el label usuario
            usr.Font = new Font("Arial", 12, FontStyle.Bold);
            usr.Text = "Usuario: " + t.usuario;
            usr.AutoSize = true;
            Label txt = new Label();//el label texto
            txt.Text = t.texto;
            txt.AutoSize = true;
            PanelTopicos.Controls.Add(txt, 0, PanelTopicos.RowCount - 1);//se agregan los dos labels al panel
            PanelTopicos.Controls.Add(usr,0, PanelTopicos.RowCount - 1);
            PanelTopicos.RowCount++;
            //PanelTopicos.Controls.Add(pa, 0, PanelTopicos.RowCount - 1);//se agrega el panel en columna1
            if (t.imagen != "")
                AddImage(t.imagen.Substring(2));
        }

        private void AddImage(string imagen)
        {
            String[] path2Image = new String[imagen.Split('/').Length + 1];
            path2Image[0] = @"C:\";
            imagen.Split('/').CopyTo(path2Image, 1);
            string img_2add = Path.Combine(path2Image);
            PictureBox p = new PictureBox();//se crea un picturebox para la imagen falta poner el sourec
            p.Size = new Size(250, 250);
            p.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {

                Bitmap MyImage = new Bitmap(img_2add);
                p.Image = (Image)MyImage;
                PanelTopicos.RowCount++;
                PanelTopicos.Controls.Add(p, 0, PanelTopicos.RowCount - 2);//agrega la imagen en la columna0
            }
            catch (Exception)
            {

            }
          
        }


        private void getTopics()
        {
            Console.WriteLine("Connecting to get topics.....");
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(ipAd, PortNumber);
                NetworkStream stream = tcpclnt.GetStream();

                Byte[] data = System.Text.Encoding.ASCII.GetBytes("0");
                stream.Write(data, 0, data.Length);

                data = new Byte[256];
                data = System.Text.Encoding.ASCII.GetBytes(topic);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", topic);

                // Buffer to store the response bytes.
                data = new Byte[4096];
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                data = new Byte[256];
                data = System.Text.Encoding.ASCII.GetBytes("3Salir");

                stream.Write(data, 0, data.Length);
                stream.Close();
                tcpclnt.Close();
                jsonRecibidoArray = new Topico[100];//se crea el arreglo que va a guardar los objetos sacados del json
                jsonRecibidoArray = JsonConvert.DeserializeObject<Topico[]>(responseData);//convierte el json a objetos y los guarda en el arreglo
                json = responseData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            getImages();                                //Buscamos si tenemos la simagenes
            foreach (Topico t in jsonRecibidoArray)     //por cada uno de los objetos del arreglo agregamos los posta al banner
                AddItem(t);

        }

        private void getImages()
        {
            foreach (var item in jsonRecibidoArray)
            {
                if (item.imagen != "")
                {
                    try
                    {
                        string pathString = item.imagen.Substring(1);
                        string[] imageInfo = pathString.Split('/');
                        string subfolder = System.IO.Path.Combine(root, imageInfo[2]);
                        string file = System.IO.Path.Combine(subfolder, imageInfo[3]);
                        if (!Directory.Exists(subfolder))
                            Directory.CreateDirectory(subfolder);
                        if (!System.IO.File.Exists(file))
                        {
                            using (System.IO.FileStream fs = System.IO.File.Create(file))
                            {
                                Console.WriteLine("Connecting to get images.....");
                                try
                                {
                                    TcpClient tcpclnt = new TcpClient();
                                    tcpclnt.Connect(ipAd, PortNumber);
                                    NetworkStream stream = tcpclnt.GetStream();
                                    Byte[] data = System.Text.Encoding.ASCII.GetBytes('2' + item.imagen);
                                    stream.Write(data, 0, data.Length);
                                    data = new Byte[1024];

                                    // Read the first batch of the TcpServer response bytes.
                                    int bytesRead;
                                    while ((bytesRead = stream.Read(data, 0, data.Length)) > 0)
                                    {
                                        fs.Write(data, 0, bytesRead);
                                        Console.WriteLine(bytesRead);
                                        if (bytesRead < 1024)
                                            break;
                                    }
                                    Console.WriteLine("Done reciving.....");
                                    //  Console.WriteLine("Received: {0}", responseData);
                                    // Close everything.
                                    data = new Byte[256];
                                    data = System.Text.Encoding.ASCII.GetBytes("3Salir");

                                    stream.Write(data, 0, data.Length);
                                    stream.Close();
                                    tcpclnt.Close();

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                    }

                }

            }
            
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            string[] fecha = DateTime.Now.Date.ToString().Split(' ');
            Topico _2Send = new Topico();
            _2Send.usuario = userName;
            _2Send.titulo = tituloLabel.Text;
            _2Send.fecha = fecha[0];
            _2Send.imagen = (sourceFile != "")? "./imagesServer/" + fecha[0].Replace('/', '_') + '/' + Path.GetFileName(sourceFile): sourceFile;
            _2Send.texto = mensajeSend.Text;
            string JsonToSend = JsonConvert.SerializeObject(_2Send);
            Console.WriteLine(JsonToSend);

            if (_2Send.titulo == "" && _2Send.texto == "")
            {
                MessageBox.Show("Campos vacíos");
            }
            else
            {
                Console.WriteLine("Connecting.....");
                try
                {
                    TcpClient tcpclnt = new TcpClient();
                    tcpclnt.Connect(ipAd, PortNumber);
                    NetworkStream stream = tcpclnt.GetStream();
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("1"+topic);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Se envio : "+"1"+topic);

                    data = new Byte[1024];
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);

                    data = new Byte[4096];
                    data = System.Text.Encoding.ASCII.GetBytes(JsonToSend);
                    stream.Write(data, 0, data.Length);
                    data = new Byte[1024];

                    if (sourceFile != "")
                    {
                        byte[] imgeByArr = ReadImageFile(sourceFile);
                        int bufferSize = 1024;

                        // Send to server
                        int bytesSent = 0;
                        int bytesLeft = imgeByArr.Length;

                        while (bytesLeft > 0)
                        {
                            int curDataSize = Math.Min(bufferSize, bytesLeft);

                            stream.Write(imgeByArr, bytesSent, curDataSize);

                            bytesSent += curDataSize;
                            bytesLeft -= curDataSize;
                        }
                        Console.WriteLine("Done sending image: " + bytesSent);

                    }
                    data = new Byte[1024];
                    bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                    // Close everything.
                    data = new Byte[256];
                    data = System.Text.Encoding.ASCII.GetBytes("3Salir");
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                    tcpclnt.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            getTopics();
        }

        private void AgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files|*.jpg;*.jpeg;*.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceFile = dialog.FileName;
                Console.WriteLine(sourceFile);
            }
        }


        private static byte[] ReadImageFile(String img)
        {
            FileInfo fileInfo = new FileInfo(img);
            byte[] buf = new byte[fileInfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            //fileInfo.Delete ();
            GC.ReRegisterForFinalize(fileInfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }

            private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void PanelTopicos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this.topic,json,this.clave.Text);
            f3.ShowDialog();
        }
    }
}
