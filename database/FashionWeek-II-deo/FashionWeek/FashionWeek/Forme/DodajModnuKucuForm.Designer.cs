
namespace FashionWeek.Forme
{
    partial class DodajModnuKucuForm
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
            this.NazivKuceInput = new System.Windows.Forms.TextBox();
            this.NazivLabel = new System.Windows.Forms.Label();
            this.ImeOsnivacaLabel = new System.Windows.Forms.Label();
            this.ImeOsnivacaInput = new System.Windows.Forms.TextBox();
            this.SedisteKuceLabel = new System.Windows.Forms.Label();
            this.SedisteKuceInput = new System.Windows.Forms.TextBox();
            this.DodajKucuFinal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NazivKuceInput
            // 
            this.NazivKuceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.NazivKuceInput.Location = new System.Drawing.Point(12, 37);
            this.NazivKuceInput.Name = "NazivKuceInput";
            this.NazivKuceInput.Size = new System.Drawing.Size(151, 35);
            this.NazivKuceInput.TabIndex = 0;
            // 
            // NazivLabel
            // 
            this.NazivLabel.AutoSize = true;
            this.NazivLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NazivLabel.Location = new System.Drawing.Point(12, 9);
            this.NazivLabel.Name = "NazivLabel";
            this.NazivLabel.Size = new System.Drawing.Size(67, 25);
            this.NazivLabel.TabIndex = 1;
            this.NazivLabel.Text = "Naziv:";
            // 
            // ImeOsnivacaLabel
            // 
            this.ImeOsnivacaLabel.AutoSize = true;
            this.ImeOsnivacaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ImeOsnivacaLabel.Location = new System.Drawing.Point(12, 163);
            this.ImeOsnivacaLabel.Name = "ImeOsnivacaLabel";
            this.ImeOsnivacaLabel.Size = new System.Drawing.Size(133, 25);
            this.ImeOsnivacaLabel.TabIndex = 2;
            this.ImeOsnivacaLabel.Text = "Ime osnivaca:";
            // 
            // ImeOsnivacaInput
            // 
            this.ImeOsnivacaInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.ImeOsnivacaInput.Location = new System.Drawing.Point(12, 191);
            this.ImeOsnivacaInput.Name = "ImeOsnivacaInput";
            this.ImeOsnivacaInput.Size = new System.Drawing.Size(151, 35);
            this.ImeOsnivacaInput.TabIndex = 3;
            // 
            // SedisteKuceLabel
            // 
            this.SedisteKuceLabel.AutoSize = true;
            this.SedisteKuceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.SedisteKuceLabel.Location = new System.Drawing.Point(12, 85);
            this.SedisteKuceLabel.Name = "SedisteKuceLabel";
            this.SedisteKuceLabel.Size = new System.Drawing.Size(135, 25);
            this.SedisteKuceLabel.TabIndex = 4;
            this.SedisteKuceLabel.Text = "Sediste Kuce:";
            // 
            // SedisteKuceInput
            // 
            this.SedisteKuceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.SedisteKuceInput.Location = new System.Drawing.Point(12, 113);
            this.SedisteKuceInput.Name = "SedisteKuceInput";
            this.SedisteKuceInput.Size = new System.Drawing.Size(151, 35);
            this.SedisteKuceInput.TabIndex = 5;
            // 
            // DodajKucuFinal
            // 
            this.DodajKucuFinal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DodajKucuFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DodajKucuFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.DodajKucuFinal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DodajKucuFinal.Location = new System.Drawing.Point(213, 191);
            this.DodajKucuFinal.Name = "DodajKucuFinal";
            this.DodajKucuFinal.Size = new System.Drawing.Size(155, 43);
            this.DodajKucuFinal.TabIndex = 6;
            this.DodajKucuFinal.Text = "Dodaj";
            this.DodajKucuFinal.UseVisualStyleBackColor = false;
            this.DodajKucuFinal.Click += new System.EventHandler(this.DodajKucuFinal_Click);
            // 
            // DodajModnuKucuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(399, 266);
            this.Controls.Add(this.DodajKucuFinal);
            this.Controls.Add(this.SedisteKuceInput);
            this.Controls.Add(this.SedisteKuceLabel);
            this.Controls.Add(this.ImeOsnivacaInput);
            this.Controls.Add(this.ImeOsnivacaLabel);
            this.Controls.Add(this.NazivLabel);
            this.Controls.Add(this.NazivKuceInput);
            this.Name = "DodajModnuKucuForm";
            this.Text = "DodajModnuKucuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NazivKuceInput;
        private System.Windows.Forms.Label NazivLabel;
        private System.Windows.Forms.Label ImeOsnivacaLabel;
        private System.Windows.Forms.TextBox ImeOsnivacaInput;
        private System.Windows.Forms.Label SedisteKuceLabel;
        private System.Windows.Forms.TextBox SedisteKuceInput;
        private System.Windows.Forms.Button DodajKucuFinal;
    }
}