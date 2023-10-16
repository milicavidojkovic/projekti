using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class VlasniciMK
    {
        internal protected virtual int Id { get; protected set; }
        internal protected virtual string?  ImeVlasnika { get; set; }
        internal protected virtual ModnaKuca? JedBroj { get; set; }

        internal VlasniciMK()
        {
        }
    }
}
