using System.ComponentModel.DataAnnotations;

namespace MoveYourBumAPI.Models
{
    //klasa bazowa z polami wspolnymi dla wszystkich innych tabel
    public class BaseDatabase
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
    }
}
