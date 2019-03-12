namespace forumCliente
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelTopicos = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Usr = new System.Windows.Forms.Label();
            this.Texto = new System.Windows.Forms.Label();
            this.PanelAgregar = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.agregar = new System.Windows.Forms.Button();
            this.AgregarImagen = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelTopicos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 119);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PanelTopicos
            // 
            this.PanelTopicos.AutoScroll = true;
            this.PanelTopicos.ColumnCount = 2;
            this.PanelTopicos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelTopicos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.PanelTopicos.Controls.Add(this.pictureBox1, 0, 0);
            this.PanelTopicos.Controls.Add(this.panel1, 1, 0);
            this.PanelTopicos.Location = new System.Drawing.Point(25, 25);
            this.PanelTopicos.Name = "PanelTopicos";
            this.PanelTopicos.RowCount = 1;
            this.PanelTopicos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelTopicos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelTopicos.Size = new System.Drawing.Size(653, 125);
            this.PanelTopicos.TabIndex = 1;
            this.PanelTopicos.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Texto);
            this.panel1.Controls.Add(this.Usr);
            this.panel1.Location = new System.Drawing.Point(242, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 119);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // Usr
            // 
            this.Usr.AutoSize = true;
            this.Usr.Location = new System.Drawing.Point(18, 13);
            this.Usr.Name = "Usr";
            this.Usr.Size = new System.Drawing.Size(43, 13);
            this.Usr.TabIndex = 0;
            this.Usr.Text = "Usuario";
            this.Usr.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Texto
            // 
            this.Texto.AutoSize = true;
            this.Texto.Location = new System.Drawing.Point(21, 30);
            this.Texto.Name = "Texto";
            this.Texto.Size = new System.Drawing.Size(387, 13);
            this.Texto.TabIndex = 1;
            this.Texto.Text = "TEXTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO";
            // 
            // PanelAgregar
            // 
            this.PanelAgregar.AutoScroll = true;
            this.PanelAgregar.ColumnCount = 4;
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.34483F));
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.7931F));
            this.PanelAgregar.Controls.Add(this.textBox1, 0, 0);
            this.PanelAgregar.Controls.Add(this.agregar, 1, 0);
            this.PanelAgregar.Controls.Add(this.AgregarImagen, 2, 0);
            this.PanelAgregar.Controls.Add(this.pictureBox2, 3, 0);
            this.PanelAgregar.Location = new System.Drawing.Point(12, 377);
            this.PanelAgregar.Name = "PanelAgregar";
            this.PanelAgregar.RowCount = 1;
            this.PanelAgregar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelAgregar.Size = new System.Drawing.Size(725, 61);
            this.PanelAgregar.TabIndex = 3;
            this.PanelAgregar.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(52, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 55);
            this.textBox1.TabIndex = 0;
            // 
            // agregar
            // 
            this.agregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.agregar.Location = new System.Drawing.Point(365, 19);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(66, 23);
            this.agregar.TabIndex = 1;
            this.agregar.Text = "agregar";
            this.agregar.UseVisualStyleBackColor = true;
            // 
            // AgregarImagen
            // 
            this.AgregarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgregarImagen.Location = new System.Drawing.Point(437, 9);
            this.AgregarImagen.Name = "AgregarImagen";
            this.AgregarImagen.Size = new System.Drawing.Size(68, 42);
            this.AgregarImagen.TabIndex = 2;
            this.AgregarImagen.Text = "Agregar Imagen\r\n";
            this.AgregarImagen.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(511, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(211, 55);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.buscar);
            this.panelBusqueda.Controls.Add(this.textBox2);
            this.panelBusqueda.Location = new System.Drawing.Point(694, 25);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(94, 131);
            this.panelBusqueda.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 0;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(3, 30);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(88, 23);
            this.buscar.TabIndex = 1;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.PanelAgregar);
            this.Controls.Add(this.PanelTopicos);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelTopicos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelAgregar.ResumeLayout(false);
            this.PanelAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Usr;
        private System.Windows.Forms.Label Texto;
        private System.Windows.Forms.TableLayoutPanel PanelAgregar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Button AgregarImagen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TableLayoutPanel PanelTopicos;
    }
}