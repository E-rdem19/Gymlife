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
    public class CommunicationApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommunicationApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/CommunicationApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Communication>>> GetCommunications(){
            return await _context.Communications.ToListAsync();
        }
        // GET: api/CommunicationApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Communication>> GetCommunication(int id){
            var communication = await _context.Communications.FindAsync(id);
            if(communication == null){
                return NotFound();
            }
            return communication;
        }
        // POST: api/CommunicationApi
        [HttpPost]
        public async Task<ActionResult<Communication>> PostCommunication(Communication communication){
            _context.Communications.Add(communication);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCommunication), new { id = communication.CommunicationID }, communication);
        }
        // PUT: api/CommunicationApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunication(int id, Communication communication){
            if(id != communication.CommunicationID){
                return BadRequest();
            }
            _context.Entry(communication).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Communications.Any(e => e.CommunicationID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/CommunicationApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunication(int id){
            var communication = await _context.Communications.FindAsync(id);
            if(communication == null){
                return NotFound();
            }
            _context.Communications.Remove(communication);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}