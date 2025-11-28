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
    public class AboutApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AboutApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/AboutApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutUS>>> GetAbouts(){
            return await _context.Abouts.ToListAsync();
        }
        // GET: api/AboutApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutUS>> GetAbout(int id){
            var about = await _context.Abouts.FindAsync(id);
            if(about == null){
                return NotFound();
            }
            return about;
        }
        // POST: api/AboutApi
        [HttpPost]
        public async Task<ActionResult<AboutUS>> PostAbout(AboutUS about){
            _context.Abouts.Add(about);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAbout), new { id = about.AboutID }, about);
        }
        // PUT: api/AboutApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbout(int id, AboutUS about){
            if(id != about.AboutID){
                return BadRequest();
            }
            _context.Entry(about).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Abouts.Any(e => e.AboutID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/AboutApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id){
            var about = await _context.Abouts.FindAsync(id);
            if(about == null){
                return NotFound();
            }
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}