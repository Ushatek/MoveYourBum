using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class ScheduleExerciseForView : BaseDatabase
    {
        public string? Annotation { get; set; }
        public int IdSchedule { get; set; }
        //public string? ScheduleName { get; set; }
        public int IdExercise { get; set; }
        public string? ExerciseName { get; set; }
        public virtual ICollection<ScheduleExerciseSetForView>? Sets { get; set; }

        public static explicit operator ScheduleExercise(ScheduleExerciseForView forView)
        {
            var result = new ScheduleExercise
            {
                Sets = forView?.Sets?
                .Select(exe => (ScheduleExerciseSet)exe).ToList() ?? new List<ScheduleExerciseSet>()
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator ScheduleExerciseForView(ScheduleExercise ing)
        {
            var result = new ScheduleExerciseForView
            {
                ExerciseName = ing?.Exercise?.Name ?? String.Empty,
                Sets = ing?.Sets?
                .Select(exe => (ScheduleExerciseSetForView)exe).ToList() ??
                new List<ScheduleExerciseSetForView>(),
            }
            .CopyProperties(ing);
            return result;
        }

    }
}
