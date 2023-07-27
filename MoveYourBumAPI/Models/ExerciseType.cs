using System.ComponentModel.DataAnnotations;

namespace MoveYourBumAPI.Models
{
    //table z typem ćwiczenia. Każdy rodzaj może zawierać wiele różnych ćeiczeń np. kradio zawiera trucht, sprint, skakanie
    public class ExerciseType : BaseDatabase
    {
        [Required(ErrorMessage = "Exercise type should have a name!")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Exercise>? Exercises { get; set; }
    }
}
