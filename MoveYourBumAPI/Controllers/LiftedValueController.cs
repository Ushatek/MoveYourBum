using Microsoft.AspNetCore.Mvc;
using MoveYourBumAPI.Data;

namespace MoveYourBumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftedValueController : ControllerBase
    {
        private readonly MoveYourBumContext _context;
        public LiftedValueController(MoveYourBumContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("LiftedValueOfExercise")]
        public async Task<ActionResult<int>> LiftedValueOfExercise(int idScheduleExercise, int idDaySchedule)
        {
            
            var lifted = _context.ScheduleExerciseSet?.Where(sch => sch.IsActive == true).ToList();
            return (from lif
                     in lifted
                    where idScheduleExercise == lif.IdScheduleExercise 
                    && idDaySchedule == lif.IdDaySchedule
                    select int.Parse(lif.ActualReps) * int.Parse(lif.WeightUsed)
                    ).Sum();
        }
        [HttpGet]
        [Route("LiftedValueOfSchedule")]
        public async Task<ActionResult<int>> LiftedValueOfSchedule(int idDaySchedule)
        {
            var lifted = _context.ScheduleExerciseSet?.Where(sch => sch.IsActive == true).ToList();
            return (from lif
                     in lifted
                    where idDaySchedule == lif.IdDaySchedule
                    select int.Parse(lif.ActualReps) * int.Parse(lif.WeightUsed)
                    ).Sum();
        }
    }
}
