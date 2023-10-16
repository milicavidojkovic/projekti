using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    class RevijaMapiranja : ClassMap<FashionWeek.Entiteti.Revija>
    {
        public RevijaMapiranja()
        {
            Table("REVIJA");

            Id(x => x.RedniBroj, "REDNIBROJID").GeneratedBy.Assigned();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Mesto, "MESTO");
            Map(x => x.Datum, "DATUM");
            Map(x => x.Vreme, "VREME");
            Map(x => x.PrvaRevija, "PRVAREVIJA");

            References(x => x.KreatorOrganizator).Column("IDORGANIZATORA").LazyLoad();

            HasManyToMany(x => x.ListaKreatoraUcesnika)
                .Table("KREATORREVIJA")
                .ParentKeyColumn("REVIJAID")
                .ChildKeyColumn("KREATORID")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x => x.ListaManekena)
                 .Table("REVIJAMANEKENI")
                 .ParentKeyColumn("REVIJAID")
                 .ChildKeyColumn("MANEKENID")
                 .Cascade.All()
                 .Inverse();

           
            HasOne(x => x.Kolekcija)
            .Cascade.All()
            .ForeignKey("REVIJAID");
        }
    }
}
