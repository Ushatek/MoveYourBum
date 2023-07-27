using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class ExerciseForView : BaseDatabase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProperTechniqueDescription { get; set; }
        public string? MuscleInvolvedDescription { get; set; }
        //każde ćwiczenie należy do jednego rodzaju ćeiczenia np. ręce, nogi, kardio
        public int IdExerciseType { get; set; }
        public string? ExerciseTypeName { get; set; }
        public virtual ICollection<ExercisePhotoForView>? Photos { get; set; }

        public static explicit operator Exercise(ExerciseForView forView)
        {
            var result = new Exercise
            {
                Photos = forView?.Photos?
                .Select(exe => (ExercisePhoto)exe).ToList() ?? new List<ExercisePhoto>()
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator ExerciseForView(Exercise exercise)
        {
            var result = new ExerciseForView
            {
                ExerciseTypeName = exercise?.ExerciseType?.Name ?? String.Empty,
                Photos = exercise?.Photos?
                .Select(exe => (ExercisePhotoForView)exe).ToList() ?? 
                new List<ExercisePhotoForView>()
            }
            .CopyProperties(exercise);
            return result;
        }
    }
}
