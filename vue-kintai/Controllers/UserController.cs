using Microsoft.AspNetCore.Mvc;
using vue_kintai.Data;
using vue_kintai.Models;

namespace vue_kintai.Controllers
{
    [Route("vue-kintai / [controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.User.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null) return NotFound();

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
