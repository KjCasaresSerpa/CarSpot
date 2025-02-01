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


[HttpPost("filter")]
public ActionResult<IEnumerable<Vehicle>> FilterVehicles([FromBody] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Make))
    {
        query = query.Where(v => v.Make.Contains(filterRequest.Make));
    }

    if (!string.IsNullOrEmpty(filterRequest.Model))
    {
        query = query.Where(v => v.Model.Contains(filterRequest.Model));
    }

    if (filterRequest.YearStart.HasValue)
    {
        query = query.Where(v => v.YearStart >= filterRequest.YearStart.Value);
    }

    if (filterRequest.YearEnd.HasValue)
    {
        query = query.Where(v => v.YearStart <= filterRequest.YearEnd.Value);
    }

    if (filterRequest.PriceStart.HasValue)
    {
        query = query.Where(v => v.PriceStart >= filterRequest.PriceStart.Value);
    }

    if (filterRequest.PriceEnd.HasValue)
    {
        query = query.Where(v => v.PriceStart <= filterRequest.PriceEnd.Value);
    }

    if (!string.IsNullOrEmpty(filterRequest.City))
    {
        query = query.Where(v => v.City.Contains(filterRequest.City));
    }

    if (!string.IsNullOrEmpty(filterRequest.Condition))
    {
        query = query.Where(v => v.Condition.Equals(filterRequest.Condition, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(filterRequest.TransmissionType))
    {
        query = query.Where(v => v.TransmissionType.Contains(filterRequest.TransmissionType));
    }

    if (!string.IsNullOrEmpty(filterRequest.Color))
    {
        query = query.Where(v => v.Color.Contains(filterRequest.Color));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[HttpPost("filter")]
public ActionResult<Vehicle> FilterVehicles1([FromBody] Vehicle filterRequest)
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Make))
    {
        query = query.Where(v => v.Make.Contains(filterRequest.Make));
    }

    if (!string.IsNullOrEmpty(filterRequest.Model))
    {
        query = query.Where(v => v.Model.Contains(filterRequest.Model));
    }

    if (filterRequest.YearStart.HasValue)
    {
        query = query.Where(v => v.YearStart >= filterRequest.YearStart.Value);
    }

    if (filterRequest.YearEnd.HasValue)
    {
        query = query.Where(v => v.YearStart <= filterRequest.YearEnd.Value);
    }

    if (filterRequest.PriceStart.HasValue)
    {
        query = query.Where(v => v.PriceStart >= filterRequest.PriceStart.Value);
    }

    if (filterRequest.PriceEnd.HasValue)
    {
        query = query.Where(v => v.PriceStart <= filterRequest.PriceEnd.Value);
    }

    if (!string.IsNullOrEmpty(filterRequest.City))
    {
        query = query.Where(v => v.City.Contains(filterRequest.City));
    }

    if (!string.IsNullOrEmpty(filterRequest.Condition))
    {
        query = query.Where(v => v.Condition.Equals(filterRequest.Condition, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(filterRequest.TransmissionType))
    {
        query = query.Where(v => v.TransmissionType.Contains(filterRequest.TransmissionType));
    }

    if (!string.IsNullOrEmpty(filterRequest.Color))
    {
        query = query.Where(v => v.Color.Contains(filterRequest.Color));
    }

    var vehicle = query.FirstOrDefault(); 

    if (vehicle == null)
    {
        return NotFound("No vehicle found matching the criteria.");
    }

    return Ok(vehicle);
}

[HttpPost("filter")]
public ActionResult<bool> FilterVehicles2([FromBody] Vehicle filterRequest)
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Make))
    {
        query = query.Where(v => v.Make.Contains(filterRequest.Make));
    }

    if (!string.IsNullOrEmpty(filterRequest.Model))
    {
        query = query.Where(v => v.Model.Contains(filterRequest.Model));
    }

    if (filterRequest.YearStart.HasValue)
    {
        query = query.Where(v => v.YearStart >= filterRequest.YearStart.Value);
    }

    if (filterRequest.YearEnd.HasValue)
    {
        query = query.Where(v => v.YearStart <= filterRequest.YearEnd.Value);
    }

    if (filterRequest.PriceStart.HasValue)
    {
        query = query.Where(v => v.PriceStart >= filterRequest.PriceStart.Value);
    }

    if (filterRequest.PriceEnd.HasValue)
    {
        query = query.Where(v => v.PriceStart <= filterRequest.PriceEnd.Value);
    }

    if (!string.IsNullOrEmpty(filterRequest.City))
    {
        query = query.Where(v => v.City.Contains(filterRequest.City));
    }

    if (!string.IsNullOrEmpty(filterRequest.Condition))
    {
        query = query.Where(v => v.Condition.Equals(filterRequest.Condition, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(filterRequest.TransmissionType))
    {
        query = query.Where(v => v.TransmissionType.Contains(filterRequest.TransmissionType));
    }

    if (!string.IsNullOrEmpty(filterRequest.Color))
    {
        query = query.Where(v => v.Color.Contains(filterRequest.Color));
    }

    bool anyVehicles = query.Any(); 

    return Ok(anyVehicles);
}

}
