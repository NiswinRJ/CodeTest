using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehaviourAPI.Models;
using UserBehaviourAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace UserBehaviour.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest("User ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.ContentType = user.ContentType;
            existingUser.JoiningDate = user.JoiningDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/users/search?term=xyz
        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery] string term)
        {
            var users = await _context.Users
                .AsNoTracking()
                .Where(u => u.Name.Contains(term) || u.Email.Contains(term))
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/users/contenttype/{contenttype}
        [HttpGet("contenttype/{contenttype}")]
        public async Task<IActionResult> GetUsersByContentType(string contenttype)
        {
            var users = await _context.Users
                .AsNoTracking()
                .Where(u => u.ContentType == contenttype)
                .ToListAsync();

            return Ok(users);
        }
    }
}

