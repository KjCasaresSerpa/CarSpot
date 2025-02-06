using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly AppDbContext _context;

    public VehicleController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpPost]
public ActionResult<Vehicle> CreateVehicle(Vehicle vehicle)
    {

    if (string.IsNullOrEmpty(vehicle.Make) || string.IsNullOrEmpty(vehicle.Model))
    {
        return BadRequest("La marca y el modelo son obligatorios.");
    }

    if (vehicle.PriceStart <= 0)
    {
        return BadRequest("El precio debe ser un valor positivo.");
    }

    _context.Vehicles.Add(vehicle);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.UserId }, vehicle);
    }


    
[HttpGet("{id}")]
public ActionResult<Vehicle> GetVehicle(int id)
    {
        var vehicle = _context.Vehicles.Find(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return vehicle;
    }

    
[HttpPut("{id}")]
public IActionResult UpdateVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.UserId)
        {
            return BadRequest();
        }

        _context.Entry(vehicle).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    
[HttpDelete("{id}")]
public IActionResult DeleteVehicle(int id)
    {
        var vehicle = _context.Vehicles.Find(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        _context.SaveChanges();

        return NoContent();
    }

    
[HttpGet("user/{userId}")]
public ActionResult<IEnumerable<Vehicle>> GetUserVehicles(int userId)
    
    {
        var vehicles = _context.Vehicles.Where(v => v.UserId == userId).ToList();
        return Ok(vehicles);
    }




[Route("filter-by-make")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByMake([FromQuery] string make)
{
    if (string.IsNullOrEmpty(make))
    {
        return BadRequest("Debe proporcionar una marca para filtrar.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByMake(make);

    return Ok(filteredVehicles);
}




   
[Route("filter-by-model")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByModel([FromQuery] string model)
{
    if (string.IsNullOrEmpty(model))
    {
        return BadRequest("Debe proporcionar un modelo para filtrar.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByModel(model);

    return Ok(filteredVehicles);
}



[Route("filter-by-year")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByYear([FromQuery] int year)
{
    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByYear(year);

    return Ok(filteredVehicles);
}


[Route("filter-by-price")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByPrice([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
{
    if (minPrice < 0 || maxPrice < 0)
    {
        return BadRequest("El precio debe ser un valor positivo.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByPrice(minPrice, maxPrice);

    return Ok(filteredVehicles);
}


[Route("filter-by-city")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByCity([FromQuery] string city)
{
    if (string.IsNullOrEmpty(city))
    {
        return BadRequest("Debe proporcionar una ciudad para filtrar.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByCity(city);

    return Ok(filteredVehicles);
}

[Route("filter-by-condition")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByCondition([FromQuery] string condition)
{
    if (string.IsNullOrEmpty(condition))
    {
        return BadRequest("Debe proporcionar una condición para filtrar.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByCondition(condition);

    return Ok(filteredVehicles);
}

[Route("filter-by-transmission")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByTransmission([FromQuery] string transmissionType)
{
    if (string.IsNullOrEmpty(transmissionType))
    {
        return BadRequest("Debe proporcionar un tipo de transmisión para filtrar.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByTransmission(transmissionType);

    return Ok(filteredVehicles);
}


[Route("filter-by-color")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterByColor([FromQuery] string color)
{
    if (string.IsNullOrEmpty(color))
    {
        return BadRequest("Debe proporcionar un color para filtrar.");
    }

    var vehicleService = new VehicleService();
    var filteredVehicles = vehicleService.FilterByColor(color);

    return Ok(filteredVehicles);
}




}

