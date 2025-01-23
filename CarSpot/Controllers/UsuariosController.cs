

using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpPost]
    public async Task<ActionResult<User>> CrearUsuario(User user)
    {
       
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CrearUsuario), new { id = user.Id }, user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsuarios()
    {
            
            var usuarios = await _context.Users.ToListAsync();

            return Ok(usuarios);
    }

        
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUsuario(int id)
    {
            
            var usuario = await _context.Users.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
    }

        
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
            
            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(); 
            }

            
            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
    }

        
        private static List<User> usuarios = new List<User>
        {
            new User { Id = 1, Username = "usuario1", Password = "contraseña123" },
            new User { Id = 2, Username = "usuario2", Password = "contraseña456" }
        };

        
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            
            var usuario = usuarios.Find(u => u.Username == user.Username && u.Password == user.Password);
            
            if (usuario == null)
            {
                return Unauthorized("Credenciales incorrectas");
            }

            
            return Ok("Login exitoso");
        }

       
}
    

        


   
    




