using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    class KolekcijaMapiranja : ClassMap<FashionWeek.Entiteti.Kolekcija>
    {
        public KolekcijaMapiranja()
        {
            Table("KOLEKCIJA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Sezona, "SEZONA");

            References(x => x.Revija)
            .Unique()
            .Cascade.All()
            .Column("REVIJAID");

            References(x => x.ModnaKuca).Column("IDMODNEKUCE").LazyLoad();
        }
    }
}
