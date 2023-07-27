using System.ComponentModel.DataAnnotations.Schema;

namespace MoveYourBumAPI.Models
{
    public class DaySchedule : BaseDatabase
    {
        //tabela łącząca realizujaca relacje wiele do wielu
        //ten sam plan może należeć do wielu dni a plan ćwiczeń może mieć wiele ćwiczeń
        public int IdDay { get; set; }
        [ForeignKey("IdDay")]
        public virtual Day? Day { get; set; }

        //a plan ćwiczeń może mieć wiele ćwiczeń
        public int IdSchedule { get; set; }
        [ForeignKey("IdSchedule")]
        public virtual Schedule? Schedule { get; set; }
    }
}
