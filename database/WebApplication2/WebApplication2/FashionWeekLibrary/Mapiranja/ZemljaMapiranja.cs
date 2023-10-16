using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    internal class ZemljaMapiranja : ClassMap<FashionWeek.Entiteti.Zemlja>
    {
        public ZemljaMapiranja()
        {
            Table("ZEMLJA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Naziv, "NAZIV");
            References(x => x.AgencijaId).Column("AGENCIJAID").LazyLoad();
        }
    }
}
