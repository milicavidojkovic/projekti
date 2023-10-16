using FashionWeek.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class KolekcijaView
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public string? Sezona { get; set; }
        public string? NazivModneKuce { get; set; }
        public string? NazivRevije { get; set; }

        public ModnaKucaView? ModnaKuca{ get; set; }
        public RevijaView? Revija{ get; set; }


        public KolekcijaView() { }
        internal KolekcijaView(Kolekcija? k)
        {
            if (k != null)
            {
                Id = k.Id;
                Naziv = k.Naziv;
                Opis = k.Opis;
                Sezona = k.Sezona;
                NazivModneKuce = k.ModnaKuca?.Naziv;
                NazivRevije = k.Revija?.Naziv;
            }
        }

        internal KolekcijaView(ModnaKuca? mk, Revija? r)
        {
            ModnaKuca = new ModnaKucaView(mk);
            Revija = new RevijaView(r);
        }
    }
}
