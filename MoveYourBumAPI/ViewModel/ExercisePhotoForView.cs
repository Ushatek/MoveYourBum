using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class ExercisePhotoForView : BaseDatabase
    {
        public string? FileName { get; set; }
        public string FileUrl { get; set; } = null!;
        public int IdExercise { get; set; }
        public string? ExerciseName { get; set; }

        public static explicit operator ExercisePhoto(ExercisePhotoForView forView)
        {
            var result = new ExercisePhoto
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator ExercisePhotoForView(ExercisePhoto ing)
        {
            var result = new ExercisePhotoForView
            {
                ExerciseName = ing?.Exercise?.Name ?? String.Empty,
            }
            .CopyProperties(ing);
            return result;
        }
    }
}
