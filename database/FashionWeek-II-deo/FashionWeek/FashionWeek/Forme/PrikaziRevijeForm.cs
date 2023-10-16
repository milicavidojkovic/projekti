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
    public partial class PrikaziRevijeForm : Form
    {
        public PrikaziRevijeForm()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {

            listRevije.Items.Clear();
            List<RevijaPregled> revije = DTOManager.vratiSveRevije();

            foreach (RevijaPregled p in revije)
            {
                ListViewItem item = new ListViewItem(new string[] { p.RedniBroj.ToString(), p.Naziv, p.Mesto, p.Datum.ToString() });
                listRevije.Items.Add(item);

            }
            listRevije.Refresh();
        }

        private void PrikaziRevijeForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
