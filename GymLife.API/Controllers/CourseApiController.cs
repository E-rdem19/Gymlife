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
    public class CourseApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CourseApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/CourseApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course_Program>>> GetCourses()
        {
            return await _context.Course_Programs.ToListAsync();
        }
        // GET: api/CourseApi/Program
        [HttpGet("Program")]
        public async Task<IActionResult> GetProgram()
        {
            var programs = await (
                from c in _context.Course_Programs
                join e in _context.Instructors
                on c.EgitmenID equals e.EgitmenID
                join s in _context.Services
                on c.ServiceID equals s.ServiceID
                select new
                {
                    c.Day,
                    c.Time,
                    c.Name,
                    c.Description,
                    e.AD,
                    e.Soyad,
                    s.ServiceName

                }).ToListAsync();
            if (programs == null || programs.Count == 0)
            {
                return NotFound();

            }
            return Ok(programs);
        }

        // GET: api/CourseApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Course_Program>> GetCourse(int id){
            var course = await _context.Course_Programs.FindAsync(id);
            if(course == null){
                return NotFound();
            }
            return course;
        }
        // POST: api/CourseApi
        [HttpPost]
        public async Task<ActionResult<Course_Program>> PostCourse(Course_Program course){
            _context.Course_Programs.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { id = course.Course_ProgramID }, course);
        }
        // PUT: api/CourseApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course_Program course){
            if(id != course.Course_ProgramID){
                return BadRequest();
            }
            _context.Entry(course).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Course_Programs.Any(e => e.Course_ProgramID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/CourseApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id){
            var course = await _context.Course_Programs.FindAsync(id);
            if(course == null){
                return NotFound();
            }
            _context.Course_Programs.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}