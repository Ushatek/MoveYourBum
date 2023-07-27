using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class ExerciseTypeForView : BaseDatabase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<ExerciseForView>? Exercises { get; set; }
        public static implicit operator ExerciseType(ExerciseTypeForView forView)
        {
            var result = new ExerciseType
            {
                Exercises = forView?.Exercises?
                .Select(ing => (Exercise)ing).ToList() ?? new List<Exercise>()
            }
            .CopyProperties(forView);
            return result;
        }
        public static explicit operator ExerciseTypeForView(ExerciseType exerciseType)
        {
            var result = new ExerciseTypeForView
            {
                Exercises = exerciseType?.Exercises?
                .Select(ing => (ExerciseForView)ing).ToList()
                ?? new List<ExerciseForView>()
            }
            .CopyProperties(exerciseType);
            return result;
        }
    }
}
