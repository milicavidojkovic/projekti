using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class Agencija
    {
        public virtual int Pib { get;  set; }
        public virtual string Naziv { get; set; }
        public virtual string Sediste { get; set; }
        public virtual DateTime DatumOsnivanja { get; set; }
        public virtual char Tip { get; set; }

        public virtual IList<Maneken> listaManekena { get; set; }
        public virtual IList<Zemlja> listaZemalja { get; set; }


        public Agencija()
        {
            listaManekena = new List<Maneken>();
            listaZemalja = new List<Zemlja>();



        }
    }
}
