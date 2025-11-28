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
    public class InstructorApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InstructorApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/InstructorApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructors(){
            return await _context.Instructors.ToListAsync();
        }
        // GET: api/InstructorApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id){
            var instructor = await _context.Instructors.FindAsync(id);
            if(instructor == null){
                return NotFound();
            }
            return instructor;
        
        }
        // POST: api/InstructorApi
        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructor(Instructor instructor){
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInstructor), new { id = instructor.EgitmenID }, instructor);
        }
        // PUT: api/InstructorApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, Instructor instructor){
            if(id != instructor.EgitmenID){
                return BadRequest();
            }
            _context.Entry(instructor).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Instructors.Any(e => e.EgitmenID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/InstructorApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id){
            var instructor = await _context.Instructors.FindAsync(id);
            if(instructor == null){
                return NotFound();
            }
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
