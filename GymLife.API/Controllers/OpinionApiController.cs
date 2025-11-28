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
    public class OpinionApiController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
        public OpinionApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/OpinionApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opinion>>> GetOpinions(){
            return await _context.Opinions.ToListAsync();          
        }
        // GET: api/OpinionApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Opinion>> GetOpinion(int id){
            var opinion = await _context.Opinions.FindAsync(id);
            if(opinion == null){
                return NotFound();
            }
            return opinion;
        }
        // POST: api/OpinionApi
        [HttpPost]
        public async Task<ActionResult<Opinion>> PostOpinion(Opinion opinion){
            _context.Opinions.Add(opinion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOpinion), new { id = opinion.OpinionID }, opinion);
        }
        // PUT: api/OpinionApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpinion(int id, Opinion opinion){
            if(id != opinion.OpinionID){
                return BadRequest();
            }
            _context.Entry(opinion).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Opinions.Any(e => e.OpinionID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/ApinionApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpinion(int id){
            var opinion = await _context.Opinions.FindAsync(id);
            if(opinion == null){
                return NotFound();
            }
            _context.Opinions.Remove(opinion);
            await _context.SaveChangesAsync();
            return NoContent();
        } 
    }
}