using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymLife.API.Data;
using Microsoft.EntityFrameworkCore;
using GymLife.API.Models;

namespace GymLife.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UsersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers(){
            return await _context.Users.ToListAsync();
        }
        // GET: api/UsersApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            return user;
        }
        // POST: api/UsersApi
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user){
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.KullaniciID }, user);
        }
        // PUT: api/UsersApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users user){
            if(id != user.KullaniciID){
                return BadRequest();
            }
            _context.Entry(user).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Users.Any(e => e.KullaniciID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/UsersApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}