using System.ComponentModel.DataAnnotations.Schema;

namespace MoveYourBumAPI.Models
{
    //tabela z ćwiczeniami. Ma swoją nazwę np. uginanie ramion z opisami. Zawiera kolekcje zdjęć a także może należeć do wielu treningów.
    public class Exercise : DictionaryTable
    {
        public string? ProperTechniqueDescription { get; set; }
        public string? MuscleInvolvedDescription { get; set; }
        //każde ćwiczenie należy do jednego rodzaju ćeiczenia np. ręce, nogi, kardio
        public int IdExerciseType { get; set; }
        [ForeignKey("IdExerciseType")]
        public virtual ExerciseType? ExerciseType { get; set; }

        public virtual ICollection<ExercisePhoto>? Photos { get; set; }
    }
}
