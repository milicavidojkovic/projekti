using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class AgencijaView
    {
        public int Pib { get; set; }
        public string? Naziv { get; set; }
        public string? Sediste { get; set; }
        public DateTime? DatumOsnivanja { get; set; }
        public char? Tip { get; set; }

        public AgencijaView() { }

        internal AgencijaView(Agencija? a)
        {
            if (a != null)
            {
                Pib = a.Pib;
                Naziv = a.Naziv;
                Sediste = a.Sediste;
                DatumOsnivanja = a.DatumOsnivanja;
                Tip = a.Tip;
            }
        }
    }
}
