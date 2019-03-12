using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace forumCliente
{
    public partial class Form2 : Form
    {
        public Form2(String usuario, String jsonTopicos)
        {
            InitializeComponent();
            //crear posts 
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

            Topico[] array = new Topico[5];
            array[0] = a;
            array[1] = b;
            array[2] = a;
            array[3] = b;
            array[4] = a;
            //termina de crear posts

            string prueba = JsonConvert.SerializeObject(array);//convierte a json
            
            System.Console.WriteLine(prueba);// desplegar el json en consola para comprobar
            Topico[] jsonRecibidoArray = new Topico[100];//se crea el arreglo que va a guardar los objetos sacados del json

            jsonRecibidoArray = JsonConvert.DeserializeObject<Topico[]>(prueba);//convierte el json a objetos y los guarda en el arreglo

            foreach (Topico t in jsonRecibidoArray)//por cada uno de los objetos del arreglo
            {
                PictureBox p = new PictureBox();//se crea un picturebox para la imagen falta poner el sourec
                p.Name = "alo";
                p.Size =  new Size(653, 125);

                Label usr = new Label();//el label usuario
                usr.Text = t.usuario;

                Label txt = new Label();//el label texto
                txt.Text = t.texto;
                txt.Location = new Point(21,30);

                Panel pa = new Panel();//el tableLayoutPanel tiene dos columnas, en su segunda tiene un panel
                pa.Controls.Add(txt);//se agregan los dos labels al panel
                pa.Controls.Add(usr);

                PanelTopicos.RowCount += 1;//se añade un row
                PanelTopicos.RowStyles.Add(new RowStyle(SizeType.Absolute,50f));//no se :v copy paste)
                PanelTopicos.Controls.Add(p, 0, PanelTopicos.RowCount - 1);//agrega la imagen en la columna0
                PanelTopicos.Controls.Add(pa, 1, PanelTopicos.RowCount - 1);//se agrega el panel en columna1
                

            }



           

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
    }
}
