using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymLife.API.Data;
using GymLife.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymLife.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GalleryApiController : ControllerBase
    {
       public readonly  ApplicationDbContext _context;

        public GalleryApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/GalleryApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gallery>>> GetGalleries()
        {
            return await _context.Galleries.ToListAsync();
        }
        // GET: api/GalleryApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Gallery>> GetGallery(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return gallery;
        }
        // POST: api/GalleryApi
        [HttpPost]
        public async Task<ActionResult<Gallery>> PostGallery(Gallery gallery)
        {
            _context.Galleries.Add(gallery);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGallery), new { id = gallery.GalleryId }, gallery);
        }
        // PUT: api/GalleryApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallery(int id, Gallery gallery)
        {
            if (id != gallery.GalleryId)
            {
                return BadRequest();
            }

            _context.Entry(gallery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/GalleryApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}