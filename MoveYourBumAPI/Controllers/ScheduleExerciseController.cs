using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleExerciseController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public ScheduleExerciseController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleExercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleExerciseForView>>> GetScheduleExercise()
        {
          if (_context.ScheduleExercise == null)
          {
              return NotFound();
          }
            //return await _context.ScheduleExercise.ToListAsync();
            return (await _context.ScheduleExercise
                    .Include(sch => sch.Sets).Include(sch => sch.Exercise).Where(sch => sch.IsActive == true).ToListAsync())
                    .Select(scheduleExercise => (ScheduleExerciseForView)scheduleExercise)
                    .ToList();
        }

        // GET: api/ScheduleExercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleExerciseForView>> GetScheduleExercise(int id)
        {
          if (_context.ScheduleExercise == null)
          {
              return NotFound();
          }
            var scheduleExercise = (ScheduleExerciseForView)(await _context?.ScheduleExercise?
                .Include(sch => sch.Sets)?.Include(sch => sch.Exercise)?
                .FirstOrDefaultAsync(scheduleExercise => scheduleExercise.Id == id));

            if (scheduleExercise == null)
            {
                return NotFound();
            }

            return scheduleExercise;
        }

        // PUT: api/ScheduleExercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleExerciseForView>> PutScheduleExercise(int id, ScheduleExerciseForView scheduleExercise)
        {
            if (id != scheduleExercise.Id)
            {
                return BadRequest();
            }

            if (_context.ScheduleExercise == null)
            {
                return NotFound();
            }
            _context.ScheduleExercise.Update((ScheduleExercise)scheduleExercise);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ScheduleExercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleExerciseForView>> PostScheduleExercise(ScheduleExerciseForView scheduleExercise)
        {
          if (_context.ScheduleExercise == null)
          {
              return Problem("Entity set 'MoveYourBumContext.ScheduleExercise'  is null.");
          }
            _context.ScheduleExercise.Add((ScheduleExercise)scheduleExercise);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetScheduleExercise", new { id = scheduleExercise.Id }, scheduleExercise);
            return Ok(scheduleExercise);
        }

        // DELETE: api/ScheduleExercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleExercise(int id)
        {
            if (_context.ScheduleExercise == null)
            {
                return NotFound();
            }
            var scheduleExercise = await _context.ScheduleExercise.FindAsync(id);
            if (scheduleExercise == null)
            {
                return NotFound();
            }
            scheduleExercise.IsActive = false;
            //_context.ScheduleExercise.Remove(scheduleExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExerciseExists(int id)
        {
            return (_context.ScheduleExercise?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
