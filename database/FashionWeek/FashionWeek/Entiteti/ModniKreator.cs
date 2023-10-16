using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class ModniKreator
    {
        public virtual int Id { get; protected set; }
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string ZemljaPorekla { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Pol { get; set; }

        public virtual ModnaKuca modnaKuca { get; set; }

        public virtual IList<Revija> ListaOrganizovanihRevija { get; set; }

        public virtual IList<Revija> ListaUstvovanihRevija { get; set; }


        public virtual IList<ModniKreator> ListaKreatoraKojiSuZvali { get; set; }
        public virtual IList<ModniKreator> ListaPozvanihKreatora { get; set; }

        public ModniKreator()
        {

            ListaOrganizovanihRevija = new List<Revija>();
            ListaUstvovanihRevija = new List<Revija>();

            ListaKreatoraKojiSuZvali = new List<ModniKreator>();
            ListaPozvanihKreatora = new List<ModniKreator>();


        }
    }
}
