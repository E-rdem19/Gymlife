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
    public class BranchApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BranchApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/BranchApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }
        // GET: api/BranchApi/Category/ID
         [HttpGet("Category/{category}")]
public async Task<IActionResult> GetBranchCategory(int category)
{
    var categories = await (
       from u in _context.Instructors
       join b in _context.Branches
       on u.BransID equals b.BranchID
       where u.BransID == category
       select new
       {
           u.AD,
           u.Soyad,
           u.Yas,
           u.Aciklama,
           u.Resim,
           u.Email,
           u.Telefon,
           u.Facebook,
           u.Instagram,
           u.Twitter,
           u.Youtube,
           b.BranchName,
           b.Description,
           b.ResimURL
         }).ToListAsync();

    if (categories == null || categories.Count == 0)
    {
        return NotFound();
    }

    return Ok(categories);
}
        // GET: api/BranchApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(int id){
            var branch = await _context.Branches.FindAsync(id);
            if(branch == null){
                return NotFound();
            }
            return branch;
        }
        // POST: api/BranchApi
        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranch(Branch branch){
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBranch), new { id = branch.BranchID }, branch);
        }
        // PUT: api/BranchApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, Branch branch){
            if(id != branch.BranchID){
                return BadRequest();
            }
            _context.Entry(branch).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Branches.Any(e => e.BranchID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/BranchApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id){
            var branch = await _context.Branches.FindAsync(id);
            if(branch == null){
                return NotFound();
            }
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}