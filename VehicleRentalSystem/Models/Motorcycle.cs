namespace VehicleRentalSystem.Models
{
    public class Motorcycle : Vehicle
    {
        public int DriversAge { get; set; }

        public Motorcycle(int driversAge, string brand, string model, double vehicleValue, DateTime rentalStartDate, DateTime rentalEndDate, DateTime actualReturnDate, string customerName)
            : base(brand, model, vehicleValue, rentalStartDate, rentalEndDate, actualReturnDate, customerName)
        {
            DriversAge = driversAge;
            DailyRentalCost = (rentalEndDate - rentalStartDate).Days <= 7 ? 15 : 10;
            InitialDailyInsuranceCost = 0.0002 * vehicleValue;
            AdditionToInitialInsuranceCost = 0.2 * InitialDailyInsuranceCost;
            DailyInsuranceCost = driversAge >= 25 ? InitialDailyInsuranceCost : InitialDailyInsuranceCost + (double)AdditionToInitialInsuranceCost;
        }

        public override string ToString()
        {
            return $"A Motorcycle that is valued at ${VehicleValue.ToString("0.00")}, and the driver is {DriversAge} years old:";
        }
    }
}
