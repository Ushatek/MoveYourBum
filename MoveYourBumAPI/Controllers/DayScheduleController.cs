using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayScheduleController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public DayScheduleController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/DaySchedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayScheduleForView>>> GetDaySchedule()
        {
          if (_context.DaySchedule == null)
          {
              return NotFound();
          }
            //return await _context.DaySchedule.ToListAsync();
            return (await _context.DaySchedule
                    .Include(sch => sch.Day)
                    .Include(sch => sch.Schedule).ThenInclude(sch => sch.ScheduleExercises).ThenInclude(sch => sch.Exercise)
                    .ToListAsync()).Where(sch => sch.IsActive == true)
                    .Select(daySchedule => (DayScheduleForView)daySchedule)
                    .ToList();
        }

        // GET: api/DaySchedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayScheduleForView>> GetDaySchedule(int id)
        {
          if (_context.DaySchedule == null)
          {
              return NotFound();
          }
            //var daySchedule = await _context.DaySchedule.FindAsync(id);
            var daySchedule = (DayScheduleForView)(await _context?.DaySchedule?
                 .Include(sch => sch.Day)
                 .Include(sch => sch.Schedule).ThenInclude(sch => sch.ScheduleExercises).ThenInclude(sch => sch.Exercise)
                .FirstOrDefaultAsync(daySchedule => daySchedule.Id == id));
            

            if (daySchedule == null)
            {
                return NotFound();
            }

            return Ok(daySchedule);
        }

        // PUT: api/DaySchedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DayScheduleForView>> PutDaySchedule(int id, DayScheduleForView daySchedule)
        {
            if (id != daySchedule.Id)
            {
                return BadRequest();
            }

            if (_context.DaySchedule == null)
            {
                return NotFound();
            }

            _context.DaySchedule.Update((DaySchedule)daySchedule);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/DaySchedule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayScheduleForView>> PostDaySchedule(DayScheduleForView daySchedule)
        {
          if (_context.DaySchedule == null)
          {
              return Problem("Entity set 'MoveYourBumContext.DaySchedule'  is null.");
          }
            _context.DaySchedule.Add((DaySchedule)daySchedule);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDaySchedule", new { id = daySchedule.Id }, daySchedule);
            return Ok(daySchedule);
        }

        // DELETE: api/DaySchedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaySchedule(int id)
        {
            if (_context.DaySchedule == null)
            {
                return NotFound();
            }
            var daySchedule = await _context.DaySchedule.FindAsync(id);
            if (daySchedule == null)
            {
                return NotFound();
            }
            daySchedule.IsActive = false;
            //_context.DaySchedule.Remove(daySchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayScheduleExists(int id)
        {
            return (_context.DaySchedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
