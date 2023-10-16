using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class ManekenView
    {
        public string? JMBG { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? Pol { get; set; }
        public int Visina { get; set; }
        public int TezinaKG { get; set; }
        public string? BojaOciju { get; set; }
        public string? BojaKose { get; set; }
        public string? Zanimanje { get; set; }
        public string? KonfekcijskiBroj { get; set; }
        public string? Tip { get; set; }
        public string? NazivAgencije { get; set; }

        public IList<RevijaView>? Revije { get; set; }
        public AgencijaView? AgencijaModela { get; set; }

        public ManekenView()
        {
            Revije = new List<RevijaView>();
        }

        internal ManekenView(Maneken? m)
        {
            if (m != null)
            {
                JMBG = m.JMBG;
                Ime = m.Ime;
                Prezime = m.Prezime;
                DatumRodjenja = m.DatumRodjenja;
                Pol = m.Pol;
                Visina = m.Visina;
                TezinaKG = m.TezinaKG;
                BojaOciju = m.BojaOciju;
                BojaKose = m.BojaKose;
                Zanimanje = m.Zanimanje;
                KonfekcijskiBroj = m.KonfekcijskiBroj;
                Tip = m.Tip;
                NazivAgencije = m.Agencija?.Naziv;

            }
        }

        internal ManekenView(Agencija? a)
        {
            AgencijaModela = new AgencijaView(a);
        }
    }
}
