using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionWeek.DTOs
{
    public class FashionWeekView
    {
        public virtual IList<ModnaKucaView>? ModneKuce { get; set; }
        public virtual IList<ModniKreatorView>? ModniKreatori { get; set; }
        public virtual IList<RevijaView>? Revije { get; set; }

        public FashionWeekView()
        {
            ModneKuce = new List<ModnaKucaView>();
            ModniKreatori = new List<ModniKreatorView>();
            Revije = new List<RevijaView>();
        }

    }
}
