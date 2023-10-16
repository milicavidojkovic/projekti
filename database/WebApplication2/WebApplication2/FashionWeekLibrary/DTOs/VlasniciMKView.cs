using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class VlasniciMKView
    {
        public int Id { get; set; }
        public string? ImeVlasanika { get; set; }
        public ModnaKucaView? ModnaKuca { get; set; }
        public string? ImeModneKuce { get; set; }

        public VlasniciMKView()
        {

        }
        internal VlasniciMKView(VlasniciMK? vmk)
        {
            if (vmk != null)
            {
                Id = vmk.Id;
                ImeVlasanika = vmk.ImeVlasnika;
                ImeModneKuce = vmk.JedBroj?.Naziv;
            }
        }

        internal VlasniciMKView(ModnaKuca? mk)
        {
            ModnaKuca = new ModnaKucaView(mk);
        }
    }
}
