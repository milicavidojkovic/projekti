using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class ModniKreator
    {
        internal protected virtual int Id { get; protected set; }
        internal protected virtual string? JMBG { get; set; }
        internal protected virtual string? Ime { get; set; }
        internal protected virtual string? Prezime { get; set; }
        internal protected virtual string? ZemljaPorekla { get; set; }
        internal protected virtual DateTime? DatumRodjenja { get; set; }
        internal protected virtual string? Pol { get; set; }

        internal protected virtual ModnaKuca? modnaKuca { get; set; }

        internal protected virtual IList<Revija>? ListaOrganizovanihRevija { get; set; }

        internal protected virtual IList<Revija>? ListaUstvovanihRevija { get; set; }


        internal protected virtual IList<ModniKreator>? ListaKreatoraKojiSuZvali { get; set; }
        internal protected virtual IList<ModniKreator>? ListaPozvanihKreatora { get; set; }

        internal ModniKreator()
        {

            ListaOrganizovanihRevija = new List<Revija>();
            ListaUstvovanihRevija = new List<Revija>();

            ListaKreatoraKojiSuZvali = new List<ModniKreator>();
            ListaPozvanihKreatora = new List<ModniKreator>();


        }
    }
}
