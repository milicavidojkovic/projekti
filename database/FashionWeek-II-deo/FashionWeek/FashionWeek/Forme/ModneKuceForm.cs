using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FashionWeek.Forme;
namespace FashionWeek.Forme
{
    public partial class ModneKuceForm : Form
    {
  
        public ModneKuceForm()
        {
            InitializeComponent();
        }

        private void ModneKuceForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {

            listaProizvoda.Items.Clear();
            List<ModnaKucaPregled> proizvodi = DTOManager.vratiSveProizvode();

            foreach (ModnaKucaPregled p in proizvodi)
            {
                ListViewItem item = new ListViewItem(new string[] {p.KucaId.ToString(), p.Naziv, p.ImeOsnivaca, p.SedisteKuce});
                listaProizvoda.Items.Add(item);

            }
            listaProizvoda.Refresh();
        }

        private void DodajKucu_Click(object sender, EventArgs e)
        {
            DodajModnuKucuForm forma1 = new DodajModnuKucuForm();
            forma1.ShowDialog();
            this.popuniPodacima();
        }

        private void IzmeniKucu_Click(object sender, EventArgs e)
        {
            if(listaProizvoda.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kucu koju zelite da izmenite");
                return;
            }
            int idKuce = Int32.Parse(listaProizvoda.SelectedItems[0].SubItems[0].Text);
            ModnaKucaBasic mk = DTOManager.vratiKucu(idKuce);

            IzmeniModnuKucuForm formIzmeni = new IzmeniModnuKucuForm(mk);
            formIzmeni.ShowDialog();

            this.popuniPodacima();
        }

        private void ObrisiKucu_Click(object sender, EventArgs e)
        {
            if (listaProizvoda.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite modnu kucu koju zelite da obrisete");
                return;
            }
            int idKuce = Int32.Parse(listaProizvoda.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu modnu kucu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKucu(idKuce);
                MessageBox.Show("Brisanje modne kuce je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void PrikaziRevijeKreatora_Click(object sender, EventArgs e)
        {
            PrikaziRevijeForm form = new PrikaziRevijeForm();
            form.ShowDialog();
            this.popuniPodacima();
        }
    }
}
