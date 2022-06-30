using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos.Outputs
{
    public class AreaDtoOut
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}