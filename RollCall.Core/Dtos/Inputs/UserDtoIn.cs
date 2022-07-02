using System.ComponentModel.DataAnnotations;
using RollCall.Core.Dtos.Outputs;

namespace RollCall.Core.Dtos.Inputs
{
    public class UserDtoIn
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [StringLength(20)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Rol")]
        public int RolId { get; set; }
        public virtual RolDto Rol { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Los {0} son requeridos")]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
    }
}