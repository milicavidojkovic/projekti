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
        ModnaKucaBasic mk;
        public ModneKuceForm()
        {
            InitializeComponent();
        }

        public ModneKuceForm(ModnaKucaBasic m)
        {
            InitializeComponent();
            mk = m;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DodajModnuKucuForm forma = new DodajModnuKucuForm(mk);
            forma.ShowDialog();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
           
        }
    }
}
