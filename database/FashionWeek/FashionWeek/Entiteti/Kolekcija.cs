using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class Kolekcija
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Sezona { get; set; } 
        public virtual Revija Revija { get; set; }

        public virtual ModnaKuca ModnaKuca { get; set; }
       

        public Kolekcija()
        {
        
            
        }
        
      
    }
}
