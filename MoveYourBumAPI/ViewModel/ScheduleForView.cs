using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class ScheduleForView : BaseDatabase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ScheduleExerciseForView>? ScheduleExercises { get; set; }
        public virtual ICollection<DayScheduleForView>? DaySchedules { get; set; }

        public static explicit operator Schedule(ScheduleForView forView)
        {
            var result = new Schedule
            {
                ScheduleExercises = forView?.ScheduleExercises?
                .Select(exe => (ScheduleExercise)exe).ToList() ?? new List<ScheduleExercise>(),
                DaySchedules = forView?.DaySchedules?
                .Select(exe => (DaySchedule)exe).ToList() ?? new List<DaySchedule>()
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator ScheduleForView(Schedule schedule)
        {
            var result = new ScheduleForView
            {
                ScheduleExercises = schedule?.ScheduleExercises?
                .Select(exe => (ScheduleExerciseForView)exe).ToList() ?? new List<ScheduleExerciseForView>(),
                DaySchedules = schedule?.DaySchedules?
                .Select(exe => (DayScheduleForView)exe).ToList() ?? new List<DayScheduleForView>()
            }
            .CopyProperties(schedule);
            return result;
        }
    }
}
