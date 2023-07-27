using System.ComponentModel.DataAnnotations;

namespace MoveYourBumAPI.Models
{
    //plan treningowy - może być używane wielokrotnie. Zawiera wiele ćwiczeń a także może należeć do wielu różnych dni np. co
    //poniedziałek robimy te same ćwiczenia
    public class Schedule : BaseDatabase
    {
        [Required(ErrorMessage = "Schedule should have a name!")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ScheduleExercise>? ScheduleExercises { get; set; }
        public virtual ICollection<DaySchedule>? DaySchedules { get; set; }
    }
}
