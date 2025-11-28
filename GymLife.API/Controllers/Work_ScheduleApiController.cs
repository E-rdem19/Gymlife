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
    public class Work_ScheduleApiController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
        public Work_ScheduleApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Work_ScheduleApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work_Schedule>>> GetWork_Schedules(){
            return await _context.Work_Schedules.ToListAsync();
        }
        // GET: api/Work_ScheduleApi/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Work_Schedule>> GetWork_Schedule(int id){
            var work_schedule = await _context.Work_Schedules.FindAsync(id);
            if(work_schedule == null){
                return NotFound();
            }
            return work_schedule;
        
        }
        // POST: api/Work_ScheduleApi
        [HttpPost]
        public async Task<ActionResult<Work_Schedule>> PostWork_Schedule(Work_Schedule work_schedule){
            _context.Work_Schedules.Add(work_schedule);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWork_Schedule), new { id = work_schedule.WorkID }, work_schedule);
        }
        // PUT: api/Work_ScheduleApi/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork_Schedule(int id, Work_Schedule work_schedule){
            if(id != work_schedule.WorkID){
                return BadRequest();
            }
            _context.Entry(work_schedule).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException){
                if(!_context.Work_Schedules.Any(e => e.WorkID == id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/Work_ScheduleApi/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork_Schedule(int id){
            var work_schedule = await _context.Work_Schedules.FindAsync(id);
            if(work_schedule == null){
                return NotFound();
            }
            _context.Work_Schedules.Remove(work_schedule);
            await _context.SaveChangesAsync();
            return NoContent();
        } 
    }
}