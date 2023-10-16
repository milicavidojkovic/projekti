using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    public class NaslovneStrane
    {
        public virtual int Id { get; protected set; }
        public virtual string NaslovneStrana { get; set; }
        public virtual  Maneken Maneken { get; set; }

        public NaslovneStrane()
        {
        }
    }
}
