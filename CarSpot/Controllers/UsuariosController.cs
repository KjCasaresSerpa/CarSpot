


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
    public ActionResult<User> CrearUsuario(User user)
{
    _context.Users.Add(user);
    _context.SaveChanges();

    return CreatedAtAction(nameof(CrearUsuario), new { id = user.Id }, user);
}


    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsuarios()
    {
    var usuarios = _context.Users.ToList();

    return Ok(usuarios);
    }


        
    [HttpGet("{id}")]
    public ActionResult<User> GetUsuario(int id)
    {
    var usuario = _context.Users.Find(id);

    if (usuario == null)
    {
        return NotFound();
    }

    return Ok(usuario);
    }


        
    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
    {
    var usuario = _context.Users.Find(id);

    if (usuario == null)
    {
        return NotFound();
    }

    _context.Users.Remove(usuario);
    _context.SaveChanges();

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
    

        


   
    




