public class VehicleService
{
   
    private static List<Vehicle> _vehicles = new List<Vehicle>
    {
        new Vehicle { UserId = 1, Make = "Toyota", Model = "Corolla", YearStart = 2022, PriceStart = 20000 },
        new Vehicle { UserId = 2, Make = "Ford", Model = "F-150", YearStart = 2021, PriceStart = 30000 },
        new Vehicle { UserId = 3, Make = "Chevrolet", Model = "Malibu", YearStart = 2020, PriceStart = 25000 },
        new Vehicle { UserId = 4, Make = "BMW", Model = "X5", YearStart = 2021, PriceStart = 50000 },
        new Vehicle { UserId = 5, Make = "Audi", Model = "A4", YearStart = 2023, PriceStart = 45000 }
    };

  
    public List<Vehicle> FilterByMake(string make)
    {
        return _vehicles.Where(v => v.Make.Contains(make, StringComparison.OrdinalIgnoreCase)).ToList();
    }


    public List<Vehicle> FilterByModel(string model)
    {
        return _vehicles.Where(v => v.Model.Contains(model, StringComparison.OrdinalIgnoreCase)).ToList();
    }


    public List<Vehicle> FilterByYear(int year)
    {
        return _vehicles.Where(v => v.YearStart == year).ToList();
    }

    
    public List<Vehicle> FilterByPrice(decimal minPrice, decimal maxPrice)
    {
        return _vehicles.Where(v => v.PriceStart >= minPrice && v.PriceStart <= maxPrice).ToList();
    }

     public List<Vehicle> FilterByCity(string city)
    {
        return _vehicles.Where(v => v.City.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
    }

     public List<Vehicle> FilterByCondition(string condition)
    {
        return _vehicles.Where(v => v.Condition.Contains(condition, StringComparison.OrdinalIgnoreCase)).ToList();
    }

     public List<Vehicle> FilterByTransmission(string transmissionType)
    {
        return _vehicles.Where(v => v.TransmissionType.Contains(transmissionType, StringComparison.OrdinalIgnoreCase)).ToList();
    }

     public List<Vehicle> FilterByColor(string color)
    {
        return _vehicles.Where(v => v.Color.Contains(color, StringComparison.OrdinalIgnoreCase)).ToList();
    }




}

