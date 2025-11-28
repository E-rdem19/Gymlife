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
    public class HomeApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HomeApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/HomeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home_Panel>>> GetHomes(){
            return await _context.Homes.ToListAsync();          
        }
        // GET: api/HomeApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Home_Panel>> GetHome(int id){
            var home = await _context.Homes.FindAsync(id);
            if(home == null){
                return NotFound();
            }
            return home;
        }
        // POST: api/HomeApi
        [HttpPost]
        public async Task<ActionResult<Home_Panel>> PostHome(Home_Panel home){
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHome), new { id = home.HomeID }, home);
        }
        // PUT: api/HomeApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home_Panel home){
            if(id != home.HomeID){
                return BadRequest();
            }
            _context.Entry(home).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/HomeApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(int id){
            var home = await _context.Homes.FindAsync(id);
            if(home == null){
                return NotFound();
            }
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}