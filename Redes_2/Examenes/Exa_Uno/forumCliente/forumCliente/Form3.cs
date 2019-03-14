using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forumCliente
{
    public partial class Form3 : Form
    {
        public Form3(string topic, string json, string clave)
        {
            InitializeComponent();
            this.Topico.Text = topic;
            Topico[] jsonRecibidoArray = JsonConvert.DeserializeObject<Topico[]>(json);
            foreach (Topico t in jsonRecibidoArray)
            {    //por cada uno de los objetos del arreglo agregamos los posta al banner
                if (t.titulo.Contains(clave) || t.texto.Contains(clave))
                {
                    AddItem(t);
                }
            }
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
            PanelTopicos.Controls.Add(usr, 0, PanelTopicos.RowCount - 1);
            PanelTopicos.RowCount++;
            //PanelTopicos.Controls.Add(pa, 0, PanelTopicos.RowCount - 1);//se agrega el panel en columna1
            if (t.imagen != "")
                AddImage(t.imagen.Substring(2));
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
