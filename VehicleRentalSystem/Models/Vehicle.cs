using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Models
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double VehicleValue { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public double DailyRentalCost { get; set; }
        public double DailyInsuranceCost { get; set; }
        public double InitialDailyInsuranceCost { get; set; }
        public double? AdditionToInitialInsuranceCost { get; set; }
        public double? DiscountToInitialInsuranceCost { get; set; }
        public string CustomerName { get; set; }

        public Vehicle(string brand, string model, double vehicleValue, DateTime rentalStartDate, DateTime rentalEndDate, DateTime actualReturnDate, string customerName)
        {
            Brand = brand;
            Model = model;
            VehicleValue = vehicleValue;
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
            ActualReturnDate = actualReturnDate;
            CustomerName = customerName;
        }
    }
}
