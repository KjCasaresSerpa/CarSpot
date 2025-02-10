using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class EstablecimientoController : ControllerBase
{
    private readonly AppDbContext _context;

    public EstablecimientoController(AppDbContext context)
    {
        _context = context;
    }

   [HttpPost]
public ActionResult<Establecimiento> CrearEstablecimiento(Establecimiento establecimiento)
{
    if (_context.Establecimientos.Any(e => e.Id == establecimiento.Id))
    {
        return BadRequest("Ya existe un establecimiento con este ID.");
    }

    _context.Establecimientos.Add(establecimiento);
    _context.SaveChanges();

    return CreatedAtAction(nameof(ObtenerEstablecimientoPorId), new { id = establecimiento.Id }, establecimiento);
}

    [HttpGet]
    public ActionResult<List<Establecimiento>> ObtenerEstablecimientos()
    {
    
        var establecimientos = _context.Establecimientos.ToList();
        return Ok(establecimientos);
    }

    [HttpGet("{id}")]
    public ActionResult<Establecimiento> ObtenerEstablecimientoPorId(int id)
    {
        var establecimiento = _context.Establecimientos.FirstOrDefault(e => e.Id == id);

        if (establecimiento == null)
            return NotFound($"Establecimiento con ID {id} no encontrado.");

        return Ok(establecimiento);
    }

    [HttpPut("{id}")]
    public ActionResult ActualizarEstablecimiento(int id, Establecimiento establecimientoActualizado)
    {
        
        var establecimiento = _context.Establecimientos.FirstOrDefault(e => e.Id == id);

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

       
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult EliminarEstablecimiento(int id)
    {
       
        var establecimiento = _context.Establecimientos.FirstOrDefault(e => e.Id == id);

        if (establecimiento == null)
            return NotFound($"Establecimiento con ID {id} no encontrado.");

       
        _context.Establecimientos.Remove(establecimiento);
        _context.SaveChanges();

        return NoContent();
    }

     private static List<Establecimiento> establecimiento = new List<Establecimiento>
        {
            new Establecimiento { Id = 1, NombreFiscal = "Banco", Direccion = "calle 4", Tipo = 0, UsuarioCreadorId = 1, Telefono = "555555", 
            CorreoElectronico = "a@gmail.com", FechaRegistro = DateTime.Now, EstaActivo = true, ProductosServicios = "Prestamos", NotasAdicionales = "Credito Facil" },
            
        };
}
