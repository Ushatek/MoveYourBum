using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveYourBumAPI.Data;
using MoveYourBumAPI.Models;
using MoveYourBumAPI.ViewModel;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly MoveYourBumContext _context;

        public DayController(MoveYourBumContext context)
        {
            _context = context;
        }

        // GET: api/Day
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayForView>>> GetDay()
        {
          if (_context.Day == null)
          {
              return NotFound();
          }
            //return await _context.Day.ToListAsync();
            return (await _context.Day
                    .Include(sch => sch.DaySchedules)
                    .ThenInclude(mel => mel.Schedule)
                    .Where(sch => sch.IsActive == true).ToListAsync())
                    .Select(day => (DayForView)day)
                    .ToList();
        }

        // GET: api/Day/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayForView>> GetDay(int id)
        {
          if (_context.Day == null)
          {
              return NotFound();
          }
            //var day = await _context.Day.FindAsync(id);
            var day = (DayForView)(await _context?.Day?
                .Include(sch => sch.DaySchedules)?
                .ThenInclude(mel => mel.Schedule)
                .FirstOrDefaultAsync(day => day.Id == id));

            if (day == null)
            {
                return NotFound();
            }

            return Ok(day);
        }

        // PUT: api/Day/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DayForView>> PutDay(int id, DayForView day)
        {
            if (id != day.Id)
            {
                return BadRequest();
            }

            if (_context.Day == null)
            {
                return NotFound();
            }
            _context.Day.Update((Day)day);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Day
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayForView>> PostDay(DayForView day)
        {
          if (_context.Day == null)
          {
              return Problem("Entity set 'MoveYourBumContext.Day'  is null.");
          }
            _context.Day.Add(day);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDay", new { id = day.Id }, day);
            return Ok(day);
        }

        // DELETE: api/Day/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            if (_context.Day == null)
            {
                return NotFound();
            }
            var day = await _context.Day.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }
            day.IsActive = false;
            //_context.Day.Remove(day);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayExists(int id)
        {
            return (_context.Day?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
