
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

  


        [HttpGet]
        public ActionResult<List<Establecimiento>> ObtenerEstablecimientos()
        {
            return Ok(_establecimientos);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Establecimiento> ObtenerEstablecimientoPorId(int id)
        {
            var establecimiento = _establecimientos.FirstOrDefault(e => e.Id == id);

            if (establecimiento == null)
                return NotFound($"Establecimiento con ID {id} no encontrado.");

            return Ok(establecimiento);
        }

        [HttpPost]
        public ActionResult<Establecimiento> CrearEstablecimiento(Establecimiento establecimiento)
        {
           
            if (_establecimientos.Any(e => e.Id == establecimiento.Id))
                return BadRequest("Ya existe un establecimiento con este ID.");

            _establecimientos.Add(establecimiento);
            return CreatedAtAction(nameof(ObtenerEstablecimientoPorId), new { id = establecimiento.Id }, establecimiento);
        }

        
        [HttpPut("{id}")]
        public ActionResult ActualizarEstablecimiento(int id, Establecimiento establecimientoActualizado)
        {
            var establecimiento = _establecimientos.FirstOrDefault(e => e.Id == id);

            if (establecimiento == null)
                return NotFound($"Establecimiento con ID {id} no encontrado.");

            establecimiento.NombreFiscal = establecimientoActualizado.NombreFiscal;
            establecimiento.Direccion = establecimientoActualizado.Direccion;
            establecimiento.Tipo = establecimientoActualizado.Tipo;
            establecimiento.UsuarioCreadorId = establecimientoActualizado.UsuarioCreadorId;
            establecimiento.Telefono = establecimientoActualizado.Telefono;
            establecimiento.CorreoElectronico = establecimientoActualizado.CorreoElectronico;
            establecimiento.FechaRegistro = establecimientoActualizado.FechaRegistro;
            establecimiento.EstaActivo = establecimientoActualizado.EstaActivo;
            establecimiento.ProductosServicios = establecimientoActualizado.ProductosServicios;
            establecimiento.NotasAdicionales = establecimientoActualizado.NotasAdicionales;

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarEstablecimiento(int id)
        {
            var establecimiento = _establecimientos.FirstOrDefault(e => e.Id == id);

            if (establecimiento == null)
                return NotFound($"Establecimiento con ID {id} no encontrado.");

            _establecimientos.Remove(establecimiento);
            return NoContent(); 
        }
    }
}
