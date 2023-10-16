using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class ModnaKuca
    {
        public virtual int KucaID { get; protected set; }
        public virtual string ImeOsnivaca { get; set; }
        public virtual string SedisteKuce { get; set; }
        public virtual string Naziv { get; set; }

        public virtual IList<ModniKreator> listaKreatora { get; set; }
        public virtual IList<VlasniciMK> listaVlasnika { get; set; }

        public virtual IList<Kolekcija> listaKolekcija { get; set; }
        public ModnaKuca()
        {
            listaKreatora = new List<ModniKreator>();
            listaVlasnika = new List<VlasniciMK>();
            listaKolekcija = new List<Kolekcija>();
        }
    }
}
