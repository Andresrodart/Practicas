﻿namespace forumCliente
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
            this.components = new System.ComponentModel.Container();
            this.PanelAgregar = new System.Windows.Forms.TableLayoutPanel();
            this.tituloLabel = new System.Windows.Forms.TextBox();
            this.agregar = new System.Windows.Forms.Button();
            this.mensajeSend = new System.Windows.Forms.TextBox();
            this.AgregarImagen = new System.Windows.Forms.Button();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.clave = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reload = new System.Windows.Forms.Timer(this.components);
            this.PanelAgregar.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelAgregar
            // 
            this.PanelAgregar.AutoScroll = true;
            this.PanelAgregar.ColumnCount = 4;
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.65517F));
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.62069F));
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37931F));
            this.PanelAgregar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.2069F));
            this.PanelAgregar.Controls.Add(this.tituloLabel, 0, 0);
            this.PanelAgregar.Controls.Add(this.agregar, 3, 0);
            this.PanelAgregar.Controls.Add(this.mensajeSend, 1, 0);
            this.PanelAgregar.Controls.Add(this.AgregarImagen, 2, 0);
            this.PanelAgregar.Location = new System.Drawing.Point(25, 637);
            this.PanelAgregar.Name = "PanelAgregar";
            this.PanelAgregar.RowCount = 1;
            this.PanelAgregar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelAgregar.Size = new System.Drawing.Size(725, 61);
            this.PanelAgregar.TabIndex = 3;
            this.PanelAgregar.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tituloLabel
            // 
            this.tituloLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tituloLabel.Location = new System.Drawing.Point(3, 7);
            this.tituloLabel.Multiline = true;
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(180, 47);
            this.tituloLabel.TabIndex = 3;
            // 
            // agregar
            // 
            this.agregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.agregar.Location = new System.Drawing.Point(654, 9);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(66, 42);
            this.agregar.TabIndex = 1;
            this.agregar.Text = "agregar";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // mensajeSend
            // 
            this.mensajeSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mensajeSend.Location = new System.Drawing.Point(204, 3);
            this.mensajeSend.Multiline = true;
            this.mensajeSend.Name = "mensajeSend";
            this.mensajeSend.Size = new System.Drawing.Size(331, 55);
            this.mensajeSend.TabIndex = 0;
            this.mensajeSend.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AgregarImagen
            // 
            this.AgregarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgregarImagen.Location = new System.Drawing.Point(567, 9);
            this.AgregarImagen.Name = "AgregarImagen";
            this.AgregarImagen.Size = new System.Drawing.Size(68, 42);
            this.AgregarImagen.TabIndex = 2;
            this.AgregarImagen.Text = "Agregar Imagen\r\n";
            this.AgregarImagen.UseVisualStyleBackColor = true;
            this.AgregarImagen.Click += new System.EventHandler(this.AgregarImagen_Click);
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.clave);
            this.panelBusqueda.Controls.Add(this.buscar);
            this.panelBusqueda.Location = new System.Drawing.Point(694, 25);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(94, 131);
            this.panelBusqueda.TabIndex = 4;
            // 
            // clave
            // 
            this.clave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clave.Location = new System.Drawing.Point(3, 6);
            this.clave.Multiline = true;
            this.clave.Name = "clave";
            this.clave.Size = new System.Drawing.Size(88, 24);
            this.clave.TabIndex = 8;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(3, 37);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(88, 23);
            this.buscar.TabIndex = 1;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 610);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mensaje";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(28, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 550);
            this.panel1.TabIndex = 9;
            // 
            // reload
            // 
            this.reload.Enabled = true;
            this.reload.Interval = 1000;
            this.reload.Tick += new System.EventHandler(this.reload_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 744);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.PanelAgregar);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.PanelAgregar.ResumeLayout(false);
            this.PanelAgregar.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel PanelAgregar;
        private System.Windows.Forms.TextBox mensajeSend;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Button AgregarImagen;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox tituloLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer reload;
    }
}