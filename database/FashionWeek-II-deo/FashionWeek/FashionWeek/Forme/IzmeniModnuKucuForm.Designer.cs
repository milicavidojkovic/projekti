namespace FashionWeek.Forme
{
    partial class IzmeniModnuKucuForm
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
            this.NazivLabel = new System.Windows.Forms.Label();
            this.NazivKuceUpdate = new System.Windows.Forms.TextBox();
            this.ImeOsnivacaLabel = new System.Windows.Forms.Label();
            this.ImeOsnivacaUpdate = new System.Windows.Forms.TextBox();
            this.SedisteKuceLabel = new System.Windows.Forms.Label();
            this.SedisteKuceUpdate = new System.Windows.Forms.TextBox();
            this.IzmeniKucuFinal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NazivLabel
            // 
            this.NazivLabel.AutoSize = true;
            this.NazivLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NazivLabel.Location = new System.Drawing.Point(12, 9);
            this.NazivLabel.Name = "NazivLabel";
            this.NazivLabel.Size = new System.Drawing.Size(67, 25);
            this.NazivLabel.TabIndex = 2;
            this.NazivLabel.Text = "Naziv:";
            // 
            // NazivKuceUpdate
            // 
            this.NazivKuceUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.NazivKuceUpdate.Location = new System.Drawing.Point(17, 37);
            this.NazivKuceUpdate.Name = "NazivKuceUpdate";
            this.NazivKuceUpdate.Size = new System.Drawing.Size(151, 35);
            this.NazivKuceUpdate.TabIndex = 3;
            // 
            // ImeOsnivacaLabel
            // 
            this.ImeOsnivacaLabel.AutoSize = true;
            this.ImeOsnivacaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ImeOsnivacaLabel.Location = new System.Drawing.Point(12, 161);
            this.ImeOsnivacaLabel.Name = "ImeOsnivacaLabel";
            this.ImeOsnivacaLabel.Size = new System.Drawing.Size(133, 25);
            this.ImeOsnivacaLabel.TabIndex = 4;
            this.ImeOsnivacaLabel.Text = "Ime osnivaca:";
            // 
            // ImeOsnivacaUpdate
            // 
            this.ImeOsnivacaUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.ImeOsnivacaUpdate.Location = new System.Drawing.Point(17, 189);
            this.ImeOsnivacaUpdate.Name = "ImeOsnivacaUpdate";
            this.ImeOsnivacaUpdate.Size = new System.Drawing.Size(151, 35);
            this.ImeOsnivacaUpdate.TabIndex = 5;
            // 
            // SedisteKuceLabel
            // 
            this.SedisteKuceLabel.AutoSize = true;
            this.SedisteKuceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.SedisteKuceLabel.Location = new System.Drawing.Point(12, 86);
            this.SedisteKuceLabel.Name = "SedisteKuceLabel";
            this.SedisteKuceLabel.Size = new System.Drawing.Size(135, 25);
            this.SedisteKuceLabel.TabIndex = 6;
            this.SedisteKuceLabel.Text = "Sediste Kuce:";
            // 
            // SedisteKuceUpdate
            // 
            this.SedisteKuceUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.SedisteKuceUpdate.Location = new System.Drawing.Point(17, 114);
            this.SedisteKuceUpdate.Name = "SedisteKuceUpdate";
            this.SedisteKuceUpdate.Size = new System.Drawing.Size(151, 35);
            this.SedisteKuceUpdate.TabIndex = 7;
            // 
            // IzmeniKucuFinal
            // 
            this.IzmeniKucuFinal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.IzmeniKucuFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IzmeniKucuFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.IzmeniKucuFinal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IzmeniKucuFinal.Location = new System.Drawing.Point(209, 189);
            this.IzmeniKucuFinal.Name = "IzmeniKucuFinal";
            this.IzmeniKucuFinal.Size = new System.Drawing.Size(156, 45);
            this.IzmeniKucuFinal.TabIndex = 8;
            this.IzmeniKucuFinal.Text = "Azuriraj";
            this.IzmeniKucuFinal.UseVisualStyleBackColor = false;
            this.IzmeniKucuFinal.Click += new System.EventHandler(this.IzmeniKucuFinal_Click);
            // 
            // IzmeniModnuKucuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(386, 246);
            this.Controls.Add(this.IzmeniKucuFinal);
            this.Controls.Add(this.SedisteKuceUpdate);
            this.Controls.Add(this.SedisteKuceLabel);
            this.Controls.Add(this.ImeOsnivacaUpdate);
            this.Controls.Add(this.ImeOsnivacaLabel);
            this.Controls.Add(this.NazivKuceUpdate);
            this.Controls.Add(this.NazivLabel);
            this.Name = "IzmeniModnuKucuForm";
            this.Text = "IzmeniModnuKucuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NazivLabel;
        private System.Windows.Forms.TextBox NazivKuceUpdate;
        private System.Windows.Forms.Label ImeOsnivacaLabel;
        private System.Windows.Forms.TextBox ImeOsnivacaUpdate;
        private System.Windows.Forms.Label SedisteKuceLabel;
        private System.Windows.Forms.TextBox SedisteKuceUpdate;
        private System.Windows.Forms.Button IzmeniKucuFinal;
    }
}