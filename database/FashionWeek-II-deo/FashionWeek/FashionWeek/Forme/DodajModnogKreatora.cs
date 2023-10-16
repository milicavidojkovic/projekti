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
    public partial class DodajModnogKreatora : Form
    {
        ModniKreatorBasic kreator;
        public DodajModnogKreatora()
        {
            InitializeComponent();
            kreator = new ModniKreatorBasic(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DodajKreatoraFinal_Click(object sender, EventArgs e)
        {
            string poruka = "Dodaj novog modnog kreatora?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if(result == DialogResult.OK)
            {
                this.kreator.JMBG = jmbgInput.Text;
                this.kreator.Ime = ImeInput.Text;
                this.kreator.Prezime = PrezimeInput.Text;
                this.kreator.ZemljaPorekla = ZemljaInput.Text;
                var parsedDate = DateTime.Parse(DatumInput.Text);
                this.kreator.DatumRodjenja = parsedDate;
                this.kreator.Pol=PolInput.Text;

                DTOManager.dodajKreatora(this.kreator);
                MessageBox.Show("Dodat je novi kreator!");
                this.Close();
            }
        }
    }
}
