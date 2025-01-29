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

    if (vehicle.Price <= 0)
    {
        return BadRequest("El precio debe ser un valor positivo.");
    }

    _context.Vehicles.Add(vehicle);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
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
        if (id != vehicle.Id)
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



    [HttpGet("filter")]
public ActionResult<IEnumerable<Vehicle>> FilterVehicles(
    [FromQuery] string make = null,
    [FromQuery] string model = null,
    [FromQuery] int? yearStart = null,
    [FromQuery] int? yearEnd = null,
    [FromQuery] decimal? priceStart = null,
    [FromQuery] decimal? priceEnd = null,
    [FromQuery] string city = null,
    [FromQuery] string condition = null,
    [FromQuery] string transmissionType = null,
    [FromQuery] string color = null)
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(make))
    {
        query = query.Where(v => v.Make.Contains(make));
    }

    if (!string.IsNullOrEmpty(model))
    {
        query = query.Where(v => v.Model.Contains(model));
    }

    if (yearStart.HasValue)
    {
        query = query.Where(v => v.Year >= yearStart.Value);
    }

    if (yearEnd.HasValue)
    {
        query = query.Where(v => v.Year <= yearEnd.Value);
    }

    if (priceStart.HasValue)
    {
        query = query.Where(v => v.Price >= priceStart.Value);
    }

    if (priceEnd.HasValue)
    {
        query = query.Where(v => v.Price <= priceEnd.Value);
    }

    if (!string.IsNullOrEmpty(city))
    {
        query = query.Where(v => v.City.Contains(city));
    }

    if (!string.IsNullOrEmpty(condition))
    {
        query = query.Where(v => v.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(transmissionType))
    {
        query = query.Where(v => v.TransmissionType.Contains(transmissionType));
    }

    if (!string.IsNullOrEmpty(color))
    {
        query = query.Where(v => v.Color.Contains(color));
    }

    var vehicles = query.ToList();
    
    return Ok(vehicles);
}

}
