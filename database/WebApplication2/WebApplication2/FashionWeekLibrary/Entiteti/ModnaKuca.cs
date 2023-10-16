using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class ModnaKuca
    {
        internal protected virtual int KucaID { get; protected set; }
        internal protected virtual string? ImeOsnivaca { get; set; }
        internal protected virtual string? SedisteKuce { get; set; }
        internal protected virtual string? Naziv { get; set; }

        internal protected virtual IList<ModniKreator>? listaKreatora { get; set; }
        internal protected virtual IList<VlasniciMK>? listaVlasnika { get; set; }

        internal protected virtual IList<Kolekcija>? listaKolekcija { get; set; }
        internal ModnaKuca()
        {
            listaKreatora = new List<ModniKreator>();
            listaVlasnika = new List<VlasniciMK>();
            listaKolekcija = new List<Kolekcija>();
        }
    }
}
