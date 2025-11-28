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
    public class PackageApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PackageApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/PackageApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package_Table>>> GetPackages(){
            return await _context.Package_Tables.ToListAsync();
        }
        // GET: api/PackageApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Package_Table>> GetPackage(int id){
            var package = await _context.Package_Tables.FindAsync(id);
            if(package == null){
                return NotFound();
            }
            return package;
        }
        // POST: api/PackageApi
        [HttpPost]
        public async Task<ActionResult<Package_Table>> PostPackage(Package_Table package){
            _context.Package_Tables.Add(package);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPackage), new { id = package.PackageID }, package);
        }
        // PUT: api/PackageApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package_Table package){
            if(id != package.PackageID){
                return BadRequest();
            }
            _context.Entry(package).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Package_Tables.Any(e => e.PackageID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/PackageApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id){
            var package = await _context.Package_Tables.FindAsync(id);
            if(package == null){
                return NotFound();
            }
            _context.Package_Tables.Remove(package);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}