using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
     public class Vehicle
    {

        public string brand;
        public string model;
        public double value;

        public int rentalPeriodInDays;
        public Customer rider;

        public DateTime reservationDateStart;
        public DateTime reservationDateEnd;
        public DateTime returnDate;
        public int actualRentalPeriodInDays;



        protected double rentalCostPerDay;
        protected double rentalCost;
        protected double insuranceCost;
        protected double insuranceCostPerDay;

        protected double totalCost;

        public Vehicle(string b, string m, double value)
        {
            this.brand = b;
            this.model = m;
            this.value = value;

            rentalPeriodInDays = 0;
            rider = null;

            this.rentalCostPerDay=0;
            this.rentalCost=0;
            this.insuranceCost=0;
            this.insuranceCostPerDay=0;
            this.totalCost=0;


        }


        public void RentVehicle(Customer customer, DateTime start, DateTime end)
        {
            if (rider == null)
            {
                this.rider = customer;
                this.reservationDateStart = start;
                this.reservationDateEnd = end;
                
                this.rentalPeriodInDays = (reservationDateEnd - reservationDateStart).Days;
            }


        }
        public void ReturnVehicle()
        {
            //realno koriscenje --- this.returnDate = DateTime.Now;

            //stavljeno radi lakseg testiranja razlicitih situacija bez obzira kog dana se vrsi testiranje
            this.returnDate = new DateTime(2024, 6, 13);


            this.actualRentalPeriodInDays = (this.returnDate - this.reservationDateStart).Days;
            Invoice invoice = new Invoice();
            invoice.RentalInvoice(this);



            this.rider = null;
            this.reservationDateStart = new DateTime();
            this.reservationDateEnd = new DateTime();
            this.actualRentalPeriodInDays = 0;
            this.rentalPeriodInDays = 0;
        }
    






}
}
