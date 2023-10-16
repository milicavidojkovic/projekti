using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionWeek.Entiteti;
using NHibernate;
using FluentNHibernate.Mapping;
using NHibernate.Linq;

namespace FashionWeek
{
    public class DTOManager
    {
        #region ModnaKuca
        //samo za modnu kucu
        public static List<ModnaKucaPregled> vratiSveProizvode()
        {
            List<ModnaKucaPregled> mk = new List<ModnaKucaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<FashionWeek.Entiteti.ModnaKuca> sveMK = from o in s.Query<FashionWeek.Entiteti.ModnaKuca>()
                                                                   select o;

                foreach (FashionWeek.Entiteti.ModnaKuca p in sveMK)
                {
                    mk.Add(new ModnaKucaPregled(p.KucaID, p.Naziv, p.ImeOsnivaca, p.SedisteKuce));
                }

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return mk;
        }


        public static void dodajKucu(ModnaKucaBasic mk)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca kuca = new FashionWeek.Entiteti.ModnaKuca();

                kuca.Naziv = mk.Naziv;
                kuca.SedisteKuce = mk.SedisteKuce;
                kuca.ImeOsnivaca = mk.ImeOsnivaca;

                s.SaveOrUpdate(kuca);
                s.Flush();
                s.Close();
            }
            catch(Exception ec) { }
        }

        public static ModnaKucaBasic izmeniKucu(ModnaKucaBasic kuca)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca mk = s.Load<FashionWeek.Entiteti.ModnaKuca>(kuca.KucaId);
                mk.Naziv = kuca.Naziv;
                mk.SedisteKuce = kuca.SedisteKuce;
                mk.ImeOsnivaca = kuca.ImeOsnivaca;

                s.Update(mk);
                s.Flush();

                s.Close();
            }
            catch(Exception ec) { }
            return kuca;
        }

        public static void obrisiKucu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca mk = s.Load<FashionWeek.Entiteti.ModnaKuca>(id);

                s.Delete(mk);
                s.Flush();
                s.Close();
            }
            catch (Exception ec) { }
        }
        public static ModnaKucaBasic vratiKucu(int id)

        {
            ModnaKucaBasic kuca = new ModnaKucaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca mk = s.Load<FashionWeek.Entiteti.ModnaKuca>(id);
                kuca = new ModnaKucaBasic(mk.KucaID, mk.Naziv, mk.SedisteKuce, mk.ImeOsnivaca);

                s.Close();
            }
            catch (Exception ec) { }
            return kuca;
        }

        #endregion


        #region ModniKreator

        public static List<ModniKreatorPregled> vratiSveKreatore()
        {
            List<ModniKreatorPregled> kreatori = new List<ModniKreatorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<FashionWeek.Entiteti.ModniKreator> sviMK = from x in s.Query<FashionWeek.Entiteti.ModniKreator>()
                                                                       select x;

                foreach (FashionWeek.Entiteti.ModniKreator y in sviMK)
                {
                    kreatori.Add(new ModniKreatorPregled(y.Id, y.Ime, y.Prezime, y.ZemljaPorekla, y.Pol));
                }
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {

            }
            return kreatori;
        }
        public static ModniKreatorBasic vratiKreatora(int id)
        {
            ModniKreatorBasic kreator = new ModniKreatorBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                FashionWeek.Entiteti.ModniKreator mk = s.Load<FashionWeek.Entiteti.ModniKreator>(id);
                kreator = new ModniKreatorBasic(mk.Id, mk.JMBG, mk.Ime, mk.Prezime, mk.ZemljaPorekla, mk.DatumRodjenja, mk.Pol);
                s.Close();
            }
            catch(Exception ec) { }
            return kreator;
        }
        public static void dodajKreatora(ModniKreatorBasic mk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                FashionWeek.Entiteti.ModniKreator kreator = new FashionWeek.Entiteti.ModniKreator();

                kreator.JMBG = mk.JMBG;
                kreator.Ime = mk.Ime;
                kreator.Prezime = mk.Prezime;
                kreator.ZemljaPorekla = mk.ZemljaPorekla;
                kreator.DatumRodjenja = mk.DatumRodjenja;
                kreator.Pol = mk.Pol;

                s.SaveOrUpdate(kreator);

                s.Flush();
                s.Close();
            }
            catch (Exception ec) { }
        }

        public static ModniKreatorBasic izmeniKreatora(ModniKreatorBasic mk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                FashionWeek.Entiteti.ModniKreator kreator = new FashionWeek.Entiteti.ModniKreator();

                kreator.JMBG = mk.JMBG;
                kreator.Ime = mk.Ime;
                kreator.Prezime = mk.Prezime;
                kreator.ZemljaPorekla = mk.ZemljaPorekla;
                kreator.DatumRodjenja = mk.DatumRodjenja;
                kreator.Pol = mk.Pol;

                s.Update(kreator);

                s.Flush();
                s.Close();
          
            }
            catch (Exception ec) { }
            return mk;
       
        }

        public static void obrisiKreatora(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModniKreator mk = s.Load<FashionWeek.Entiteti.ModniKreator>(id);

                s.Delete(mk);
                s.Flush();
                s.Close();
            }
            catch(Exception ec) { } 
        }
        #endregion

        #region Revija  
        public static List<RevijaPregled> vratiSveRevije()
        {
            List<RevijaPregled> revije = new List<RevijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<FashionWeek.Entiteti.Revija> sveRevije = from o in s.Query<FashionWeek.Entiteti.Revija>()
                                                                    select o;

                foreach (FashionWeek.Entiteti.Revija p in sveRevije)
                {
                    revije.Add(new RevijaPregled(p.RedniBroj, p.Naziv, p.Mesto, p.Datum,p.Vreme));
                }

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return revije;
        }
        #endregion
    }

}
