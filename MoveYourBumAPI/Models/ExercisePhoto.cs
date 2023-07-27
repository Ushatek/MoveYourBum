using System.ComponentModel.DataAnnotations.Schema;

namespace MoveYourBumAPI.Models
{
    //tabela zawiera jedno zdjecie - należy do jednego ćwiczenia, tak by to ćwiczenie mogło mieć wiele zdjęć
    public class ExercisePhoto : BaseDatabase
    {
        public string? FileName { get; set; }
        public string FileUrl { get; set; } = null!;

        //klucz obcy
        public int IdExercise { get; set; }
        [ForeignKey("IdExercise")]
        public virtual Exercise? Exercise { get; set; }
    }
}
