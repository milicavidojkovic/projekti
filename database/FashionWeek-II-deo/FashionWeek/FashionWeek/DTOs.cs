using FashionWeek.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace FashionWeek
{
    #region Agencija
    public class AgencijaPregled
    {
        public int Pib;
        public string Naziv;
        public string Sediste;
        public DateTime DatumOsnivanja;
        public char Tip;

        public AgencijaPregled() { }

        public AgencijaPregled(int pib, string naziv, string sediste, DateTime datumOsnivanja, char tip)
        {
            Pib = pib;
            Naziv = naziv;
            Sediste = sediste;
            DatumOsnivanja = datumOsnivanja;
            Tip = tip;
        }
    }
    public class AgencijaBasic
    {
        public int Pib;
        public string Naziv;
        public string Sediste;
        public DateTime DatumOsnivanja;
        public char Tip;

        public virtual IList<ManekenBasic> listaManekena { get; set; }
        public virtual IList<ZemljaBasic> listaZemalja { get; set; }

        public AgencijaBasic()
        {
            listaManekena = new List<ManekenBasic>();
            listaZemalja = new List<ZemljaBasic>();
        }
        public AgencijaBasic(int pib, string naziv, string sediste, DateTime datumOsnivanja, char tip)
        {
            Pib = pib;
            Naziv = naziv;
            Sediste = sediste;
            DatumOsnivanja = datumOsnivanja;
            Tip = tip;
        }
    }
    #endregion
    #region Kolekcija
    public class KolekcijaPregled
    {
        public int Id;
        public string Naziv;
        public string Opis;
        public string Sezona;


        public KolekcijaPregled() { }
        public KolekcijaPregled(int id, string naziv, string opis, string sezona)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            Sezona = sezona;
        }
    }
    public class KolekcijaBasic
    {
        public int Id;
        public string Naziv;
        public string Opis;
        public string Sezona;
        public RevijaBasic Revija;
        public ModnaKucaBasic ModnaKuca;

        public KolekcijaBasic() { }

        public KolekcijaBasic(int id, string naziv, string opis, string sezona)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            Sezona = sezona;
        }
    }
    #endregion
    #region Maneken
    public class ManekenPregled
    {
        public string JMBG;
        public string Ime;
        public string Prezime;
        public DateTime DatumRodjenja;
        public string Pol;
        public int Visina;
        public int TezinaKG;
        public string BojaOciju;
        public string BojaKose;
        public string Zanimanje;
        public string KonfekcijskiBroj;
        public string Tip;

        public ManekenPregled() { }

        public ManekenPregled(string jMBG, string ime, string prezime, DateTime datumRodjenja, string pol, int visina, int tezinaKG, string bojaOciju, string bojaKose, string zanimanje, string konfekcijskiBroj, string tip)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            Visina = visina;
            TezinaKG = tezinaKG;
            BojaOciju = bojaOciju;
            BojaKose = bojaKose;
            Zanimanje = zanimanje;
            KonfekcijskiBroj = konfekcijskiBroj;
            Tip = tip;
        }
    }
    public class ManekenBasic
    {
        public string JMBG;
        public string Ime;
        public string Prezime;
        public DateTime DatumRodjenja;
        public string Pol;
        public int Visina;
        public int TezinaKG;
        public string BojaOciju;
        public string BojaKose;
        public string Zanimanje;
        public string KonfekcijskiBroj;
        public string Tip;
        public AgencijaBasic Agencija;
        public virtual IList<RevijaBasic> ListaRevija { get; set; }
        public virtual IList<NaslovneStraneBasic> listaNaslovnih { get; set; }

        public ManekenBasic()
        {
            ListaRevija = new List<RevijaBasic>();
            listaNaslovnih = new List<NaslovneStraneBasic>();
        }
        public ManekenBasic(string jMBG, string ime, string prezime, DateTime datumRodjenja, string pol, int visina, int tezinaKG, string bojaOciju, string bojaKose, string zanimanje, string konfekcijskiBroj, string tip)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            Visina = visina;
            TezinaKG = tezinaKG;
            BojaOciju = bojaOciju;
            BojaKose = bojaKose;
            Zanimanje = zanimanje;
            KonfekcijskiBroj = konfekcijskiBroj;
            Tip = tip;
        }
    }
    #endregion
    #region ModnaKuca
    public class ModnaKucaPregled
    {
        public int KucaId;
        public string Naziv;
        public string ImeOsnivaca;
        public string SedisteKuce;

        public ModnaKucaPregled()
        { }
        public ModnaKucaPregled(int kucaID, string naziv, string sedisteKuce, string imeOsnivaca)
        {
            this.KucaId = kucaID;
            this.Naziv = naziv;
            this.SedisteKuce = sedisteKuce;
            this.ImeOsnivaca = imeOsnivaca;
        }
    }
    public class ModnaKucaBasic
    {
        public int KucaId;
        public string ImeOsnivaca;
        public string SedisteKuce;
        public string Naziv;

        public virtual IList<ModniKreatorBasic> listaKreatora { get; set; }
        public virtual IList<VlasniciMKBasic> listaVlasnika { get; set; }

        public virtual IList<KolekcijaBasic> listaKolekcija { get; set; }

        public ModnaKucaBasic()
        {
            listaKreatora = new List<ModniKreatorBasic>();
            listaVlasnika = new List<VlasniciMKBasic>();
            listaKolekcija = new List<KolekcijaBasic>();
        }
        public ModnaKucaBasic(int kucaId, string imeOsnivaca, string sedisteKuce, string naziv)
        {
            this.KucaId = kucaId;
            this.ImeOsnivaca = imeOsnivaca;
            this.SedisteKuce = sedisteKuce;
            this.Naziv = naziv;
        }
    }
    #endregion
    #region ModniKreator
    public class ModniKreatorPregled
    {
        public int Id;
        public string JMBG;
        public string Ime;
        public string Prezime;
        public string ZemljaPorekla;
        public DateTime DatumRodjenja;
        public string Pol;
        public ModniKreatorPregled(int Id, string Ime, string Prezime,
            string ZemljaPorekla, string Pol)
        {
            this.Id = Id;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.ZemljaPorekla = ZemljaPorekla;
            this.Pol = Pol;
        }
    }
    public class ModniKreatorBasic
    {
        public int Id;
        public string JMBG;
        public string Ime;
        public string Prezime;
        public string ZemljaPorekla;
        public DateTime DatumRodjenja;
        public string Pol;
        public ModnaKucaBasic modnaKuca;
        public virtual IList<RevijaBasic> ListaOrganizovanihRevija { get; set; }
        public virtual IList<RevijaBasic> ListaUstvovanihRevija { get; set; }
        public virtual IList<ModniKreatorBasic> ListaKreatoraKojiSuZvali { get; set; }
        public virtual IList<ModniKreatorBasic> ListaPozvanihKreatora { get; set; }

        public ModniKreatorBasic()
        {
            ListaOrganizovanihRevija = new List<RevijaBasic>();
            ListaUstvovanihRevija = new List<RevijaBasic>();

            ListaKreatoraKojiSuZvali = new List<ModniKreatorBasic>();
            ListaPozvanihKreatora = new List<ModniKreatorBasic>();

        }
        public ModniKreatorBasic(int Id, string JMBG, string Ime, string Prezime,
            string ZemljaPorekla, DateTime DatumRodjenja, string Pol)
        {
            this.Id = Id;
            this.JMBG = JMBG;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.ZemljaPorekla = ZemljaPorekla;
            this.DatumRodjenja = DatumRodjenja;
            this.Pol = Pol;
        }

    }
    #endregion
    #region NaslovnaStrana
    public class NaslovneStranePregled
    {
        public int Id;
        public string NaslovneStrane;


        public NaslovneStranePregled(int Id, string NaslovneStrane)
        {
            this.Id = Id;
            this.NaslovneStrane = NaslovneStrane;

        }

    }
    public class NaslovneStraneBasic
    {
        public int Id;
        public string NaslovneStrane;
        public ManekenBasic Maneken;

        public NaslovneStraneBasic(int Id, string NaslovneStrane, ManekenBasic Maneken)
        {
            this.Id = Id;
            this.NaslovneStrane = NaslovneStrane;
            this.Maneken = Maneken;
        }

    }
    #endregion
    #region Revija
    public class RevijaPregled
    {
        public int RedniBroj;
        public string Naziv;
        public string Mesto;
        public DateTime Datum;
        public DateTime Vreme;

        public RevijaPregled()
        {

        }
        public RevijaPregled(int rbr, string naziv, string mesto, DateTime datum, DateTime vreme)
        {
            this.RedniBroj = rbr;
            this.Naziv = naziv;
            this.Datum = datum;
            this.Vreme = vreme;
        }
    }

    public class RevijaBasic
    {
        public int RedniBroj;
        public string Naziv;
        public string Mesto;
        public DateTime Datum;
        public DateTime Vreme;
        public ModniKreatorBasic KreatorOrganizator;
        public string PrvaRevija;
        public virtual IList<ModniKreatorBasic> ListaKreatoraUcesnika { get; set; }
        public virtual IList<ManekenBasic> ListaManekena { get; set; }

        public RevijaBasic()
        {
            ListaKreatoraUcesnika = new List<ModniKreatorBasic>();
            ListaManekena = new List<ManekenBasic>();
        }
        public RevijaBasic(int rbr, string naziv, string mesto, DateTime datum, DateTime vreme)
        {
            this.RedniBroj = rbr;
            this.Naziv = naziv;
            this.Datum = datum;
            this.Vreme = vreme;
        }
    }
    #endregion
    #region VlasniciMK
    public class VlasniciMKPregled
    {
        public int Id;
        public string ImeVlasnika;
        public VlasniciMKPregled()
        {

        }
        public VlasniciMKPregled(int id, string imeVl)
        {
            this.Id = id;
            this.ImeVlasnika = imeVl;
        }
    }

    public class VlasniciMKBasic
    {
        public int Id;
        public string ImeVlasnika;
        public virtual ModnaKucaBasic JedBroj { get; set; }

        public VlasniciMKBasic()
        {
        }

        public VlasniciMKBasic(int id, string imeVl)
        {
            this.Id = id;
            this.ImeVlasnika = imeVl;
        }
    }
    #endregion
    #region Zemlja
    public class ZemljaBasic
    {
        public int Id;
        public string ImeVlasnika;
        public ModnaKucaBasic JedBroj;

        public ZemljaBasic(int Id, string ImeVlasnika, ModnaKucaBasic JedBroj)
        {
            this.Id = Id;
            this.ImeVlasnika = ImeVlasnika;
            this.JedBroj = JedBroj;
        }

        public ZemljaBasic()
        {

        }
    }
    public class ZemljaPregled
    {
        public int Id;
        public string ImeVlasnika;

        public ZemljaPregled(int Id, string ImeVlasnika)
        {
            this.Id = Id;
            this.ImeVlasnika = ImeVlasnika;

        }

    }
    #endregion
}
