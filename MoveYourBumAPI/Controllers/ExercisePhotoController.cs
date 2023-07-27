using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisePhotoController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public ExercisePhotoController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/ExercisePhoto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercisePhotoForView>>> GetExercisePhoto()
        {
          if (_context.ExercisePhoto == null)
          {
              return NotFound();
          }
            return (await _context.ExercisePhoto
                    .ToListAsync()).Where(exe => exe.IsActive == true)
                    .Select(exercise => (ExercisePhotoForView)exercise)
                    .ToList();
        }

        // GET: api/ExercisePhoto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExercisePhotoForView>> GetExercisePhoto(int id)
        {
          if (_context.ExercisePhoto == null)
          {
              return NotFound();
          }
            var exercisePhoto = (ExercisePhotoForView)(await _context?.ExercisePhoto?
                .FirstOrDefaultAsync(exercisePhoto => exercisePhoto.Id == id));

            if (exercisePhoto == null)
            {
                return NotFound();
            }

            return Ok(exercisePhoto);
        }

        // PUT: api/ExercisePhoto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ExercisePhotoForView>> PutExercisePhoto(int id, ExercisePhotoForView exercisePhoto)
        {
            if (id != exercisePhoto.Id)
            {
                return BadRequest();
            }
            if (_context.ExercisePhoto == null)
            {
                return NotFound();
            }

            _context.ExercisePhoto.Update((ExercisePhoto)exercisePhoto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ExercisePhoto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExercisePhotoForView>> PostExercisePhoto(ExercisePhotoForView exercisePhoto)
        {
          if (_context.ExercisePhoto == null)
          {
              return Problem("Entity set 'MoveYourBumContext.ExercisePhoto'  is null.");
          }
            _context.ExercisePhoto.Add((ExercisePhoto)exercisePhoto);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetExercisePhoto", new { id = exercisePhoto.Id }, exercisePhoto);
            return Ok(exercisePhoto);
        }

        // DELETE: api/ExercisePhoto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercisePhoto(int id)
        {
            if (_context.ExercisePhoto == null)
            {
                return NotFound();
            }
            var exercisePhoto = await _context.ExercisePhoto.FindAsync(id);
            if (exercisePhoto == null)
            {
                return NotFound();
            }
            exercisePhoto.IsActive = false;
            //_context.ExercisePhoto.Remove(exercisePhoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercisePhotoExists(int id)
        {
            return (_context.ExercisePhoto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
