
namespace FashionWeek
{
    partial class PocetnaStranica
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
            this.label2 = new System.Windows.Forms.Label();
            this.Ulaz = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(26, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "FASHION WEEK";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Ulaz
            // 
            this.Ulaz.BackColor = System.Drawing.Color.Gainsboro;
            this.Ulaz.FlatAppearance.BorderSize = 0;
            this.Ulaz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Ulaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ulaz.Location = new System.Drawing.Point(88, 272);
            this.Ulaz.Name = "Ulaz";
            this.Ulaz.Size = new System.Drawing.Size(243, 55);
            this.Ulaz.TabIndex = 3;
            this.Ulaz.Text = "ENTER";
            this.Ulaz.UseVisualStyleBackColor = false;
            this.Ulaz.Click += new System.EventHandler(this.RevijePocetno_Click);
            this.Ulaz.MouseLeave += new System.EventHandler(this.Ulaz_MouseLeave);
            this.Ulaz.MouseHover += new System.EventHandler(this.Ulaz_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FashionWeek.Properties.Resources.slika;
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 462);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PocetnaStranica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 465);
            this.Controls.Add(this.Ulaz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PocetnaStranica";
            this.Text = "PocetnaStranica";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ulaz;
    }
}