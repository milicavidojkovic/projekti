using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    public class Customer
    {
        public string name;
        public string lastName;
        public int age;
        public int experience;

        List<Vehicle> rentedVehicles;

        public Customer(string n, string ln, int a, int e)
        {
            this.name = n;
            this.lastName = ln;
            this.age = a;
            this.experience = e;

            rentedVehicles = new List<Vehicle>();

        }



    }
}
