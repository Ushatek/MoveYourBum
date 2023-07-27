using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public ScheduleController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/Schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleForView>>> GetSchedule()
        {
            if (_context.Schedule == null)
            {
                return NotFound();
            }
            //return await _context.Schedule.ToListAsync();
            return (await _context.Schedule
                    .Include(sch => sch.DaySchedules)
                    .Include(sch => sch.ScheduleExercises)
                    .ThenInclude(sch => sch.Exercise)
                    .Where(sch => sch.IsActive == true).ToListAsync())
                    .Select(schedule => (ScheduleForView)schedule)
                    .ToList();
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleForView>> GetSchedule(int id)
        {
            if (_context.Schedule == null)
            {
                return NotFound();
            }
            //var schedule = await _context.Schedule.FindAsync(id);
            var schedule = (ScheduleForView)(await _context?.Schedule?
                .Include(sch => sch.DaySchedules)
                .Include(exe => exe.ScheduleExercises)?
                .ThenInclude(sch => sch.Exercise)
                .FirstOrDefaultAsync(schedule => schedule.Id == id));

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // PUT: api/Schedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleForView>> PutSchedule(int id, ScheduleForView schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            if (_context.Schedule == null)
            {
                return NotFound();
            }
            _context.Schedule.Update((Schedule)schedule);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Schedule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleForView>> PostSchedule(ScheduleForView schedule)
        {
            if (_context.Schedule == null)
            {
                return Problem("Entity set 'MoveYourBumContext.Schedule'  is null.");
            }
            _context.Schedule.Add((Schedule)schedule);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
            return Ok(schedule);
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            if (_context.Schedule == null)
            {
                return NotFound();
            }
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            schedule.IsActive = false;
            //_context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(int id)
        {
            return (_context.Schedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
