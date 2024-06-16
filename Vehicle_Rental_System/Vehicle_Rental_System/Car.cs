using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    public class Car : Vehicle
    {
        public int safetyRating;

        public Car(string b, string m, double value, int sR) : base(b, m, value)
        {
            if (sR > 0 && sR < 6)
            {
                this.safetyRating = sR;
            }
        }



    }
}
