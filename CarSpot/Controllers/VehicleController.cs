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
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();  // Método sincrónico
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
}
