using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    public class Invoice
    {
        
        public void RentalInvoice(Vehicle vehicle) {

            //general information
            Console.WriteLine("XXXXXXXXX");
            Console.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("Customer name: " + vehicle.rider.name + " " + vehicle.rider.lastName);
            Console.WriteLine("Rented Vehicle: " + vehicle.brand + " " + vehicle.model);

            Console.WriteLine();

            Console.WriteLine("Reservation start date: " + vehicle.reservationDateStart.ToString("yyyy-MM-dd"));
            Console.WriteLine("Reservation end date: " + vehicle.reservationDateEnd.ToString("yyyy-MM-dd"));
            Console.WriteLine("Reserved rental days: " + vehicle.rentalPeriodInDays + " days");

            Console.WriteLine();

            Console.WriteLine("Actual return date: " + vehicle.returnDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Actual rental days: " + vehicle.actualRentalPeriodInDays+" days");

            Console.WriteLine();

            //invoice information
            TotalCost(vehicle);

            
            Console.WriteLine("XXXXXXXXX");
            Console.WriteLine();

        }
        public double RentalCostPerDay(Vehicle vehicle) {
            double dailyCost = 0.00;
            if (vehicle.rentalPeriodInDays < 8)
            {
                if (vehicle is Car) dailyCost = 20.0;
                else if (vehicle is Motorcycle) dailyCost = 15.00;
                else if(vehicle is Cargo_Van)  dailyCost = 50.00; 
              }
          else
            {
                if (vehicle is Car) dailyCost = 15.00;
                else if (vehicle is Motorcycle) dailyCost = 10.00;
                else if(vehicle is Cargo_Van)  dailyCost = 40.00; 
        }
            Console.WriteLine("Rental cost per day: $" + dailyCost.ToString("F2"));
            return dailyCost;
        }
        public double InsuranceCostPerDay(Vehicle vehicle) {
            double dailyCost = 0.00;
            double changedCost = 0.00;
            double finalCost = 0.00;
            if (vehicle is Car)
            {
                Car car = (Car)vehicle;
                dailyCost = Math.Round(car.value / 100.00 * 0.01, 2);

                if (car.safetyRating > 3)
                {
                    changedCost = Math.Round(10.00 * dailyCost / 100.00 , 2);

                    Console.WriteLine("Initial insurance per day: $" + dailyCost.ToString("F2"));
                    Console.WriteLine("Insurance discount per day: $" + changedCost.ToString("F2"));
                    
                }
                finalCost = dailyCost - changedCost;
                Console.WriteLine("Insurance per day: $" + finalCost.ToString("F2"));
            }
            else if(vehicle is Motorcycle)
            {
                dailyCost = Math.Round(vehicle.value / 100.00 * 0.02,2);

                if (vehicle.rider.age<25)
                {
                    changedCost = Math.Round(20.00 * dailyCost / 100.00,2);

                    Console.WriteLine("Initial insurance per day: $" + dailyCost.ToString("F2"));
                    Console.WriteLine("Insurance addition per day: $" + changedCost.ToString("F2"));

                }
                finalCost = dailyCost + changedCost;
                Console.WriteLine("Insurance per day: $" + finalCost.ToString("F2"));
            }
            else if(vehicle is Cargo_Van){
                dailyCost = Math.Round(vehicle.value / 100.00 * 0.03,2);

                if (vehicle.rider.experience > 5)
                {
                    changedCost = Math.Round(15.00 * dailyCost / 100.00,2);

                    Console.WriteLine("Initial insurance per day: $" + dailyCost.ToString("F2"));
                    Console.WriteLine("Insurance discount per day: $" + changedCost.ToString("F2"));

                }
                finalCost = dailyCost - changedCost;
                Console.WriteLine("Insurance per day: $" + finalCost.ToString("F2"));
            }
            return finalCost;
        }
        public void TotalCost(Vehicle vehicle) {
            double rentaldaily=RentalCostPerDay(vehicle);
            double insurancedaily=InsuranceCostPerDay(vehicle);
            double totalRent = 0.0;
            double totalInsurance = 0.0;
            double rentDiscount=0.0;
            double insuranceDiscount=0.0;

            if (vehicle.rentalPeriodInDays> vehicle.actualRentalPeriodInDays)
            {

                rentDiscount = Math.Round(rentaldaily * (vehicle.rentalPeriodInDays - vehicle.actualRentalPeriodInDays) / 2,2);
                insuranceDiscount = Math.Round(insurancedaily * (vehicle.rentalPeriodInDays - vehicle.actualRentalPeriodInDays),2);
                Console.WriteLine();
                Console.WriteLine("Early return discount for rent: $" + rentDiscount.ToString("F2"));
                Console.WriteLine("Early return discount for insurance: $" + insuranceDiscount.ToString("F2"));

            }
            totalRent = rentaldaily * vehicle.actualRentalPeriodInDays + rentDiscount;
            totalInsurance = insurancedaily * vehicle.actualRentalPeriodInDays;
            Console.WriteLine();
            Console.WriteLine("Total rent: $" + totalRent.ToString("F2"));
            Console.WriteLine("Total insurance: $" + totalInsurance.ToString("F2"));
            Console.WriteLine("Total: $" + (totalRent+totalInsurance).ToString("F2"));


        }

    }
}
