using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class ModniKreatorView
    {
        public int Id { get; set; }
        public string? JMBG { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? ZemljaPorekla { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? Pol { get; set; }

        public string? NazivModneKuce { get; set; }
        public ModnaKucaView? ModnaKuca { get; set; }

        public IList<RevijaView>? ListaOrganizovanihRevija { get; set; }

        public IList<RevijaView>? ListaUstvovanihRevija { get; set; }

        public IList<ModniKreatorView>? ListaKreatoraKojiSuZvali { get; set; }
        public IList<ModniKreatorView>? ListaPozvanihKreatora { get; set; }


        public ModniKreatorView() 
        {
            ListaOrganizovanihRevija = new List<RevijaView>();
            ListaUstvovanihRevija = new List<RevijaView>();

            ListaKreatoraKojiSuZvali = new List<ModniKreatorView>();
            ListaPozvanihKreatora = new List<ModniKreatorView>();

        }
        internal ModniKreatorView(ModniKreator? mk)
        {
            if (mk != null)
            {
                Id = mk.Id;
                JMBG = mk.JMBG;
                Ime = mk.Ime;
                Prezime = mk.Prezime;
                ZemljaPorekla = mk.ZemljaPorekla;
                DatumRodjenja = mk.DatumRodjenja;
                Pol = mk.Pol;
                NazivModneKuce = mk.modnaKuca?.Naziv;
            }
        }
        internal ModniKreatorView(ModnaKuca? mkuca)
        {
            ModnaKuca = new ModnaKucaView(mkuca);
        }
        }
}
