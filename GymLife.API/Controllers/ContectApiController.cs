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
    public class ContectApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ContectApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/ContectApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contect>>> GetContects(){
            return await _context.Contects.ToListAsync();
        }
        // GET: api/ContectApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Contect>> GetContect(int id){
            var contect = await _context.Contects.FindAsync(id);
            if(contect == null){
                return NotFound();
            }
            return contect;
        }
        // POST: api/ContectApi
        [HttpPost]
        public async Task<ActionResult<Contect>> PostContect(Contect contect){
            _context.Contects.Add(contect);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContect), new { id = contect.ContectID }, contect);
        }
        // PUT: api/ContectApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContect(int id, Contect contect){
            if(id != contect.ContectID){
                return BadRequest();
            }
            _context.Entry(contect).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Contects.Any(e => e.ContectID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/ContectApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContect(int id)
        {
            var contect = await _context.Contects.FindAsync(id);
            if (contect == null)
            {
                return NotFound();
            }
            _context.Contects.Remove(contect);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // GET: api/ContectApi/GetContact
        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact()
        {
            var contact=await(from u in _context.Contects
            join i in _context.Users
            on u.Email equals i.Email
            select new
            {
                i.AD,
                i.Soyad,
                u.Message,
                i.Resim
            }).ToListAsync();
            return Ok(contact);
        }
    }
}