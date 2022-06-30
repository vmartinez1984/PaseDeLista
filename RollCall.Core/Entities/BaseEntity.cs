using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollCall.Core.Entities
{
    public class Base01Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }

    public class Base02Entity : Base01Entity
    {
        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }
}