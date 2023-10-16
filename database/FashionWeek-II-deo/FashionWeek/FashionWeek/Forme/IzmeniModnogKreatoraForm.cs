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
    public partial class IzmeniModnogKreatoraForm : Form
    {
        public ModniKreatorBasic kreator;
        public IzmeniModnogKreatoraForm()
        {
            InitializeComponent();
        }
        public IzmeniModnogKreatoraForm(ModniKreatorBasic mk)
        {
            InitializeComponent();
            this.kreator = mk;
        }

        private void IzmeniModnogKreatora_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE MODNOG KREATORA {kreator.Ime.ToUpper()}";
        }
        public void popuniPodacima()
        {
            jmbgInput.Text = this.kreator.JMBG;
            ImeInput.Text = this.kreator.Ime;
            PrezimeInput.Text = this.kreator.Prezime;
            ZemljaInput.Text = this.kreator.ZemljaPorekla;
            DatumInput.Text = this.kreator.DatumRodjenja.ToString();
            PolInput.Text = this.kreator.Pol;
        }
        private void IzmeniKreatoraFinal_Click(object sender, EventArgs e)
        {
            string poruka = "Izmeni modnog kreatora?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.kreator.JMBG = jmbgInput.Text;
                this.kreator.Ime = ImeInput.Text;
                this.kreator.Prezime = PrezimeInput.Text;
                this.kreator.ZemljaPorekla = ZemljaInput.Text;
                var parsedDate = DateTime.Parse(DatumInput.Text);
                this.kreator.DatumRodjenja = parsedDate;
                this.kreator.Pol = PolInput.Text;

                DTOManager.izmeniKreatora(this.kreator);
                MessageBox.Show("Uspesno azuriranje!");
                this.Close();
            }
        }
    }
}
