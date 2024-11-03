using Interfaces.DTO;
using System.ComponentModel.DataAnnotations;

namespace Interfaces.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "registration")]
        public RegistrationDTO Registration { get; set; }

        [Required]
        [Display(Name = "slots")]
        public List<SlotDTO> Slots { get; set; }
    }
}
