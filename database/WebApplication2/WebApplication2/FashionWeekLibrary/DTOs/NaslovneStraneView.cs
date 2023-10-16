using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class NaslovneStraneView
    {
        public int Id { get; set; }
        public string? NaslovneStrana { get; set; }

        public ManekenView? Maneken { get; set; }
        public string? ImeManekena { get; set; }

        public NaslovneStraneView() { }
        internal NaslovneStraneView(NaslovneStrane? ns)
        {
            if (ns != null)
            {
                Id = ns.Id;
                NaslovneStrana = ns.NaslovneStrana;
                ImeManekena = ns.Maneken?.Ime + " " + ns.Maneken?.Prezime;
            }

        }

        internal NaslovneStraneView(Maneken? man)
        {
            Maneken = new ManekenView(man);
        }

    }
}
