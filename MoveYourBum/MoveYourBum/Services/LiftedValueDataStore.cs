using MoveYourBum.Services.Abstract;

namespace MoveYourBum.Services
{
    public class LiftedValueDataStore : ADataStore
    {

        public int LiftedValueOfExercise(int idScheduleExercise, int idDaySchedule)
        {
            return _service.LiftedValueOfExerciseAsync(idScheduleExercise, idDaySchedule).GetAwaiter().GetResult();
        }
        public int LiftedValueOfSchedule(int idDaySchedule)
        {
            return _service.LiftedValueOfScheduleAsync(idDaySchedule).GetAwaiter().GetResult();
        }

    }
}
