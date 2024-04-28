using Interfaces.DTO;
using System.ComponentModel.DataAnnotations;

namespace Interfaces.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "Registration")]
        public RegistrationDTO Registration { get; set; }

        [Required]
        [Display(Name = "Slots")]
        public List<SlotDTO> Slots { get; set; }
    }
}
