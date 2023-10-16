using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;


namespace FashionWeek.Mapiranja{
    class ManekenMapiranja : ClassMap<FashionWeek.Entiteti.Maneken>

    {
        public ManekenMapiranja()
        {
            Table("MANEKEN");

            Id(x => x.JMBG, "JMBG").GeneratedBy.Assigned();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatumRodjenja, "DATUMRODJENJA");
            Map(x => x.Pol, "POL");
            Map(x => x.Visina, "VISINACM");
            Map(x => x.TezinaKG, "TEZINAKG"); 
            Map(x => x.BojaKose, "BOJAKOSE");
            Map(x => x.BojaOciju, "BOJAOCIJU");
            Map(x => x.KonfekcijskiBroj, "KONFEKCIJSKIBROJ");
            Map(x => x.Tip, "TIP");
            Map(x => x.Zanimanje, "ZANIMANJE");

            References(x => x.Agencija).Column("AGENCIJAID").LazyLoad();

            HasManyToMany(x => x.ListaRevija)
                 .Table("REVIJAMANEKENI")
                 .ParentKeyColumn("MANEKENID")
                 .ChildKeyColumn("REVIJAID")
                 .Cascade.All();

            HasMany(x => x.listaNaslovnih).KeyColumn("JMBGMANEKENA").LazyLoad().Cascade.All().Inverse();

        }

    }
}
