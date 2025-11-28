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
    public class BMIApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BMIApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/BMIApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BMI>>> GetBMIs(){
            return await _context.BMIs.ToListAsync();
        }
        // GET: api/BMIApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BMI>> GetBMI(int id){
            var bmi = await _context.BMIs.FindAsync(id);
            if(bmi == null){
                return NotFound();
            }
            return bmi;
        }
        // POST: api/BMIApi
        [HttpPost]
        public async Task<ActionResult<BMI>> PostBMI(BMI bmi){
            _context.BMIs.Add(bmi);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBMI), new { id = bmi.BMI_ID }, bmi);
        }
        // PUT: api/BMIApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBMI(int id, BMI bmi){
            if(id != bmi.BMI_ID){
                return BadRequest();
            }
            _context.Entry(bmi).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.BMIs.Any(e => e.BMI_ID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/BMIApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBMI(int id){
            var bmi = await _context.BMIs.FindAsync(id);
            if(bmi == null){
                return NotFound();
            }
            _context.BMIs.Remove(bmi);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}