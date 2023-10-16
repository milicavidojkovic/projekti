using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    public class NaslovneStraneMapiranja : ClassMap<FashionWeek.Entiteti.NaslovneStrane>

    {
        public NaslovneStraneMapiranja()
        {
            Table("NAZIVNASLOVNE");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.NaslovneStrana, "NASLOVNASTRANA");
            References(x => x.Maneken).Column("JMBGMANEKENA").LazyLoad();

        }
    }
}
