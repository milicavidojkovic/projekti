using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.Entiteti
{
    internal class NaslovneStrane
    {
        internal protected virtual int Id { get; protected set; }
        internal protected virtual string? NaslovneStrana { get; set; }
        internal protected virtual  Maneken? Maneken { get; set; }

        internal NaslovneStrane()
        {
        }
    }
}
