using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class Revija
    {
        internal protected virtual int RedniBroj { get;  set; }
        internal protected virtual string? Naziv { get; set; }
        internal protected virtual string? Mesto { get; set; }
        internal protected virtual DateTime? Datum { get; set; }
        internal protected virtual DateTime? Vreme { get; set; }

        internal protected virtual ModniKreator? KreatorOrganizator { get; set; }
        internal protected virtual string? PrvaRevija { get; set; }
        internal protected virtual IList<ModniKreator>? ListaKreatoraUcesnika { get; set; }
        internal protected virtual IList<Maneken>? ListaManekena { get; set; }




        internal protected virtual Kolekcija? Kolekcija { get; set; } 
        internal Revija()
        {
          
            ListaKreatoraUcesnika = new List<ModniKreator>();
            ListaManekena = new List<Maneken>();
        }
    }
}
