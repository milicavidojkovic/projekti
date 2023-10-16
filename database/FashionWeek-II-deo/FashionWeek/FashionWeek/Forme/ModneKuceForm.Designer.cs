
namespace FashionWeek.Forme
{
    partial class ModneKuceForm
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
            this.DodajKucu = new System.Windows.Forms.Button();
            this.IzmeniKucu = new System.Windows.Forms.Button();
            this.ObrisiKucu = new System.Windows.Forms.Button();
            this.listaProizvoda = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrikaziRevijeKreatora = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DodajKucu
            // 
            this.DodajKucu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DodajKucu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DodajKucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DodajKucu.Location = new System.Drawing.Point(393, 22);
            this.DodajKucu.Margin = new System.Windows.Forms.Padding(0);
            this.DodajKucu.Name = "DodajKucu";
            this.DodajKucu.Size = new System.Drawing.Size(185, 51);
            this.DodajKucu.TabIndex = 1;
            this.DodajKucu.Text = "Dodaj";
            this.DodajKucu.UseVisualStyleBackColor = false;
            this.DodajKucu.Click += new System.EventHandler(this.DodajKucu_Click);
            // 
            // IzmeniKucu
            // 
            this.IzmeniKucu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.IzmeniKucu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IzmeniKucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.IzmeniKucu.Location = new System.Drawing.Point(393, 89);
            this.IzmeniKucu.Margin = new System.Windows.Forms.Padding(2);
            this.IzmeniKucu.Name = "IzmeniKucu";
            this.IzmeniKucu.Size = new System.Drawing.Size(185, 51);
            this.IzmeniKucu.TabIndex = 2;
            this.IzmeniKucu.Text = "Izmeni";
            this.IzmeniKucu.UseVisualStyleBackColor = false;
            this.IzmeniKucu.Click += new System.EventHandler(this.IzmeniKucu_Click);
            // 
            // ObrisiKucu
            // 
            this.ObrisiKucu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ObrisiKucu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ObrisiKucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ObrisiKucu.Location = new System.Drawing.Point(393, 156);
            this.ObrisiKucu.Margin = new System.Windows.Forms.Padding(2);
            this.ObrisiKucu.Name = "ObrisiKucu";
            this.ObrisiKucu.Size = new System.Drawing.Size(185, 51);
            this.ObrisiKucu.TabIndex = 3;
            this.ObrisiKucu.Text = "Obriši";
            this.ObrisiKucu.UseVisualStyleBackColor = false;
            this.ObrisiKucu.Click += new System.EventHandler(this.ObrisiKucu_Click);
            // 
            // listaProizvoda
            // 
            this.listaProizvoda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listaProizvoda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.listaProizvoda.FullRowSelect = true;
            this.listaProizvoda.GridLines = true;
            this.listaProizvoda.HideSelection = false;
            this.listaProizvoda.Location = new System.Drawing.Point(11, 21);
            this.listaProizvoda.Margin = new System.Windows.Forms.Padding(2);
            this.listaProizvoda.Name = "listaProizvoda";
            this.listaProizvoda.Size = new System.Drawing.Size(359, 322);
            this.listaProizvoda.TabIndex = 4;
            this.listaProizvoda.UseCompatibleStateImageBehavior = false;
            this.listaProizvoda.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Naziv";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sediste";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ime osnivača";
            this.columnHeader3.Width = 120;
            // 
            // PrikaziRevijeKreatora
            // 
            this.PrikaziRevijeKreatora.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PrikaziRevijeKreatora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrikaziRevijeKreatora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.PrikaziRevijeKreatora.Location = new System.Drawing.Point(393, 293);
            this.PrikaziRevijeKreatora.Name = "PrikaziRevijeKreatora";
            this.PrikaziRevijeKreatora.Size = new System.Drawing.Size(185, 51);
            this.PrikaziRevijeKreatora.TabIndex = 5;
            this.PrikaziRevijeKreatora.Text = "Revije";
            this.PrikaziRevijeKreatora.UseVisualStyleBackColor = false;
            this.PrikaziRevijeKreatora.Click += new System.EventHandler(this.PrikaziRevijeKreatora_Click);
            // 
            // ModneKuceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.PrikaziRevijeKreatora);
            this.Controls.Add(this.listaProizvoda);
            this.Controls.Add(this.ObrisiKucu);
            this.Controls.Add(this.IzmeniKucu);
            this.Controls.Add(this.DodajKucu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModneKuceForm";
            this.Text = "ModneKuceForm";
            this.Load += new System.EventHandler(this.ModneKuceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DodajKucu;
        private System.Windows.Forms.Button IzmeniKucu;
        private System.Windows.Forms.Button ObrisiKucu;
        private System.Windows.Forms.ListView listaProizvoda;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Button PrikaziRevijeKreatora;
    }
}