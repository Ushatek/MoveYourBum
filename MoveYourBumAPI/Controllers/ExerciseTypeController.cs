using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public ExerciseTypeController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseTypeForView>>> GetExerciseType()
        {
          if (_context.ExerciseType == null)
          {
              return NotFound();
          }
            return (await _context.ExerciseType
                    .Include(exe => exe.Exercises).ToListAsync()).Where(exe => exe.IsActive == true)
                    .Select(exerciseType => (ExerciseTypeForView)exerciseType)
                    .ToList();
        }

        // GET: api/ExerciseType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseTypeForView>> GetExerciseType(int id)
        {
          if (_context.ExerciseType == null)
          {
              return NotFound();
          }
            var exerciseType = (ExerciseTypeForView)(await _context?.ExerciseType?
                .Include(exe => exe.Exercises)?
                .FirstOrDefaultAsync(exerciseType => exerciseType.Id == id));

            if (exerciseType == null)
            {
                return NotFound();
            }

            return Ok(exerciseType);
        }

        // PUT: api/ExerciseType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ExerciseTypeForView>> PutExerciseType(int id, ExerciseTypeForView exerciseType)
        {
            if (id != exerciseType.Id)
            {
                return BadRequest();
            }
            if (_context.ExerciseType == null)
            {
                return NotFound();
            }
            _context.ExerciseType.Update(exerciseType);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        // POST: api/ExerciseType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseTypeForView>> PostExerciseType(ExerciseTypeForView exerciseType)
        {
          if (_context.ExerciseType == null)
          {
              return Problem("Entity set 'MoveYourBumContext.ExerciseType'  is null.");
          }
            _context.ExerciseType.Add(exerciseType);
            await _context.SaveChangesAsync();

            return Ok(exerciseType);
        }

        // DELETE: api/ExerciseType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseType(int id)
        {
            if (_context.ExerciseType == null)
            {
                return NotFound();
            }
            var exerciseType = await _context.ExerciseType.FindAsync(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            exerciseType.IsActive = false;
            //_context.ExerciseType.Remove(exerciseType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseTypeExists(int id)
        {
            return (_context.ExerciseType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
