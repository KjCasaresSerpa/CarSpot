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

[Route("filter")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> FilterVehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Make))
    {
        query = query.Where(v => v.Make.Contains(filterRequest.Make));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

   
[Route("filter1")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter1Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Model))
    {
        query = query.Where(v => v.Model.Contains(filterRequest.Model));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}



[Route("filter2")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter2Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

     if (filterRequest.YearStart != null)
    {
        query = query.Where(v => v.YearStart == filterRequest.YearStart);
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter3")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter3Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

     if (filterRequest.YearEnd != null)
    {
        query = query.Where(v => v.YearEnd == filterRequest.YearEnd);
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter4")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter4Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

     if (filterRequest.PriceStart != null)
    {
        query = query.Where(v => v.PriceStart == filterRequest.PriceStart);
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter5")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter5Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

     if (filterRequest.PriceEnd != null)
    {
        query = query.Where(v => v.PriceEnd == filterRequest.PriceEnd);
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter6")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter6Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.City))
    {
        query = query.Where(v => v.City.Contains(filterRequest.City));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter7")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter7Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Condition))
    {
        query = query.Where(v => v.Condition.Contains(filterRequest.Condition));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter8")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter8Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.TransmissionType))
    {
        query = query.Where(v => v.TransmissionType.Contains(filterRequest.TransmissionType));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}

[Route("filter9")]
[HttpGet]
public ActionResult<IEnumerable<Vehicle>> Filter9Vehicles([FromQuery] Vehicle filterRequest)
    
{
    var query = _context.Vehicles.AsQueryable();

    if (!string.IsNullOrEmpty(filterRequest.Color))
    {
        query = query.Where(v => v.Color.Contains(filterRequest.Color));
    }

    var vehicles = query.ToList();

    return Ok(vehicles);
}



}

