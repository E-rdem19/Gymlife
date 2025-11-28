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
    public class InformationApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InformationApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/InformationApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Information_Panel>>> GetInformations(){
            return await _context.Information_Panels.ToListAsync();
        }
        // GET: api/InformationApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Information_Panel>> GetInformation(int id){
            var information = await _context.Information_Panels.FindAsync(id);
            if(information == null){
                return NotFound();
            }
            return information;
        }
        // POST: api/InformationApi
        [HttpPost]
        public async Task<ActionResult<Information_Panel>> PostInformation(Information_Panel information){
            _context.Information_Panels.Add(information);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInformation), new { id = information.InfoID }, information);
        }
        // PUT: api/InformationApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformation(int id, Information_Panel information){
            if(id != information.InfoID){
                return BadRequest();
            }
            _context.Entry(information).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/InformationApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformation(int id){
            var information = await _context.Information_Panels.FindAsync(id);
            if(information == null){
                return NotFound();
            }
            _context.Information_Panels.Remove(information);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
