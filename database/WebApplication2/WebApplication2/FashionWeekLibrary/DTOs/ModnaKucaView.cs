using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class ModnaKucaView
    {
        public int KucaId { get; set; }
        public string? ImeOsnivaca { get; set; }
        public string? SedisteKuce { get; set; }
        public string? Naziv { get; set; }

        public IList<ModniKreatorView>? listaKreatora { get; set; }
       public IList<VlasniciMKView>? listaVlasnika { get; set; }

        public ModnaKucaView()
        {
           listaKreatora = new List<ModniKreatorView>();
           listaVlasnika = new List<VlasniciMKView>();
        }
        internal ModnaKucaView(ModnaKuca? mk)
        {
            if (mk != null)
            {
                KucaId = mk.KucaID;
                ImeOsnivaca = mk.ImeOsnivaca;
                SedisteKuce = mk.SedisteKuce;
                Naziv = mk.Naziv;
            }
        }
    }
}
