using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class VlasniciMK
    {
        public virtual int Id { get; protected set; }
        public virtual string  ImeVlasnika { get; set; }
        public virtual ModnaKuca JedBroj { get; set; }

        public VlasniciMK()
        {
        }
    }
}
