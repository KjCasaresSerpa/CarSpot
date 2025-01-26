

using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
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
        
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
        var user = await _context.Users.FindAsync(request.UserId);
        if (user == null)
            {
                return NotFound("User not found");
            }


        if (!VerifyPassword(request.CurrentPassword, user.Password))
            {
                return BadRequest("Current password is incorrect");
            }

    
        user.Password = HashPassword(request.NewPassword);
        await _context.SaveChangesAsync();

        return Ok("Password changed successfully");
    }

    private bool VerifyPassword(string password, string storedHash)
        {
    
             return BCrypt.Net.BCrypt.Verify(password, storedHash);

        }

    private string HashPassword(string password)
    {
    
        return BCrypt.Net.BCrypt.HashPassword(password);

    }

    [HttpPost("block-user/{userId}")]
    public async Task<IActionResult> BlockUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                {
                    return NotFound("User not found");
                }

    
            user.IsBlocked = true;
    
            // user.BlockedUntil = DateTime.UtcNow.AddDays(30);  // Si usas una fecha para el bloqueo temporal

        await _context.SaveChangesAsync();

        return Ok("User has been blocked");
    }


       
}
    

        


   
    




