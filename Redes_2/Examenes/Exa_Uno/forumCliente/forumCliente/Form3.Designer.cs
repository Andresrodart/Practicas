namespace forumCliente
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Topico = new System.Windows.Forms.Label();
            this.PanelTopicos = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PanelTopicos);
            this.panel1.Location = new System.Drawing.Point(31, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 390);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estas viendo entradas de:";
            // 
            // Topico
            // 
            this.Topico.AutoSize = true;
            this.Topico.Location = new System.Drawing.Point(168, 13);
            this.Topico.Name = "Topico";
            this.Topico.Size = new System.Drawing.Size(35, 13);
            this.Topico.TabIndex = 2;
            this.Topico.Text = "label2";
            // 
            // PanelTopicos
            // 
            this.PanelTopicos.AutoSize = true;
            this.PanelTopicos.ColumnCount = 1;
            this.PanelTopicos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelTopicos.Location = new System.Drawing.Point(18, 20);
            this.PanelTopicos.Name = "PanelTopicos";
            this.PanelTopicos.RowCount = 1;
            this.PanelTopicos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelTopicos.Size = new System.Drawing.Size(663, 100);
            this.PanelTopicos.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Topico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Topico;
        private System.Windows.Forms.TableLayoutPanel PanelTopicos;
    }
}