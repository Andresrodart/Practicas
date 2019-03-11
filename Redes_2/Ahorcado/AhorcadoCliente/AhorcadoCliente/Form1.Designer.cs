namespace AhorcadoCliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ez = new System.Windows.Forms.Button();
            this.med = new System.Windows.Forms.Button();
            this.hrd = new System.Windows.Forms.Button();
            this.wrd = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ch = new System.Windows.Forms.TextBox();
            this.snd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ez
            // 
            this.ez.Location = new System.Drawing.Point(43, 68);
            this.ez.Name = "ez";
            this.ez.Size = new System.Drawing.Size(75, 23);
            this.ez.TabIndex = 0;
            this.ez.Text = "Fácil";
            this.ez.UseVisualStyleBackColor = true;
            this.ez.Click += new System.EventHandler(this.ez_Click);
            // 
            // med
            // 
            this.med.Location = new System.Drawing.Point(195, 68);
            this.med.Name = "med";
            this.med.Size = new System.Drawing.Size(75, 23);
            this.med.TabIndex = 1;
            this.med.Text = "Normal";
            this.med.UseVisualStyleBackColor = true;
            this.med.Click += new System.EventHandler(this.button2_Click);
            // 
            // hrd
            // 
            this.hrd.Location = new System.Drawing.Point(330, 68);
            this.hrd.Name = "hrd";
            this.hrd.Size = new System.Drawing.Size(75, 23);
            this.hrd.TabIndex = 2;
            this.hrd.Text = "Difícil";
            this.hrd.UseVisualStyleBackColor = true;
            this.hrd.Click += new System.EventHandler(this.hrd_Click);
            // 
            // wrd
            // 
            this.wrd.AutoSize = true;
            this.wrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrd.Location = new System.Drawing.Point(33, 154);
            this.wrd.Name = "wrd";
            this.wrd.Size = new System.Drawing.Size(141, 55);
            this.wrd.TabIndex = 3;
            this.wrd.Text = "_ _ _ ";
            this.wrd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(610, 357);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(13, 13);
            this.state.TabIndex = 4;
            this.state.Text = "_";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(34, 253);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // ch
            // 
            this.ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch.Location = new System.Drawing.Point(184, 351);
            this.ch.MaxLength = 1;
            this.ch.Name = "ch";
            this.ch.Size = new System.Drawing.Size(100, 29);
            this.ch.TabIndex = 6;
            // 
            // snd
            // 
            this.snd.Location = new System.Drawing.Point(199, 409);
            this.snd.Name = "snd";
            this.snd.Size = new System.Drawing.Size(71, 29);
            this.snd.TabIndex = 7;
            this.snd.Text = "Enviar";
            this.snd.UseVisualStyleBackColor = true;
            this.snd.Click += new System.EventHandler(this.snd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.snd);
            this.Controls.Add(this.ch);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.state);
            this.Controls.Add(this.wrd);
            this.Controls.Add(this.hrd);
            this.Controls.Add(this.med);
            this.Controls.Add(this.ez);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ez;
        private System.Windows.Forms.Button med;
        private System.Windows.Forms.Button hrd;
        private System.Windows.Forms.Label wrd;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox ch;
        private System.Windows.Forms.Button snd;
    }
}

