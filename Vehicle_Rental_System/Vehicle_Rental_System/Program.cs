using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime start1 = new DateTime(2024, 6, 3);
            DateTime end1 = new DateTime(2024, 6, 13);

            DateTime start2 = new DateTime(2024, 6, 3);
            DateTime end2 = new DateTime(2024, 6, 13);

            DateTime start3 = new DateTime(2024, 6, 3);
            DateTime end3 = new DateTime(2024, 6, 18);

            Customer custumer1 = new Customer("John", "Doe", 28, 5);
            Customer custumer2 = new Customer("Mary", "Johnson", 20, 2);
            Customer custumer3 = new Customer("John", "Markson", 28, 8);


            Vehicle car1 = new Car("Mitsubishi", "Mirage", 15000.00, 3);
            car1.RentVehicle(custumer1, start1, end1);
            car1.ReturnVehicle();
            
            Vehicle motorcycle1 = new Motorcycle("Triumph", "Tiger Sport 660", 10000.00);
            motorcycle1.RentVehicle(custumer2, start2, end2);
            motorcycle1.ReturnVehicle();

            Vehicle van1 = new Cargo_Van("Mitsubishi", "Mirage", 20000.00);
            van1.RentVehicle(custumer3, start3, end3);
            van1.ReturnVehicle();


            Console.ReadLine();
        }
    }
}
