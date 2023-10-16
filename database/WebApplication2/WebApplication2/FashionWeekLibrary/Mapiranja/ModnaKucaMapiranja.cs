using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FashionWeek.Entiteti;

namespace FashionWeek.Mapiranja
{
    class ModnaKucaMapiranja : ClassMap<FashionWeek.Entiteti.ModnaKuca>
    {
        public ModnaKucaMapiranja()
        {
            Table("MODNAKUCA");

            Id(x => x.KucaID, "KUCAID").GeneratedBy.TriggerIdentity();

            Map(x => x.ImeOsnivaca, "IMEOSNIVACA");
            Map(x => x.SedisteKuce, "SEDISTEKUCE");
            Map(x => x.Naziv, "NAZIV");

            HasMany(x => x.listaKreatora).KeyColumn("IDKUCE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.listaVlasnika).KeyColumn("JEDBROJ").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.listaKolekcija).KeyColumn("IDMODNEKUCE").LazyLoad().Cascade.All().Inverse();

        }

    }
}
