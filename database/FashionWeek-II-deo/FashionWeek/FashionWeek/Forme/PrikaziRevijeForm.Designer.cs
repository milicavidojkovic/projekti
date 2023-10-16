namespace FashionWeek.Forme
{
    partial class PrikaziRevijeForm
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
            this.listRevije = new System.Windows.Forms.ListView();
            this.rBr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.naziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mesto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listRevije
            // 
            this.listRevije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rBr,
            this.naziv,
            this.mesto,
            this.datum});
            this.listRevije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listRevije.GridLines = true;
            this.listRevije.HideSelection = false;
            this.listRevije.Location = new System.Drawing.Point(0, -1);
            this.listRevije.Name = "listRevije";
            this.listRevije.Size = new System.Drawing.Size(376, 374);
            this.listRevije.TabIndex = 0;
            this.listRevije.UseCompatibleStateImageBehavior = false;
            this.listRevije.View = System.Windows.Forms.View.Details;
            // 
            // rBr
            // 
            this.rBr.Text = "Redni Broj";
            this.rBr.Width = 100;
            // 
            // naziv
            // 
            this.naziv.Text = "Naziv";
            this.naziv.Width = 80;
            // 
            // mesto
            // 
            this.mesto.Text = "Mesto";
            this.mesto.Width = 90;
            // 
            // datum
            // 
            this.datum.Text = "Datum";
            this.datum.Width = 100;
            // 
            // PrikaziRevijeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 371);
            this.Controls.Add(this.listRevije);
            this.Name = "PrikaziRevijeForm";
            this.Text = "PrikaziRevijeForm";
            this.Load += new System.EventHandler(this.PrikaziRevijeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listRevije;
        private System.Windows.Forms.ColumnHeader rBr;
        private System.Windows.Forms.ColumnHeader naziv;
        private System.Windows.Forms.ColumnHeader mesto;
        private System.Windows.Forms.ColumnHeader datum;
    }
}