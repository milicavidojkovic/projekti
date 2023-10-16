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
    public partial class RevijaForm : Form
    {
        public RevijaForm()
        {
            InitializeComponent();
        }

        private void ModneKucePrikaz_Click(object sender, EventArgs e)
        {
            ModneKuceForm forma = new ModneKuceForm();
            forma.ShowDialog();
        }

        private void ModniKreatoriPrikaz_Click(object sender, EventArgs e)
        {
            ModniKreatoriForm forma = new ModniKreatoriForm();
            forma.ShowDialog();
        }

        private void ModneKucePrikaz_MouseHover(object sender, EventArgs e)
        {
            ModneKucePrikaz.BackColor = Color.Black;
            ModneKucePrikaz.ForeColor = Color.WhiteSmoke;
        }

        private void ModneKucePrikaz_MouseLeave(object sender, EventArgs e)
        {
            ModneKucePrikaz.BackColor = Color.Gainsboro;
            ModneKucePrikaz.ForeColor = Color.Black;
        }

        private void ModniKreatoriPrikaz_MouseHover(object sender, EventArgs e)
        {
            ModniKreatoriPrikaz.BackColor = Color.Black;
            ModniKreatoriPrikaz.ForeColor = Color.WhiteSmoke;
        }

        private void ModniKreatoriPrikaz_MouseLeave(object sender, EventArgs e)
        {
            ModniKreatoriPrikaz.BackColor = Color.Gainsboro;
            ModniKreatoriPrikaz.ForeColor = Color.Black;
        }
    }
}
