using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class Agencija
    {
        internal protected virtual int Pib { get;  set; }
        internal protected virtual string? Naziv { get; set; }
        internal protected virtual string? Sediste { get; set; }
        internal protected virtual DateTime? DatumOsnivanja { get; set; }
        internal protected virtual char? Tip { get; set; }

        internal protected virtual IList<Maneken>? listaManekena { get; set; }
        internal protected virtual IList<Zemlja>? listaZemalja { get; set; }


        internal Agencija()
        {
            listaManekena = new List<Maneken>();
            listaZemalja = new List<Zemlja>();



        }
    }
}
