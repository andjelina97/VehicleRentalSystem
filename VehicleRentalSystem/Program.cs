using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice();
            Car car = new Car(3, "Mitsubishi", "Mirage", 15000.00, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13), "John Doe");
            Motorcycle motorcycle = new Motorcycle(20, "Triumph", "Tiger Sport 660", 10000, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13), "Mary Johnson");
            CargoVan cargoVan = new CargoVan(8, "Citroen", "Jumper", 20000, new DateTime(2024, 6, 3), new DateTime(2024, 6, 18), new DateTime(2024, 6, 13), "John Markson");
            List<Vehicle> vehicles = new List<Vehicle>() { car, motorcycle, cargoVan };

            foreach(Vehicle vehicle in vehicles)
            {
                invoice.GenerateRentalInvoice(vehicle);
            }
        }
    }
}
