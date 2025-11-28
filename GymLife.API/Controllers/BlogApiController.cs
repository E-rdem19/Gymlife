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
    public class BlogApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BlogApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/BlogApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }
        // GET: api/BlogApi/BlogDetails/ID
        [HttpGet("BlogDetails/{id}")]
        public async Task<IActionResult> GetBlogDetails(int id)
        {
            var blogDetails = await (from b in _context.Blogs
                                     join i in _context.Instructors
                                     on b.EgitmenID equals i.EgitmenID
                                     where i.BransID == id
                                     select new
                                     {
                                         b.Date,
                                         b.Title,
                                         b.Like,
                                         b.ImagePath,
                                         b.Description,
                                         i.AD,
                                         i.Soyad,

                                     }).ToListAsync();
            if (blogDetails == null || blogDetails.Count == 0)
            {
                return NotFound();

            }
            return Ok(blogDetails);
        }
        // GET: api/BlogApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id){
            var blog = await _context.Blogs.FindAsync(id);
            if(blog == null){
                return NotFound();
            }
            return blog;
        }
        // POST: api/BlogApi
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog){
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogID }, blog);
        }
        // PUT: api/BlogApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog){
            if(id != blog.BlogID){
                return BadRequest();
            }
            _context.Entry(blog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/BlogApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id){
            var blog = await _context.Blogs.FindAsync(id);
            if(blog == null){
                return NotFound();
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }       
    }
}