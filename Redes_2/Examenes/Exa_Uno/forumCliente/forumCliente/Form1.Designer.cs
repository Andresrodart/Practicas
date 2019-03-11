namespace forumCliente
{
    partial class Form1
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
            this.perritos = new System.Windows.Forms.Button();
            this.tecno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // perritos
            // 
            this.perritos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perritos.Location = new System.Drawing.Point(196, 49);
            this.perritos.Name = "perritos";
            this.perritos.Size = new System.Drawing.Size(133, 51);
            this.perritos.TabIndex = 0;
            this.perritos.Text = "Perritos";
            this.perritos.UseVisualStyleBackColor = true;
            this.perritos.Click += new System.EventHandler(this.perritos_Click);
            // 
            // tecno
            // 
            this.tecno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tecno.Location = new System.Drawing.Point(196, 125);
            this.tecno.Name = "tecno";
            this.tecno.Size = new System.Drawing.Size(133, 51);
            this.tecno.TabIndex = 1;
            this.tecno.Text = "Tecnologia";
            this.tecno.UseVisualStyleBackColor = true;
            this.tecno.Click += new System.EventHandler(this.tecno_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(552, 221);
            this.Controls.Add(this.tecno);
            this.Controls.Add(this.perritos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button perritos;
        private System.Windows.Forms.Button tecno;
    }
}

