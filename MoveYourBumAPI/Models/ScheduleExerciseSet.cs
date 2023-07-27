using System.ComponentModel.DataAnnotations.Schema;

namespace MoveYourBumAPI.Models
{
    public class ScheduleExerciseSet : BaseDatabase
    {
        public string? PlannedReps { get; set; }
        public string? ActualReps { get; set; }
        public string? WeightUsed { get; set; }

        //każda seria należy do konkretnego ćwiczenia z planu
        public int IdScheduleExercise { get; set; }
        [ForeignKey("IdScheduleExercise")]

        public virtual ScheduleExercise? ScheduleExercise { get; set; }

        //i do konkretnego dayschedule
        public int? IdDaySchedule { get; set; }//nullowalne polaczenie
        [ForeignKey("IdDaySchedule")]

        public virtual DaySchedule? DaySchedule { get; set; }
    }
}
