using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    class AgencijaMapiranja : ClassMap<FashionWeek.Entiteti.Agencija>
    {
        public AgencijaMapiranja()
        {
            Table("AGENCIJA");

            Id(x => x.Pib, "PIB").GeneratedBy.Assigned();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Sediste, "SEDISTE");
            Map(x => x.DatumOsnivanja, "DATUMOSNIVANJA");
            Map(x => x.Tip, "TIP");

            HasMany(x => x.listaManekena).KeyColumn("AGENCIJAID").LazyLoad().Cascade.All().Inverse();


            HasMany(x => x.listaZemalja).KeyColumn("AGENCIJAID").LazyLoad().Cascade.All().Inverse();

        }
    }

}
