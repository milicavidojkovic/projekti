using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FashionWeek.Forme
{
    public partial class DodajModnuKucuForm : Form
    {
        ModnaKucaBasic kuca;
        public DodajModnuKucuForm()
        {
            InitializeComponent();
            kuca = new ModnaKucaBasic();
        }

        private void DodajKucuFinal_Click(object sender, EventArgs e)
        {
            string poruka = "Dodaj novu modnu kucu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka,title, buttons);

            if(result == DialogResult.OK)
            {
                this.kuca.Naziv = NazivKuceInput.Text;
                this.kuca.SedisteKuce = SedisteKuceInput.Text;
                this.kuca.ImeOsnivaca = ImeOsnivacaInput.Text;

                DTOManager.dodajKucu(this.kuca);
                MessageBox.Show("Dodata je nova modna kuca!");
                this.Close();
            }
        }
    }
    
}
    