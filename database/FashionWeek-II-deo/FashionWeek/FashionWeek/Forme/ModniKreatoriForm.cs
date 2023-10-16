using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionWeek.Forme;
using System.Windows.Forms;

namespace FashionWeek.Forme
{
    public partial class ModniKreatoriForm : Form
    {
        public ModniKreatoriForm()
        {
            InitializeComponent();
        }
        

        public void popuniPodacima()
        {
            listKreatori.Items.Clear();
            List<ModniKreatorPregled> kreatori = DTOManager.vratiSveKreatore();

            foreach (ModniKreatorPregled x in kreatori)
            {
                ListViewItem item = new ListViewItem(new string[] {x.Id.ToString(),x.Ime,x.Prezime,x.ZemljaPorekla,x.Pol});
                listKreatori.Items.Add(item);
            }
            listKreatori.Refresh();
        }

        private void ModniKreatoriForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void DodajKreatora_Click(object sender, EventArgs e)
        {
            DodajModnogKreatora form = new DodajModnogKreatora();
            form.ShowDialog();
            this.popuniPodacima();
        }

        private void IzmeniKreatora_Click(object sender, EventArgs e)
        {
            if (listKreatori.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreatora kog zelite da izmenite");
                return;
            }
            int idKreatora = Int32.Parse(listKreatori.SelectedItems[0].SubItems[0].Text);
            ModniKreatorBasic mk = DTOManager.vratiKreatora(idKreatora);

            IzmeniModnogKreatoraForm form = new IzmeniModnogKreatoraForm(mk);
            form.ShowDialog();
            this.popuniPodacima();
        }


        private void ObrisiKreatora_Click(object sender, EventArgs e)
        {
            if (listKreatori.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreatora kog zelite da obrisete");
                return;
            }
            int idKreatora = Int32.Parse(listKreatori.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog kreatora?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKreatora(idKreatora);
                MessageBox.Show("Brisanje kreatora je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void PrikaziRevije_Click(object sender, EventArgs e)
        {
            PrikaziRevijeForm form = new PrikaziRevijeForm();
            form.ShowDialog();
            this.popuniPodacima();
        }
    }
}
