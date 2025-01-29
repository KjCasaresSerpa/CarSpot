public class Vehicle
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; } 
    public string Condition { get; set; }
    public string TransmissionType { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }
    public string CabinType { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
