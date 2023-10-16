using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class Maneken
    {
        internal protected virtual string? JMBG { get;  set; }
        internal protected virtual string? Ime { get; set; }
        internal protected virtual string? Prezime { get; set; }
        internal protected virtual DateTime? DatumRodjenja { get; set; }
        internal protected virtual string? Pol { get; set; }
        internal protected virtual int Visina { get; set; }
        internal protected virtual int TezinaKG { get; set; }
        internal protected virtual string? BojaOciju { get; set; }
        internal protected virtual string? BojaKose { get; set; }
        internal protected virtual string? Zanimanje { get; set; }
        internal protected virtual string? KonfekcijskiBroj { get; set; }

        internal protected virtual string? Tip { get; set; }

        internal protected virtual Agencija? Agencija { get; set; }

        internal protected virtual IList<Revija>? ListaRevija { get; set; }
        internal protected virtual IList<NaslovneStrane>? listaNaslovnih { get; set; }

        internal Maneken()
        {
            ListaRevija = new List<Revija>();
            listaNaslovnih = new List<NaslovneStrane>();
        }
    }
}
