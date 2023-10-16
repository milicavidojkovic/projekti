using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class Maneken
    {
        public virtual string JMBG { get;  set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Pol { get; set; }
        public virtual int Visina { get; set; }
        public virtual int TezinaKG { get; set; }
        public virtual string BojaOciju { get; set; }
        public virtual string BojaKose { get; set; }
        public virtual String Zanimanje { get; set; }
        public virtual string KonfekcijskiBroj { get; set; }

        public virtual string Tip { get; set; }

        public virtual Agencija Agencija { get; set; }

        public virtual IList<Revija> ListaRevija { get; set; }
        public virtual IList<NaslovneStrane> listaNaslovnih { get; set; }

        public Maneken()
        {
            ListaRevija = new List<Revija>();
            listaNaslovnih = new List<NaslovneStrane>();
        }
    }
}
