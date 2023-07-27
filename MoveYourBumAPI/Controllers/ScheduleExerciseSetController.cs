using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleExerciseSetController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public ScheduleExerciseSetController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleExerciseSet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleExerciseSetForView>>> GetScheduleExerciseSet()
        {
            if (_context.ScheduleExerciseSet == null)
            {
                return NotFound();
            }
            //return await _context.ScheduleExerciseSet.ToListAsync();
            return (await _context.ScheduleExerciseSet
                    .Include(sch => sch.ScheduleExercise).Include(sch => sch.DaySchedule).ToListAsync()).Where(sch => sch.IsActive == true)
                    .Select(scheduleExerciseSet => (ScheduleExerciseSetForView)scheduleExerciseSet)
                    .ToList();
        }

        // GET: api/ScheduleExerciseSet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleExerciseSetForView>> GetScheduleExerciseSet(int id)
        {
            if (_context.ScheduleExerciseSet == null)
            {
                return NotFound();
            }
            var scheduleExerciseSet = (ScheduleExerciseSetForView)(await _context?.ScheduleExerciseSet?
                .Include(sch => sch.ScheduleExercise)?.Include(sch => sch.DaySchedule)?
                .FirstOrDefaultAsync(scheduleExerciseSet => scheduleExerciseSet.Id == id));

            if (scheduleExerciseSet == null)
            {
                return NotFound();
            }

            return Ok(scheduleExerciseSet);
        }

        // PUT: api/ScheduleExerciseSet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleExerciseSetForView>> PutScheduleExerciseSet(int id, ScheduleExerciseSetForView scheduleExerciseSet)
        {
            if (id != scheduleExerciseSet.Id)
            {
                return BadRequest();
            }
            if (_context.ScheduleExerciseSet == null)
            {
                return NotFound();
            }
            _context.ScheduleExerciseSet.Update((ScheduleExerciseSet)scheduleExerciseSet);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ScheduleExerciseSet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleExerciseSetForView>> PostScheduleExerciseSet(ScheduleExerciseSetForView scheduleExerciseSet)
        {
            if (_context.ScheduleExerciseSet == null)
            {
                return Problem("Entity set 'MoveYourBumContext.ScheduleExerciseSet'  is null.");
            }
            _context.ScheduleExerciseSet.Add((ScheduleExerciseSet)scheduleExerciseSet);
            await _context.SaveChangesAsync();

            return Ok(scheduleExerciseSet);
        }

        // DELETE: api/ScheduleExerciseSet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleExerciseSet(int id)
        {
            if (_context.ScheduleExerciseSet == null)
            {
                return NotFound();
            }
            var scheduleExerciseSet = await _context.ScheduleExerciseSet.FindAsync(id);
            if (scheduleExerciseSet == null)
            {
                return NotFound();
            }
            scheduleExerciseSet.IsActive = false;
            //_context.ScheduleExerciseSet.Remove(scheduleExerciseSet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExerciseSetExists(int id)
        {
            return (_context.ScheduleExerciseSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
