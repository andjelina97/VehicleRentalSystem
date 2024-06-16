namespace VehicleRentalSystem.Models
{
    public class Car : Vehicle
    {
        public int SafetyRating { get; set; }

        public Car(int safetyRating, string brand, string model, double vehicleValue, DateTime rentalStartDate, DateTime rentalEndDate, DateTime actualReturnDate, string customerName)
            : base(brand, model, vehicleValue, rentalStartDate, rentalEndDate, actualReturnDate, customerName) 
        {
            SafetyRating = safetyRating;
            DailyRentalCost = (rentalEndDate - rentalStartDate).Days <= 7 ? 20 : 15;
            InitialDailyInsuranceCost = 0.0001 * vehicleValue;
            DiscountToInitialInsuranceCost = 0.1 * InitialDailyInsuranceCost;
            DailyInsuranceCost = safetyRating <= 3 ? InitialDailyInsuranceCost : InitialDailyInsuranceCost - (double)DiscountToInitialInsuranceCost;
        }

        public override string ToString()
        {
            return $"A Car that is valued at ${VehicleValue.ToString("0.00")}, and has a security rating of {SafetyRating}:";
        }
    }
}
