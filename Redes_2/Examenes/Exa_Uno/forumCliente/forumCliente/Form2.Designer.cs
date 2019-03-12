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
            this.PanelAgregar = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.agregar = new System.Windows.Forms.Button();
            this.AgregarImagen = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.buscar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PanelTopicos = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelBusqueda.SuspendLayout();
            this.SuspendLayout();
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
            this.PanelAgregar.Location = new System.Drawing.Point(25, 637);
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
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(3, 30);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(88, 23);
            this.buscar.TabIndex = 1;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 0;
            // 
            // PanelTopicos
            // 
            this.PanelTopicos.AutoScroll = true;
            this.PanelTopicos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelTopicos.Location = new System.Drawing.Point(33, 12);
            this.PanelTopicos.Name = "PanelTopicos";
            this.PanelTopicos.Size = new System.Drawing.Size(592, 593);
            this.PanelTopicos.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 744);
            this.Controls.Add(this.PanelTopicos);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.PanelAgregar);
            this.Name = "Form2";
            this.Text = "Form2";
            this.PanelAgregar.ResumeLayout(false);
            this.PanelAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel PanelAgregar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Button AgregarImagen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FlowLayoutPanel PanelTopicos;
    }
}