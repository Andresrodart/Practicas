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


        private void perritos_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form2 f2 = new Form2(userName,"perritos");
            f2.ShowDialog();
            
        }

        private void tecno_Click(object sender, EventArgs e)
        {

        }
    }
}
