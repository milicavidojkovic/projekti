using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class RevijaView
    {
        public int RedniBroj { get; set; }
        public string? Naziv { get; set; }
        public string? Mesto { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? Vreme { get; set; }

        public ModniKreatorView? KreatorOrganizator { get; set; }
        public string? NazivOrganizatora { get; set; }
        public string? PrvaRevija { get; set; }
        public IList<ModniKreatorView>? ListaKreatoraUcesnika { get; set; }

        public KolekcijaView? Kolekcija { get; set; }
        public string? NazivKolekcije { get; set; }

        public RevijaView()
        {
            ListaKreatoraUcesnika = new List<ModniKreatorView>();
        }
        internal RevijaView(Revija? r)
        {
            if (r != null)
            {
                RedniBroj = r.RedniBroj;
                Naziv = r.Naziv;
                Mesto = r.Mesto;
                Datum = r.Datum;
                Vreme = r.Vreme;
                NazivKolekcije = r.Kolekcija?.Naziv;
                NazivOrganizatora = r.KreatorOrganizator?.Ime+" "+r.KreatorOrganizator?.Prezime;
            }
        }

        internal RevijaView(ModniKreator? mk)
        {
            KreatorOrganizator = new ModniKreatorView(mk);
        }

        internal RevijaView(Kolekcija? k)
        {
            Kolekcija = new KolekcijaView(k);
        }
    }
}
