using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class ZemljaView
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public AgencijaView? Agencija { get; set; }
        public string? NazivAgencije { get; set; }

        public ZemljaView() { }
        internal ZemljaView(Zemlja? z)
        {
            if (z != null)
            {
                Id = z.Id;
                Naziv = z.Naziv;
                NazivAgencije = z.AgencijaId?.Naziv;

            }
        }
        internal ZemljaView(Agencija? a)
        {
            Agencija = new AgencijaView(a);
        }
    }
    }
