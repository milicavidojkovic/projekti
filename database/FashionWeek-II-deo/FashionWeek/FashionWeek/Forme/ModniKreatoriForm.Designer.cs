
namespace FashionWeek.Forme
{
    partial class ModniKreatoriForm
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
            this.listKreatori = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zemlja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrikaziRevije = new System.Windows.Forms.Button();
            this.ObrisiKreatora = new System.Windows.Forms.Button();
            this.IzmeniKreatora = new System.Windows.Forms.Button();
            this.DodajKreatora = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listKreatori
            // 
            this.listKreatori.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Ime,
            this.Prezime,
            this.Zemlja,
            this.Pol});
            this.listKreatori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listKreatori.FullRowSelect = true;
            this.listKreatori.GridLines = true;
            this.listKreatori.HideSelection = false;
            this.listKreatori.Location = new System.Drawing.Point(11, 22);
            this.listKreatori.Margin = new System.Windows.Forms.Padding(2);
            this.listKreatori.Name = "listKreatori";
            this.listKreatori.Size = new System.Drawing.Size(359, 322);
            this.listKreatori.TabIndex = 0;
            this.listKreatori.UseCompatibleStateImageBehavior = false;
            this.listKreatori.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Ime
            // 
            this.Ime.Text = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.Text = "Prezime";
            this.Prezime.Width = 80;
            // 
            // Zemlja
            // 
            this.Zemlja.Text = "Zemlja Rodjenja";
            this.Zemlja.Width = 120;
            // 
            // Pol
            // 
            this.Pol.Text = "Pol";
            this.Pol.Width = 35;
            // 
            // PrikaziRevije
            // 
            this.PrikaziRevije.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PrikaziRevije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrikaziRevije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.PrikaziRevije.Location = new System.Drawing.Point(393, 293);
            this.PrikaziRevije.Margin = new System.Windows.Forms.Padding(2);
            this.PrikaziRevije.Name = "PrikaziRevije";
            this.PrikaziRevije.Size = new System.Drawing.Size(185, 51);
            this.PrikaziRevije.TabIndex = 1;
            this.PrikaziRevije.Text = "Revije";
            this.PrikaziRevije.UseVisualStyleBackColor = false;
            this.PrikaziRevije.Click += new System.EventHandler(this.PrikaziRevije_Click);
            // 
            // ObrisiKreatora
            // 
            this.ObrisiKreatora.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ObrisiKreatora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ObrisiKreatora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ObrisiKreatora.Location = new System.Drawing.Point(393, 156);
            this.ObrisiKreatora.Margin = new System.Windows.Forms.Padding(2);
            this.ObrisiKreatora.Name = "ObrisiKreatora";
            this.ObrisiKreatora.Size = new System.Drawing.Size(185, 51);
            this.ObrisiKreatora.TabIndex = 2;
            this.ObrisiKreatora.Text = "Obriši";
            this.ObrisiKreatora.UseVisualStyleBackColor = false;
            this.ObrisiKreatora.Click += new System.EventHandler(this.ObrisiKreatora_Click);
            // 
            // IzmeniKreatora
            // 
            this.IzmeniKreatora.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.IzmeniKreatora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IzmeniKreatora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.IzmeniKreatora.Location = new System.Drawing.Point(393, 89);
            this.IzmeniKreatora.Name = "IzmeniKreatora";
            this.IzmeniKreatora.Size = new System.Drawing.Size(185, 51);
            this.IzmeniKreatora.TabIndex = 3;
            this.IzmeniKreatora.Text = "Izmeni";
            this.IzmeniKreatora.UseVisualStyleBackColor = false;
            this.IzmeniKreatora.Click += new System.EventHandler(this.IzmeniKreatora_Click);
            // 
            // DodajKreatora
            // 
            this.DodajKreatora.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DodajKreatora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DodajKreatora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DodajKreatora.Location = new System.Drawing.Point(393, 22);
            this.DodajKreatora.Name = "DodajKreatora";
            this.DodajKreatora.Size = new System.Drawing.Size(185, 51);
            this.DodajKreatora.TabIndex = 4;
            this.DodajKreatora.Text = "Dodaj";
            this.DodajKreatora.UseVisualStyleBackColor = false;
            this.DodajKreatora.Click += new System.EventHandler(this.DodajKreatora_Click);
            // 
            // ModniKreatoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.DodajKreatora);
            this.Controls.Add(this.IzmeniKreatora);
            this.Controls.Add(this.ObrisiKreatora);
            this.Controls.Add(this.PrikaziRevije);
            this.Controls.Add(this.listKreatori);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModniKreatoriForm";
            this.Text = "ModniKreatoriForm";
            this.Load += new System.EventHandler(this.ModniKreatoriForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listKreatori;
        private System.Windows.Forms.Button PrikaziRevije;
        private System.Windows.Forms.Button ObrisiKreatora;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Ime;
        private System.Windows.Forms.ColumnHeader Prezime;
        private System.Windows.Forms.ColumnHeader Zemlja;
        private System.Windows.Forms.ColumnHeader Pol;
        private System.Windows.Forms.Button IzmeniKreatora;
        private System.Windows.Forms.Button DodajKreatora;
    }
}