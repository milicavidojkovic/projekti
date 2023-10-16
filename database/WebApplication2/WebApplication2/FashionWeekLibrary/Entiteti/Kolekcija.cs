using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class Kolekcija
    {
        internal protected virtual int Id { get; protected set; }
        internal protected virtual string? Naziv { get; set; }
        internal protected virtual string? Opis { get; set; }
        internal protected virtual string? Sezona { get; set; }
        internal protected virtual Revija? Revija { get; set; }

        public virtual ModnaKuca? ModnaKuca { get; set; }
       

        internal Kolekcija()
        {
        
            
        }
        
      
    }
}
