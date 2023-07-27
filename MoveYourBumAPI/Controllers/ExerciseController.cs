using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public ExerciseController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/Exercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseForView>>> GetExercise()
        {
          if (_context.Exercise == null)
          {
              return NotFound();
          }
            //return (await _context.Exercise.ToListAsync()).Select(exe => (ExerciseForView)exe).ToList();
            return (await _context.Exercise
                    .Include(exe => exe.Photos).ToListAsync()).Where(exe => exe.IsActive == true)
                    .Select(exercise => (ExerciseForView)exercise)
                    .ToList();

        }

        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseForView>> GetExercise(int id)
        {
          if (_context.Exercise == null)
          {
              return NotFound();
          }
            var exercise = (ExerciseForView)(await _context?.Exercise?
                .Include(exe => exe.Photos)?
                .FirstOrDefaultAsync(exercise => exercise.Id == id));

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ExerciseForView>> PutExercise(int id, ExerciseForView exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest();
            }

            if (_context.Exercise == null)
            {
                return NotFound();
            }
            _context.Exercise.Update((Exercise)exercise);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Exercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseForView>> PostExercise(ExerciseForView exercise)
        {
          if (_context.Exercise == null)
          {
              return Problem("Entity set 'MoveYourBumContext.Exercise'  is null.");
          }
            _context.Exercise.Add((Exercise)exercise);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
            return Ok(exercise);
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            if (_context.Exercise == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            exercise.IsActive = false;
            //_context.Exercise.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseExists(int id)
        {
            return (_context.Exercise?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
