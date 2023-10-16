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
namespace FashionWeek
{
    public partial class PocetnaStranica : Form
    {
        public PocetnaStranica()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModneKuceForm forma = new ModneKuceForm();
            forma.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModniKreatoriForm forma = new ModniKreatoriForm();
            forma.ShowDialog();
        }
    }
}
