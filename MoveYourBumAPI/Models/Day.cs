using System.ComponentModel.DataAnnotations;

namespace MoveYourBumAPI.Models
{
    public class Day : BaseDatabase
    {
        public DateTime? Date { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<DaySchedule>? DaySchedules { get; set; }
    }
}
