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
    public partial class IzmeniModnuKucuForm : Form
    {
        public ModnaKucaBasic kuca;
        public IzmeniModnuKucuForm()
        {
            InitializeComponent();
        }

        public IzmeniModnuKucuForm(ModnaKucaBasic mk)
        {
            InitializeComponent();
            this.kuca = mk;
        }

        private void IzmeniModnuKucu_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE MODNE KUCE {kuca.Naziv.ToUpper()}";
        }
        public void popuniPodacima()
        {
            NazivKuceUpdate.Text = this.kuca.Naziv;
            SedisteKuceUpdate.Text = this.kuca.SedisteKuce;
            ImeOsnivacaUpdate.Text = this.kuca.ImeOsnivaca;
        }

        private void IzmeniKucuFinal_Click(object sender, EventArgs e)
        {
            string poruka = "Izmeni modnu kucu?";
            string title = "Pitanje";

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if(result == DialogResult.OK)
            {
                this.kuca.Naziv = NazivKuceUpdate.Text;
                this.kuca.SedisteKuce = SedisteKuceUpdate.Text;
                this.kuca.ImeOsnivaca = ImeOsnivacaUpdate.Text;
            }
            DTOManager.izmeniKucu(this.kuca);
            MessageBox.Show("Uspesno azuriranje!");
            this.Close();
        }
    }
}
