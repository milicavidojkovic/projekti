using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Event.Default;
using System.Web;
using FashionWeek;


namespace FashionWeek
{
    public static class DataProvider
    {
        #region Agencija
        public static async Task<Result<List<AgencijaView>, string>> VratiSveAgencijeAsync()
        {
            List<AgencijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<Agencija>().ListAsync())
                               .Select(p => new AgencijaView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o agencijama.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiAgencijuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Agencija agencija = await s.LoadAsync<Agencija>(id);

                await s.DeleteAsync(agencija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja agencije.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> IzmeniAgencijuAsync(AgencijaView agencija)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Agencija a = await s.LoadAsync<Agencija>(agencija.Pib);

                a.Naziv = agencija.Naziv;
                a.Sediste = agencija.Sediste;
                a.DatumOsnivanja = agencija.DatumOsnivanja;
                a.Tip = agencija.Tip;

                await s.SaveOrUpdateAsync(a);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti agenciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<int, string>> SacuvajAgencijuAsync(AgencijaView agencija)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Agencija a = new()
                {
                 Naziv = agencija.Naziv,
                Sediste = agencija.Sediste,
                DatumOsnivanja = agencija.DatumOsnivanja,
                Tip = agencija.Tip
            };

                await s.SaveAsync(a);
                await s.FlushAsync();

                id = a.Pib;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati agenciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region Kolekcija

        public static async Task<Result<List<KolekcijaView>, string>> VratiSvKolekcijeAsync()
        {
            List<KolekcijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<Kolekcija>().ListAsync())
                               .Select(p => new KolekcijaView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o kolekcijama.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiKolekcijuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Kolekcija agencija = await s.LoadAsync<Kolekcija>(id);

                await s.DeleteAsync(agencija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja kolekcije.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> PoveziKolekcijuRevijuIModnuKucuAsync(int revijaId,int kolekcijaId, int ModnaKucaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Kolekcija kolekcija = await s.LoadAsync<Kolekcija>(kolekcijaId);
                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(ModnaKucaId);
                Revija revija = await s.LoadAsync<Revija>(revijaId);

                kolekcija.ModnaKuca = modnaKuca;
                kolekcija.Revija = revija;

                await s.UpdateAsync(kolekcija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće povezati kolekciju sa modnom kucom i revijom.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> IzmeniKolekcijuAsync(KolekcijaView kolekcija)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Kolekcija k = await s.LoadAsync<Kolekcija>(kolekcija.Id);

                k.Naziv = kolekcija.Naziv;
                k.Opis = kolekcija.Opis;
                k.Sezona = kolekcija.Sezona;

                await s.SaveOrUpdateAsync(k);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti agenciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajKolekcijuAsync(KolekcijaView kolekcija)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Kolekcija k = new()
                {
                    Naziv = kolekcija.Naziv,
                Opis = kolekcija.Opis,
                Sezona = kolekcija.Sezona
            };

                await s.SaveAsync(k);
                await s.FlushAsync();

                id = k.Id;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati kolekciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region Maneken

        public static async Task<Result<List<ManekenView>, string>> VratiSveManekeneAsync()
        {
            List<ManekenView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<Maneken>().ListAsync())
                               .Select(p => new ManekenView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o manekenima.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiManekenaAsync(string id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Maneken maneken = await s.LoadAsync<Maneken>(id);

                await s.DeleteAsync(maneken);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja manekena.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> PoveziManekenaIRevijuAsync(int revijaId, string manekenId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Maneken maneken = await s.LoadAsync<Maneken>(manekenId);
                
                Revija revija = await s.LoadAsync<Revija>(revijaId);

                
                maneken.ListaRevija?.Add(revija);

                await s.UpdateAsync(maneken);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće povezati manekena sa revijom.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> PoveziManekenaIAgencijuAsync(int agencijaId, string manekenId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Maneken maneken = await s.LoadAsync<Maneken>(manekenId);

                Agencija agencija = await s.LoadAsync<Agencija>(agencijaId);


                maneken.Agencija=agencija;

                await s.UpdateAsync(maneken);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće povezati manekena sa agencijom.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> IzmeniManekenaAsync(ManekenView maneken)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Maneken m = await s.LoadAsync<Maneken>(maneken.JMBG);

                m.Ime=maneken.Ime;
                m.Prezime=maneken.Prezime;
                m.DatumRodjenja=maneken.DatumRodjenja;
                m.Pol=maneken.Pol;
                m.Visina=maneken.Visina;
                m.TezinaKG=maneken.TezinaKG;
                m.BojaOciju=maneken.BojaOciju;
                    m.BojaKose=maneken.BojaKose;
                m.Zanimanje=maneken.Zanimanje;
                m.KonfekcijskiBroj=maneken.KonfekcijskiBroj;
                m.Tip=maneken.Tip;

                await s.SaveOrUpdateAsync(m);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti agenciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajManekenaAsync(ManekenView maneken)
        {
            ISession? s = null;
            string? JMBG = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Maneken m = new()
                {
                    Ime = maneken.Ime,
                Prezime = maneken.Prezime,
                DatumRodjenja = maneken.DatumRodjenja,
               Pol = maneken.Pol,
                Visina = maneken.Visina,
                TezinaKG = maneken.TezinaKG,
                BojaOciju = maneken.BojaOciju,
                BojaKose = maneken.BojaKose,
                Zanimanje = maneken.Zanimanje,
                KonfekcijskiBroj = maneken.KonfekcijskiBroj,
                Tip = maneken.Tip
                    };

                await s.SaveAsync(m);
                await s.FlushAsync();

                JMBG = m.JMBG;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati kolekciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return JMBG;
        }

        #endregion 

        #region ModnaKuca

        public static async Task<Result<List<ModnaKucaView>, string>> VratiSveModneKuceAsync()
        {
            List<ModnaKucaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<ModnaKuca>().ListAsync())
                               .Select(p => new ModnaKucaView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o modnim kucama.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiModnuKucuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(id);

                await s.DeleteAsync(modnaKuca);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja modne kuce.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajUModnuKucuKreatoraAsync(int modnaKucaID, int kreatorID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator modniKreator = await s.LoadAsync<ModniKreator>(kreatorID);
                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(modnaKucaID);
                

                modnaKuca.listaKreatora?.Add(modniKreator);

                await s.UpdateAsync(modnaKuca);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati kreatora u modnu kucu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajUModnuKucuKolekcijuAsync(int modnaKucaID, int kolekcijaID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Kolekcija kolekcija= await s.LoadAsync<Kolekcija>(kolekcijaID);
                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(modnaKucaID);


                modnaKuca.listaKolekcija?.Add(kolekcija);

                await s.UpdateAsync(modnaKuca);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati kolekciju u modnu kucu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }


        public async static Task<Result<bool, string>> DodajUModnuKucuVlasnikaAsync(int modnaKucaID, int vlasnikMKId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                VlasniciMK vlasnik = await s.LoadAsync<VlasniciMK>(vlasnikMKId);
                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(modnaKucaID);


                modnaKuca.listaVlasnika?.Add(vlasnik);

                await s.UpdateAsync(modnaKuca);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati vlasnika u modnu kucu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> IzmeniModnuKucuAsync(ModnaKucaView modnaKuca)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModnaKuca mk = await s.LoadAsync<ModnaKuca>(modnaKuca.KucaId);

                mk.ImeOsnivaca = modnaKuca.ImeOsnivaca;
                mk.SedisteKuce=modnaKuca.SedisteKuce;
                mk.Naziv=modnaKuca.Naziv;

                await s.SaveOrUpdateAsync(mk);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti modnu kucu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajModnuKucuAsync(ModnaKucaView modnaKuca)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModnaKuca mk = new()
                {
                    ImeOsnivaca = modnaKuca.ImeOsnivaca,
                SedisteKuce = modnaKuca.SedisteKuce,
                Naziv = modnaKuca.Naziv
            };

                await s.SaveAsync(mk);
                await s.FlushAsync();

                id = mk.KucaID;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati kolekciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region ModniKreator

        public static async Task<Result<List<ModniKreatorView>, string>> VratiSveModneKreatoreAsync()
        {
            List<ModniKreatorView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<ModniKreator>().ListAsync())
                               .Select(p => new ModniKreatorView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o modnim kreatorima.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiModnogKreatoraAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator modniKreator = await s.LoadAsync<ModniKreator>(id);

                await s.DeleteAsync(modniKreator);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja modnog kreatora.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajModnomKreatoruModnuKucuAsync(int modnaKucaID, int kreatorID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator modniKreator = await s.LoadAsync<ModniKreator>(kreatorID);
                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(modnaKucaID);


                modniKreator.modnaKuca=modnaKuca;

                await s.UpdateAsync(modniKreator);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati modnu kucu kreatoru.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajModnomKreatoruOrganizovaneRevijeAsync(int modniKreatorID, int revijaID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija revija = await s.LoadAsync<Revija>(revijaID);
                ModniKreator modniKreator= await s.LoadAsync<ModniKreator>(modniKreatorID);


                modniKreator.ListaOrganizovanihRevija?.Add(revija);

                await s.UpdateAsync(modniKreator);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati reviju koju je modni kreator organizovao";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajModnomKreatoruUcestvovaneRevijeAsync(int modniKreatorID, int revijaID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija revija = await s.LoadAsync<Revija>(revijaID);
                ModniKreator modniKreator = await s.LoadAsync<ModniKreator>(modniKreatorID);


                modniKreator.ListaUstvovanihRevija?.Add(revija);

                await s.UpdateAsync(modniKreator);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati reviju u kojoj je modni kreator ucestvovao";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajModnomKreatoruModneKreatoreAsync(int modniKreator1ID, int modniKreator2ID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator modniKreator1 = await s.LoadAsync<ModniKreator>(modniKreator1ID);
                ModniKreator modniKreator2 = await s.LoadAsync<ModniKreator>(modniKreator2ID);

                modniKreator1.ListaPozvanihKreatora?.Add(modniKreator2);
                modniKreator2.ListaKreatoraKojiSuZvali?.Add(modniKreator1);

                await s.UpdateAsync(modniKreator1);
                await s.UpdateAsync(modniKreator2);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati modnog kreatora koji je zvao drugog";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }


        public async static Task<Result<bool, string>> IzmeniModnogKreatoraAsync(ModniKreatorView modniKreator)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator mk = await s.LoadAsync<ModniKreator>(modniKreator.Id);

                mk.JMBG = modniKreator.JMBG;
                mk.Ime=modniKreator.Ime;
                mk.Prezime=modniKreator.Prezime;
                mk.ZemljaPorekla=modniKreator.ZemljaPorekla;
                mk.DatumRodjenja=modniKreator.DatumRodjenja;
                mk.Pol=modniKreator.Pol;

                await s.SaveOrUpdateAsync(mk);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti modnog kreatora.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<int, string>> SacuvajModnogKreatoraAsync(ModniKreatorView modniKreator)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator mk = new()
                {
                    JMBG = modniKreator.JMBG,
                Ime = modniKreator.Ime,
                Prezime = modniKreator.Prezime,
                ZemljaPorekla = modniKreator.ZemljaPorekla,
                DatumRodjenja = modniKreator.DatumRodjenja,
                Pol = modniKreator.Pol
            };

                await s.SaveAsync(mk);
                await s.FlushAsync();

                id = mk.Id;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati kolekciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region NaslovneStrane

        public static async Task<Result<List<NaslovneStraneView>, string>> VratiSveNaslovneStraneAsync()
        {
            List<NaslovneStraneView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<NaslovneStrane>().ListAsync())
                               .Select(p => new NaslovneStraneView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o naslovnim stranama.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiNaslovnuStranuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                NaslovneStrane naslovna = await s.LoadAsync<NaslovneStrane>(id);

                await s.DeleteAsync(naslovna);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja naslovne strane.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> SpojiNaslovnuSaManekenomAsync(int naslovnaId, string manekenID)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                NaslovneStrane naslovna = await s.LoadAsync<NaslovneStrane>(naslovnaId);
                Maneken maneken = await s.LoadAsync<Maneken>(manekenID);


                naslovna.Maneken=maneken;

                await s.UpdateAsync(naslovna);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće spojiti manekena i naslovnu stranu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }


        public async static Task<Result<bool, string>> IzmeniNaslovnuStranuAsync(NaslovneStraneView naslovna)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                NaslovneStrane ns = await s.LoadAsync<NaslovneStrane>(naslovna.Id);

                ns.NaslovneStrana = naslovna.NaslovneStrana;

                await s.SaveOrUpdateAsync(ns);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti naslovnu stranu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajNaslovuStranuAsync(NaslovneStraneView naslovna)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                NaslovneStrane ns = new()
                {
                    NaslovneStrana = naslovna.NaslovneStrana
            };

                await s.SaveAsync(ns);
                await s.FlushAsync();

                id = ns.Id;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati kolekciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region Revija

        public static async Task<Result<List<RevijaView>, string>> VratiSveRevijeAsync()
        {
            List<RevijaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<Revija>().ListAsync())
                               .Select(p => new RevijaView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o revijama.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiRevijuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija revija = await s.LoadAsync<Revija>(id);

                await s.DeleteAsync(revija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja revije.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajRevijiOrganizatoraAsync(int revijaId, int kreatorID,string prvaRevija)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                ModniKreator modniKreator = await s.LoadAsync<ModniKreator>(kreatorID);
                Revija revija = await s.LoadAsync<Revija>(revijaId);


                revija.KreatorOrganizator=modniKreator;
                revija.PrvaRevija = prvaRevija;

                await s.UpdateAsync(revija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati organizatora reviji.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajRevijiKolekcijuAsync(int revijaId, int kolekcijaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Kolekcija kolekcija = await s.LoadAsync<Kolekcija>(kolekcijaId);
                Revija revija = await s.LoadAsync<Revija>(revijaId);


                revija.Kolekcija = kolekcija;

                await s.UpdateAsync(revija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati organizatora reviji.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> DodajRevijiKreatoraUcesnikaAsync(int revijaId, int kreatorId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija revija = await s.LoadAsync<Revija>(revijaId);
                ModniKreator modniKreator = await s.LoadAsync<ModniKreator>(kreatorId);


                revija.ListaKreatoraUcesnika?.Add(modniKreator);

                await s.UpdateAsync(revija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati kreatora ucesnika reviji.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }


        public async static Task<Result<bool, string>> DodajRevijiManekenaAsync(int revijaId, string manekenId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija revija = await s.LoadAsync<Revija>(revijaId);
                Maneken maneken = await s.LoadAsync<Maneken>(manekenId);


                revija.ListaManekena?.Add(maneken);

                await s.UpdateAsync(revija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati manekena reviji.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> IzmeniRevijuAsync(RevijaView revija)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija rv = await s.LoadAsync<Revija>(revija.RedniBroj);

                rv.Naziv = revija.Naziv;
                rv.Mesto=revija.Mesto;
                rv.Datum = revija.Datum;
                rv.Vreme = revija.Vreme;
                

                await s.SaveOrUpdateAsync(rv);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti reviju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajRevijuAsync(RevijaView revija)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Revija rv = new()
                {
                    Naziv = revija.Naziv,
                Mesto = revija.Mesto,
                Datum = revija.Datum,
                Vreme = revija.Vreme
            };

                await s.SaveAsync(rv);
                await s.FlushAsync();

                id = rv.RedniBroj;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati reviju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region VlasniciMK

        public static async Task<Result<List<VlasniciMKView>, string>> VratiSveVlasnikeAsync()
        {
            List<VlasniciMKView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<VlasniciMK>().ListAsync())
                               .Select(p => new VlasniciMKView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o vlasnicima.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiVlasnikaAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                VlasniciMK vlasnik = await s.LoadAsync<VlasniciMK>(id);

                await s.DeleteAsync(vlasnik);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja vlasnika.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> SpojiVlasnikaSaModnomKucomAsync(int vlasnikId, int modnaKucaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                VlasniciMK vlasnik = await s.LoadAsync<VlasniciMK>(vlasnikId);
                ModnaKuca modnaKuca = await s.LoadAsync<ModnaKuca>(modnaKucaId);


                vlasnik.JedBroj = modnaKuca;

                await s.UpdateAsync(vlasnik);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće spojiti vlasnika i modnu kucu.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }


        public async static Task<Result<bool, string>> IzmeniVlasnikaAsync(VlasniciMKView vlasnik)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                VlasniciMK vlas = await s.LoadAsync<VlasniciMK>(vlasnik.Id);

                vlas.ImeVlasnika = vlasnik.ImeVlasanika;

                await s.SaveOrUpdateAsync(vlas);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti vlasnika.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajVlasnikaAsync(VlasniciMKView vlasnik)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                VlasniciMK vlas = new()
                {
                    ImeVlasnika = vlasnik.ImeVlasanika
            };

                await s.SaveAsync(vlas);
                await s.FlushAsync();

                id = vlas.Id;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati vlasnika.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion

        #region Zemlja

        public static async Task<Result<List<ZemljaView>, string>> VratiSveZemljeAsync()
        {
            List<ZemljaView> data = new();

            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                data = (await s.QueryOver<Zemlja>().ListAsync())
                               .Select(p => new ZemljaView(p)).ToList();
            }
            catch (Exception)
            {
                return "Došlo je do greške prilikom prikupljanja informacija o zemljama.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return data;
        }

        public async static Task<Result<bool, string>> ObrisiZemljuAsync(int id)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Zemlja zemlja = await s.LoadAsync<Zemlja>(id);

                await s.DeleteAsync(zemlja);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Greška prilikom brisanja zemlja.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, string>> SpojiZemljuSaAgencijomAsync(int zemljaId, int agencijaId)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Zemlja zemlja= await s.LoadAsync<Zemlja>(zemljaId);
                Agencija agencija = await s.LoadAsync<Agencija>(agencijaId);


                zemlja.AgencijaId = agencija;

                await s.UpdateAsync(zemlja);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće spojiti zemlju i agenciju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }


        public async static Task<Result<bool, string>> IzmeniZemljuAsync(ZemljaView zemlja)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Zemlja zm = await s.LoadAsync<Zemlja>(zemlja.Id);

                zm.Naziv = zemlja.Naziv;

                await s.SaveOrUpdateAsync(zm);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti zemlju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }



        public async static Task<Result<int, string>> SacuvajZemljuAsync(ZemljaView zemlja)
        {
            ISession? s = null;
            int id = default;

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.";
                }

                Zemlja zm = new()
                {
                    Naziv = zemlja.Naziv
                };

                await s.SaveAsync(zm);
                await s.FlushAsync();

                id = zm.Id;
            }
            catch (Exception)
            {
                return "Nemoguće sačuvati zemlju.";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return id;
        }

        #endregion
    }
}
