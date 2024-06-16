namespace VehicleRentalSystem.Models
{
    public class CargoVan : Vehicle
    {
        public int DriversYearsOfExperience { get; set; }

        public CargoVan(int driversYearsOfExperience, string brand, string model, double vehicleValue, DateTime rentalStartDate, DateTime rentalEndDate, DateTime actualReturnDate,string customerName)
            : base(brand, model, vehicleValue, rentalStartDate, rentalEndDate, actualReturnDate, customerName)
        {
            DriversYearsOfExperience = driversYearsOfExperience;
            DailyRentalCost = (rentalEndDate - rentalStartDate).Days <= 7 ? 50 : 40;
            InitialDailyInsuranceCost = 0.0003 * vehicleValue;
            DiscountToInitialInsuranceCost = 0.15 * InitialDailyInsuranceCost;
            DailyInsuranceCost = driversYearsOfExperience <= 5 ? InitialDailyInsuranceCost : InitialDailyInsuranceCost - (double)DiscountToInitialInsuranceCost;
        }

        public override string ToString()
        {
            return $"A Cargo van that is valued at ${VehicleValue.ToString("0.00")}, and the driver has {DriversYearsOfExperience} years of driving experience:";
        }
    }
}
