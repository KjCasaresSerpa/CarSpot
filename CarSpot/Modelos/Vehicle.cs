public class Vehicle
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int UserId { get; set; } 
    public User User { get; set; }
}
