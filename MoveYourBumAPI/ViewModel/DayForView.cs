using MoveYourBumAPI.Helpers;
using MoveYourBumAPI.Models;

namespace MoveYourBumAPI.ViewModel
{
    public class DayForView : BaseDatabase
    {
        public DateTime? Date { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<DayScheduleForView>? DaySchedules { get; set; }

        public static implicit operator Day(DayForView forView)
        {
            var result = new Day
            {
                DaySchedules = forView?.DaySchedules?
                .Select(exe => (DaySchedule)exe).ToList() ?? new List<DaySchedule>()
            }
            .CopyProperties(forView);
            return result;
        }
        public static explicit operator DayForView(Day day)
        {
            var result = new DayForView
            {
                DaySchedules = day?.DaySchedules?
                .Select(exe => (DayScheduleForView)exe).ToList()
                ?? new List<DayScheduleForView>()
            }
            .CopyProperties(day);
            return result;
        }
    }
}
