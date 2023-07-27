using System.ComponentModel.DataAnnotations.Schema;

namespace MoveYourBumAPI.Models
{
    public class ScheduleExercise : BaseDatabase
    {
        public string? Annotation { get; set; }
        //należy do konkretnego planu treningowego
        public int IdSchedule { get; set; }
        [ForeignKey("IdSchedule")]
        public virtual Schedule? Schedule { get; set; }

        //odnosci się do konkretnego ćwiczenia
        public int IdExercise { get; set; }
        [ForeignKey("IdExercise")]
        public virtual Exercise? Exercise { get; set; }

        //moze zawierac wiele serii
        public virtual ICollection<ScheduleExerciseSet>? Sets { get; set; }
    }
}
