namespace FashionWeek.Forme
{
    partial class RevijaForm
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
            this.ModneKucePrikaz = new System.Windows.Forms.Button();
            this.ModniKreatoriPrikaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FashionWeek.Properties.Resources.slika;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 462);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ModneKucePrikaz
            // 
            this.ModneKucePrikaz.BackColor = System.Drawing.SystemColors.Control;
            this.ModneKucePrikaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModneKucePrikaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModneKucePrikaz.Location = new System.Drawing.Point(88, 156);
            this.ModneKucePrikaz.Name = "ModneKucePrikaz";
            this.ModneKucePrikaz.Size = new System.Drawing.Size(333, 55);
            this.ModneKucePrikaz.TabIndex = 2;
            this.ModneKucePrikaz.Text = "MODNE KUCE";
            this.ModneKucePrikaz.UseVisualStyleBackColor = false;
            this.ModneKucePrikaz.Click += new System.EventHandler(this.ModneKucePrikaz_Click);
            this.ModneKucePrikaz.MouseLeave += new System.EventHandler(this.ModneKucePrikaz_MouseLeave);
            this.ModneKucePrikaz.MouseHover += new System.EventHandler(this.ModneKucePrikaz_MouseHover);
            // 
            // ModniKreatoriPrikaz
            // 
            this.ModniKreatoriPrikaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModniKreatoriPrikaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModniKreatoriPrikaz.Location = new System.Drawing.Point(88, 265);
            this.ModniKreatoriPrikaz.Name = "ModniKreatoriPrikaz";
            this.ModniKreatoriPrikaz.Size = new System.Drawing.Size(333, 55);
            this.ModniKreatoriPrikaz.TabIndex = 3;
            this.ModniKreatoriPrikaz.Text = "MODNI KREATORI";
            this.ModniKreatoriPrikaz.UseVisualStyleBackColor = true;
            this.ModniKreatoriPrikaz.Click += new System.EventHandler(this.ModniKreatoriPrikaz_Click);
            this.ModniKreatoriPrikaz.MouseLeave += new System.EventHandler(this.ModniKreatoriPrikaz_MouseLeave);
            this.ModniKreatoriPrikaz.MouseHover += new System.EventHandler(this.ModniKreatoriPrikaz_MouseHover);
            // 
            // RevijaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 450);
            this.Controls.Add(this.ModniKreatoriPrikaz);
            this.Controls.Add(this.ModneKucePrikaz);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RevijaForm";
            this.Text = "RevijaForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ModneKucePrikaz;
        private System.Windows.Forms.Button ModniKreatoriPrikaz;
    }
}