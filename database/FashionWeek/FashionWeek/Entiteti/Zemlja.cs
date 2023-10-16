using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class Zemlja
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual Agencija AgencijaId { get; set; }

        public Zemlja() { 
        }
            
    }
}
