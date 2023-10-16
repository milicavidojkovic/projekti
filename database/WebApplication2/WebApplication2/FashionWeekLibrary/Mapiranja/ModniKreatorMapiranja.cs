using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    class ModniKreatorMapiranja : ClassMap<FashionWeek.Entiteti.ModniKreator>
    {
        public ModniKreatorMapiranja()
        {
            Table("MODNIKREATOR");



            Id(x => x.Id, "KREATORID").GeneratedBy.TriggerIdentity();



            Map(x => x.JMBG, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.ZemljaPorekla, "ZEMLJAPOREKLA");
            Map(x => x.DatumRodjenja, "DATUMRODJENJA");
            Map(x => x.Pol, "POL");

            References(x => x.modnaKuca).Column("IDKUCE").LazyLoad();

            HasMany(x => x.ListaOrganizovanihRevija).KeyColumn("IDORGANIZATORA").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.ListaUstvovanihRevija)
               .Table("KREATORREVIJA")
               .ParentKeyColumn("KREATORID")
               .ChildKeyColumn("REVIJAID")
               .Cascade.All();

            HasManyToMany(x => x.ListaPozvanihKreatora)
               .Table("MKMKO")
               .ParentKeyColumn("MKOID")
               .ChildKeyColumn("MKID")
               .Cascade.All()
               .Inverse();


            HasManyToMany(x => x.ListaKreatoraKojiSuZvali)
              .Table("MKMKO")
              .ParentKeyColumn("MKID")
              .ChildKeyColumn("MKOID")
              .Cascade.All();             
        }
    }

}
