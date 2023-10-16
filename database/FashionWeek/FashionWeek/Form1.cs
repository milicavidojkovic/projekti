using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using FashionWeek.Entiteti;

namespace FashionWeek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdUcitavanjeModneKuce_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca mk = s.Load<FashionWeek.Entiteti.ModnaKuca>(4);

                MessageBox.Show(mk.ImeOsnivaca);

                s.Close();

            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeModneKuce_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.ModnaKuca mk = new Entiteti.ModnaKuca();
                mk.Naziv = "Armani";
                mk.ImeOsnivaca = "Djordjo Armani";
                mk.SedisteKuce = "Milano";

                s.Save(mk);

                s.Flush();
                s.Close();
            }

            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcitavanjeManekena_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.Maneken mn = s.Load<FashionWeek.Entiteti.Maneken>("1234567891001");

                MessageBox.Show(mn.Ime + " " + mn.Prezime);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdDodavanjeManekena_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Maneken mn = new Entiteti.Maneken();
                mn.JMBG = "2012001457814";
                mn.Ime = "Gigi";
                mn.Prezime = "Hadid";
                mn.Pol = "Z";
                mn.Tip = "M";

                s.Save(mn);

                s.Flush();
                s.Close();
            }

            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdModniKreatorUcitavanje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModniKreator mk = s.Load<FashionWeek.Entiteti.ModniKreator>(4);

                MessageBox.Show(mk.Ime + " " + mk.Prezime);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodajMKreatora_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.ModniKreator mn = new Entiteti.ModniKreator();
                mn.JMBG = "0610001457814";
                mn.Ime = "Tom";
                mn.Prezime = "Ford";
                mn.Pol = "M";
                mn.ZemljaPorekla = "SAD";
                mn.DatumRodjenja = new DateTime(1961, 8, 27);
                

                s.Save(mn);

                s.Flush();
                s.Close();
            }

            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcitavanjeRevije_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.Revija mk = s.Load<FashionWeek.Entiteti.Revija>(3);

                MessageBox.Show(mk.Naziv + " " + mk.Mesto);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeRevije_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Revija mn = new Entiteti.Revija();
                mn.RedniBroj = 5;
                mn.Naziv = "Revija5";
                mn.Mesto = "Njujork";
                mn.Datum = new DateTime(2023, 8, 27);
                mn.Vreme = new DateTime(1, 1, 1, 13, 13, 13);


                s.Save(mn);

                s.Flush();
                s.Close();
            }

            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcitavanjeAgencije_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.Agencija mk = s.Load<FashionWeek.Entiteti.Agencija>(2);
                string tip;
                if (mk.Tip == 'I')
                    tip = "Internacionalna";
                else
                    tip = "Domaca";
                MessageBox.Show(mk.Naziv + " " + tip);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeAgencije_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Agencija mn = new Entiteti.Agencija();
                mn.Pib = 3;
                mn.Sediste = "Monako";
                mn.Tip = 'I';
                mn.DatumOsnivanja = new DateTime(2012, 4, 20);
                mn.Naziv = "FashionIcon";


                s.Save(mn);

                s.Flush();
                s.Close();
            }

            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcitavanjeKolekcije_Click(object sender, EventArgs e)
        {
            try
            {
               ISession s = DataLayer.GetSession();
               Revija r = s.Load<Revija>(1);

               MessageBox.Show(r.Naziv);

               MessageBox.Show(r.Kolekcija.Naziv);
             
              s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOne_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModniKreator mk = s.Load<FashionWeek.Entiteti.ModniKreator>(6);
                MessageBox.Show(mk.Ime + " " + mk.Prezime);
                MessageBox.Show(mk.modnaKuca.Naziv);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca mk = s.Load<FashionWeek.Entiteti.ModnaKuca>(7);

                foreach (ModniKreator m in mk.listaKreatora)
                {
                    MessageBox.Show(m.Ime + " " + m.Prezime);
                }
                s.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeOdeljenja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FashionWeek.Entiteti.ModnaKuca mk = new ModnaKuca()
                {

                    ImeOsnivaca = "Zak Lenoar",
                    SedisteKuce = "Pariz",
                    Naziv="Cloe"

                };

                ModniKreator m1 = new ModniKreator()
                {
                    JMBG = "2012001784512",
                    Ime = "Gabi",
                    Prezime = "Agion",
                    ZemljaPorekla = "Francuska",
                    DatumRodjenja = new DateTime(1921, 12, 11),
                    Pol = "Z"
                };

                ModniKreator m2 = new ModniKreator()
                {
                    JMBG = "0610001345689",
                    Ime = "Gabriela",
                    Prezime = "Herst",
                    ZemljaPorekla = "Francuska",
                    DatumRodjenja = new DateTime(1968, 2, 21),
                    Pol = "Z"
                };

                m1.modnaKuca = mk;
                m2.modnaKuca = mk;

                mk.listaKreatora.Add(m1);
                mk.listaKreatora.Add(m2);

                s.Save(mk);

                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeMkRev_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ISession s = DataLayer.GetSession();
            //
            //    FashionWeek.Entiteti.ModnaKuca mk = new ModnaKuca()
            //    {
            //        
            //        ImeOsnivaca = "Alfred Van Cleef",
            //        SedisteKuce = "Pariz",
            //        Naziv = "Van Cleef"
            //
            //    };
            //
            //    Revija m1 = new Revija()
            //    {
            //        RedniBroj=6,
            //        Naziv="Revija6", 
            //        Datum=new DateTime(2021, 12,3),
            //        Vreme=new DateTime(1,1,1,10,10,5),
            //        Mesto="Rim"
            //    };
            //
            //    Revija m2 = new Revija()
            //    {
            //        RedniBroj = 7,
            //        Naziv = "Revija7",
            //        Datum = new DateTime(2022, 10, 6),
            //        Vreme = new DateTime(1, 1, 5, 7, 10, 5),
            //        Mesto = "Madrid"
            //    };
            //
            //    m1.modnaKuca = mk;
            //    m2.modnaKuca = mk;
            //
            //    mk.listaRevija.Add(m1);
            //    mk.listaRevija.Add(m2);
            //
            //    s.Save(mk);
            //
            //    s.Flush();
            //    s.Close();
            //
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                ISession s = DataLayer.GetSession();



                Entiteti.ModniKreator mk = new Entiteti.ModniKreator()
                {
                    JMBG = "9876564483704",
                    Ime = "Vivijen",
                    Prezime = "Vestvud",
                    ZemljaPorekla = "Velika Britanija",
                    DatumRodjenja = new DateTime(1941, 4, 8),
                    Pol = "Z"
                };




                Revija r1 = new Revija()
                {
                    RedniBroj = 8,
                    Naziv = "Lookbook",
                    Mesto = "London",
                    Datum = new DateTime(2023, 12, 11),
                    Vreme = new DateTime(1, 1, 1, 16, 34, 0),
                    PrvaRevija="DA"
                };





                Revija r2 = new Revija()
                {
                    RedniBroj = 9,
                    Naziv = "FranceInFashion",
                    Mesto = "Pariz",
                    Datum = new DateTime(2023, 5, 23),
                    Vreme = new DateTime(1, 1, 1, 20, 0, 0),
                    PrvaRevija = "NE"

                };


                r1.KreatorOrganizator = mk;
                r2.KreatorOrganizator = mk;



                mk.ListaOrganizovanihRevija.Add(r1);
                mk.ListaOrganizovanihRevija.Add(r2);



                s.Save(mk);



                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAgencijaManekeni_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();



                Entiteti.Agencija ag = new Entiteti.Agencija()
                {
                    Pib=4,
                    Naziv="MVM",
                    Sediste="Sofija",
                    DatumOsnivanja= new DateTime(1, 1, 1, 3, 14, 1),
                    Tip='I'
                };




                Maneken m1 = new Maneken()
                {
                    JMBG = "1401003459678",
                    Ime="Naomi",
                    Prezime="Kembel",
                    DatumRodjenja= new DateTime(1970, 5, 22),
                    Pol = "Z",
                    Visina = 179,
                    TezinaKG = 58,
                    BojaKose = "braon",
                    BojaOciju="braon",
                    KonfekcijskiBroj="xxs",
                    Tip="M"
                    

                };

                Maneken m2 = new Maneken()
                {
                    JMBG = "1612001633989",
                    Ime = "Dejbid",
                    Prezime = "Gandi",
                    DatumRodjenja = new DateTime(1980, 2, 19),
                    Pol = "M",
                    Visina = 191,
                    TezinaKG = 70,
                    BojaKose = "crna",
                    BojaOciju = "plava",
                    KonfekcijskiBroj = "xs",
                    Tip = "M"

                };


                m1.Agencija = ag;
                m2.Agencija = ag;



               ag.listaManekena.Add(m1);
               ag.listaManekena.Add(m2);



                s.Save(ag);



                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreatorRevija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija r = s.Load<Revija>(1);
                ModniKreator mk = s.Load<ModniKreator>(5);
                foreach(ModniKreator m in r.ListaKreatoraUcesnika)
                {
                    MessageBox.Show(m.Ime + " " + m.Prezime);
                }

                foreach(Revija rev in mk.ListaUstvovanihRevija)
                {
                    MessageBox.Show(rev.Naziv);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeRevijaKreator_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija r = new Revija() {
                    RedniBroj = 7,
                    Naziv="Revija7",
                    Mesto="Sarajevo",
                    Datum=new DateTime(2021, 12,13),
                    Vreme=new DateTime(1,1,1,1,13,12)
                    
                };
                ModniKreator mk =  new ModniKreator(){
                    JMBG="1612001586947",
                    Ime="Sara",
                    Prezime="Blejkli",
                    ZemljaPorekla="SAD",
                    DatumRodjenja=new DateTime(1971, 2,27),
                    Pol="Z"

                };

                r.ListaKreatoraUcesnika.Add(mk);
                mk.ListaUstvovanihRevija.Add(r);

                s.Save(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdRevijaManeken_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija r = s.Load<Revija>(4);
                Maneken mk = s.Load<Maneken>("1234567891001");
                foreach (Maneken m in r.ListaManekena)
                {
                    MessageBox.Show(m.Ime + " " + m.Prezime);
                }

                foreach (Revija rev in mk.ListaRevija)
                {
                    MessageBox.Show(rev.Naziv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeRevijaManekeni_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Revija r = new Revija()
                {
                    RedniBroj = 10,
                    Naziv = "Revija10",
                    Mesto = "Oslo",
                    Datum = new DateTime(2022, 1, 23),
                    Vreme = new DateTime(1, 1, 1, 1, 13, 12)

                };

                Maneken mk = new Maneken()
                {
                    JMBG = "1610006587496",
                    Ime = "Hejli",
                    Prezime = "Biber",
                    DatumRodjenja=new DateTime(1993, 12,3),
                    Pol = "Z",
                    Visina=178,
                    TezinaKG=56, 
                    BojaOciju="Braon",
                    BojaKose="Smeđa",
                    KonfekcijskiBroj="s",
                    Tip = "M"
            };
                r.ListaManekena.Add(mk);
                mk.ListaRevija.Add(r);

                s.Save(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdMkMko_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ModniKreator mko = s.Load<ModniKreator>(23);
                ModniKreator mk = s.Load<ModniKreator>(24);
                string proba="";
                
                foreach (ModniKreator m in mko.ListaPozvanihKreatora)
                {
                    MessageBox.Show(m.Ime + " " + m.Prezime);
                }

                foreach (ModniKreator m in mk.ListaKreatoraKojiSuZvali)
                {
                    MessageBox.Show(m.Ime + " " + m.Prezime);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeZemalja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Agencija ag = new Entiteti.Agencija()
                {
                    Pib = 53,
                    Naziv = "MIM",
                    Sediste = "MINHEN",
                    DatumOsnivanja = new DateTime(1, 1, 1, 3, 14, 1),
                    Tip = 'I'
                };
                Zemlja z1 = new Zemlja()
                {
                    Naziv = "Francuska",
                    AgencijaId = ag
                };
                Zemlja z2 = new Zemlja()
                {
                    Naziv = "Spanija",
                    AgencijaId = ag
                };
                Zemlja z3 = new Zemlja()
                {
                    Naziv = "Nemacka",
                    AgencijaId=ag
                    
                };
               // z1.AgencijaId = ag;
               // z2.AgencijaId = ag;
               // z3.AgencijaId = ag;

                ag.listaZemalja.Add(z1);
                ag.listaZemalja.Add(z2);
                ag.listaZemalja.Add(z3);

                s.Save(ag);
                s.Flush();
                s.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDDodavanjeVlasnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.ModnaKuca mk = new Entiteti.ModnaKuca()
                {
                    Naziv = "Versace",
                    ImeOsnivaca = "Djani Versace",
                    SedisteKuce = "Italija"
            };
                VlasniciMK v1 = new VlasniciMK()
                {
                    ImeVlasnika = "Donatela Versace",
                    JedBroj = mk
                };
                VlasniciMK v2 = new VlasniciMK()
                {
                    ImeVlasnika = "Alegra Versace",
                    JedBroj = mk
                }; 
                VlasniciMK v3 = new VlasniciMK()
                {
                    ImeVlasnika = "Danijel Versace",
                    JedBroj = mk
                };


                mk.listaVlasnika.Add(v1);
                mk.listaVlasnika.Add(v2);
                mk.listaVlasnika.Add(v3);

                s.Save(mk);
                s.Flush();
                s.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeNaslovnih_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Maneken mk = new Entiteti.Maneken()
                {
                    JMBG = "0508004857135",
                    Ime = "Adrijana",
                    Prezime = "Lima",
                    DatumRodjenja = new DateTime(1981, 6, 12),
                    Pol = "Z",
                    Visina = 178,
                    TezinaKG = 56,
                    BojaOciju = "Braon",
                    BojaKose = "Braon",
                    KonfekcijskiBroj = "s",
                    Tip = "M"
                };
                NaslovneStrane n1 = new NaslovneStrane()
                {
                    NaslovneStrana = "Vogue",
                    Maneken = mk
                };

                NaslovneStrane n2 = new NaslovneStrane()
                {
                    NaslovneStrana = "ELLE",
                    Maneken = mk
                };
                NaslovneStrane n3 = new NaslovneStrane()
                {
                    NaslovneStrana = "Harpers Bazaar",
                    Maneken = mk
                };



                mk.listaNaslovnih.Add(n1);
                mk.listaNaslovnih.Add(n2);
                mk.listaNaslovnih.Add(n3);

                s.Save(mk);
                s.Flush();
                s.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeKolekcije_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Kolekcija k = new Entiteti.Kolekcija()
                {
                    Naziv="Sun kissed",
                    Opis= "Letnji sarenolik",
                    Sezona="Leto"


                    
                };
                Revija r = new Revija()
                {
                    RedniBroj=11,
                    Naziv = "Sun kissed runway",
                    Mesto = "Venecija",
                    Datum = new DateTime(2021, 1,19),
                    Vreme = new DateTime(1,1,1,1,12,5),

                };

                k.Revija = r;
                r.Kolekcija = k;

                s.Save(k);
                s.Flush();
                s.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdModnaKucaRevija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kolekcija k = s.Load<Kolekcija>(3);
                MessageBox.Show(k.Naziv);
                MessageBox.Show(k.ModnaKuca.Naziv);
                MessageBox.Show(k.Revija.Naziv);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeMkMko_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.ModniKreator mno = new Entiteti.ModniKreator();
                mno.JMBG = "0412005475682";
                mno.Ime = "Ralf";
                mno.Prezime = "Loren";
                mno.Pol = "M";
                mno.ZemljaPorekla = "SAD";
                mno.DatumRodjenja = new DateTime(1969, 8, 7);

                Entiteti.ModniKreator mn1 = new Entiteti.ModniKreator();
                mn1.JMBG = "0509998471236";
                mn1.Ime = "Stela";
                mn1.Prezime = "Mekartni";
                mn1.Pol = "Z";
                mn1.ZemljaPorekla = "Engleska";
                mn1.DatumRodjenja = new DateTime(1983, 8, 7);

                Entiteti.ModniKreator mn2 = new Entiteti.ModniKreator();
                mn2.JMBG = "0714975253698";
                mn2.Ime = "Manolo";
                mn2.Prezime = "Blahnik";
                mn2.Pol = "M";
                mn2.ZemljaPorekla = "SAD";
                mn2.DatumRodjenja = new DateTime(1964, 8, 7);


                Entiteti.ModniKreator mn3 = new Entiteti.ModniKreator();
                mn3.JMBG = "0506007854512";
                mn3.Ime = "Aleksandar";
                mn3.Prezime = "Mekvin";
                mn3.Pol = "M";
                mn3.ZemljaPorekla = "Engleska";
                mn3.DatumRodjenja = new DateTime(1969, 3, 17);





                mno.ListaPozvanihKreatora.Add(mn1);
                mno.ListaPozvanihKreatora.Add(mn2);
                mno.ListaPozvanihKreatora.Add(mn3);

                mn1.ListaKreatoraKojiSuZvali.Add(mno);
                mn2.ListaKreatoraKojiSuZvali.Add(mno);
                mn3.ListaKreatoraKojiSuZvali.Add(mno);



                s.Save(mno);

                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
