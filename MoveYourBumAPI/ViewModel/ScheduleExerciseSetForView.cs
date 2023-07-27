using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class ScheduleExerciseSetForView : BaseDatabase
    {
        public string? PlannedReps { get; set; }
        public string? ActualReps { get; set; }
        public string? WeightUsed { get; set; }

        public int IdScheduleExercise { get; set; }
        public string? ScheduleExerciseName { get; set; }

        public int? IdDaySchedule { get; set; }
        public string? DayScheduleName { get; set; }

        public static explicit operator ScheduleExerciseSet(ScheduleExerciseSetForView forView)
        {
            var result = new ScheduleExerciseSet
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator ScheduleExerciseSetForView(ScheduleExerciseSet scheduleExerciseSet)
        {
            var result = new ScheduleExerciseSetForView
            {
                ScheduleExerciseName = scheduleExerciseSet?.ScheduleExercise?.Exercise?.Name ?? String.Empty,
                DayScheduleName = scheduleExerciseSet?.DaySchedule?.Schedule?.Name ?? String.Empty,
            }
            .CopyProperties(scheduleExerciseSet);
            return result;
        }
    }
}
