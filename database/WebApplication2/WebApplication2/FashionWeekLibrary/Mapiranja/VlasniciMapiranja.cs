using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    internal class VlasniciMapiranja : ClassMap<FashionWeek.Entiteti.VlasniciMK>

    {
        public VlasniciMapiranja()
        {
            Table("VLASNICIMODNIHKUCA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.ImeVlasnika, "IMEVLASNIKA");
            References(x => x.JedBroj).Column("JEDID").LazyLoad();

        }
    }
}
