using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class Revija
    {
        public virtual int RedniBroj { get;  set; }
        public virtual string Naziv { get; set; }
        public virtual string Mesto { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual DateTime Vreme { get; set; }

        public virtual ModniKreator KreatorOrganizator { get; set; }
        public virtual string PrvaRevija { get; set; }
        public virtual IList<ModniKreator> ListaKreatoraUcesnika { get; set; }
        public virtual IList<Maneken> ListaManekena { get; set; }




        public virtual Kolekcija Kolekcija { get; set; } 
        public Revija()
        {
          
            ListaKreatoraUcesnika = new List<ModniKreator>();
            ListaManekena = new List<Maneken>();
        }
    }
}
