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
    public class ServicesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ServicesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/ServicesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        // GET: api/ServicesApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id){
            var service = await _context.Services.FindAsync(id);
            if(service == null){
                return NotFound();
            }
            return service;
        }
        // POST: api/ServicesApi
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service){
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetService), new { id = service.ServiceID }, service);
        }
        // PUT: api/ServicesApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service){
            if(id != service.ServiceID){
                return BadRequest();
            }
            _context.Entry(service).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Services.Any(e => e.ServiceID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/ServicesApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id){
            var service = await _context.Services.FindAsync(id);
            if(service == null){
                return NotFound();
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}