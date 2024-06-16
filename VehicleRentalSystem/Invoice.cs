using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    public class Invoice
    {
        public Invoice()
        {

        }

        public void GenerateRentalInvoice(Vehicle vehicle)
        {
            int intendedRentalPeriod = (vehicle.RentalEndDate - vehicle.RentalStartDate).Days;
            int actualRentalPeriod = (vehicle.ActualReturnDate - vehicle.RentalStartDate).Days;
            double totalRentalCost, totalInsuranceCost;
            double? rentEarlyDiscount = null; 
            double? insuranceEarlyDiscount = null;

            if (intendedRentalPeriod > actualRentalPeriod)
            {
                int daysNotUsed = intendedRentalPeriod - actualRentalPeriod;
                rentEarlyDiscount = (vehicle.DailyRentalCost / 2) * daysNotUsed;
                totalRentalCost = (double)actualRentalPeriod * vehicle.DailyRentalCost + (double)rentEarlyDiscount;
                totalInsuranceCost = (double)actualRentalPeriod * vehicle.DailyInsuranceCost;
                insuranceEarlyDiscount = daysNotUsed * vehicle.DailyInsuranceCost;
            }
            else
            {
                totalRentalCost = (double)actualRentalPeriod * vehicle.DailyRentalCost;
                totalInsuranceCost = (double)actualRentalPeriod * vehicle.DailyInsuranceCost;
            }

            PrintOutput(vehicle, intendedRentalPeriod, actualRentalPeriod, totalRentalCost, totalInsuranceCost, rentEarlyDiscount, insuranceEarlyDiscount);
        }

        private void PrintOutput(Vehicle vehicle, int intendedRentalPeriod, int actualRentalPeriod, double totalRentalCost, double totalInsuranceCost, double? rentEarlyDiscount, double? insuranceEarlyDiscount) 
        {
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine($"{vehicle.ToString()}");
            Console.WriteLine($"Date: {vehicle.ActualReturnDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Customer name: {vehicle.CustomerName}");
            Console.WriteLine($"Rented vehicle: {vehicle.Brand} {vehicle.Model}");
            Console.WriteLine();
            Console.WriteLine($"Reservation start date: {vehicle.RentalStartDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Reservation end date: {vehicle.RentalEndDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Reserved rental days: {intendedRentalPeriod} days");
            Console.WriteLine();
            Console.WriteLine($"Actual return date: {vehicle.ActualReturnDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Actual rental days: {actualRentalPeriod} days");
            Console.WriteLine();
            Console.WriteLine($"Rental cost per day: ${vehicle.DailyRentalCost.ToString("0.00")}");

            if (vehicle.InitialDailyInsuranceCost != vehicle.DailyInsuranceCost)
            {
                Console.WriteLine($"Initial insurance per day: ${vehicle.InitialDailyInsuranceCost.ToString("0.00")}");
                if (vehicle.AdditionToInitialInsuranceCost != null)
                {
                    Console.WriteLine($"Insurance addition per day: ${((double)vehicle.AdditionToInitialInsuranceCost).ToString("0.00")}");
                }
                if (vehicle.DiscountToInitialInsuranceCost != null)
                {
                    Console.WriteLine($"Insurance addition per day: ${((double)vehicle.DiscountToInitialInsuranceCost).ToString("0.00")}");
                }
            }
            Console.WriteLine($"Insurance per day: ${vehicle.DailyInsuranceCost.ToString("0.00")}");
            Console.WriteLine();
            if(rentEarlyDiscount != null) 
            {
                Console.WriteLine($"Early return discount for rent: ${((double)rentEarlyDiscount).ToString("0.00")}");
            }
            if (insuranceEarlyDiscount != null)
            {
                Console.WriteLine($"Early return discount for insurance: ${((double)insuranceEarlyDiscount).ToString("0.00")}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total rent: ${totalRentalCost.ToString("0.00")}");
            Console.WriteLine($"Total insurance: ${totalInsuranceCost.ToString("0.00")}");
            Console.WriteLine($"Total: ${(totalRentalCost + totalInsuranceCost).ToString("0.00")}");
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine();
        }
    }
}
