using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class DayScheduleForView : BaseDatabase
    {
        public int IdDay { get; set; }
        public DateTime? DayDate { get; set; }
        public int IdSchedule { get; set; }
        public string? ScheduleName { get; set; }
        public string? ScheduleDescription { get; set; }


        public virtual ICollection<ScheduleExerciseForView>? ScheduleExercises { get; set; }

        public static explicit operator DaySchedule(DayScheduleForView forView)
        {
            var result = new DaySchedule
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator DayScheduleForView(DaySchedule daySchedule)
        {
            var result = new DayScheduleForView
            {
                ScheduleExercises = daySchedule?.Schedule?.ScheduleExercises?
                .Select(exe => (ScheduleExerciseForView)exe).ToList() ?? new List<ScheduleExerciseForView>(),

                DayDate = daySchedule?.Day?.Date ?? DateTime.Now,
                ScheduleName = daySchedule?.Schedule?.Name ?? String.Empty,
                ScheduleDescription = daySchedule?.Schedule?.Description ?? String.Empty,
            }
            .CopyProperties(daySchedule);
            return result;
        }
    }
}
