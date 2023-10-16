using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class Zemlja
    {
        internal protected virtual int Id { get; protected set; }
        internal protected virtual string? Naziv { get; set; }
        internal protected virtual Agencija? AgencijaId { get; set; }

        internal Zemlja() { 
        }
            
    }
}
