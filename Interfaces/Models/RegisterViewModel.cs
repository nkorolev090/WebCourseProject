using System.ComponentModel.DataAnnotations;

namespace Interfaces.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Name")]
        public string? Name { get; set; } = null;

        [Display(Name = "Midname")]
        public string? Midname { get; set; } = null;

        [Display(Name = "Surname")]
        public string? Surname { get; set; } = null;

        [Display(Name = "PhoneNumber")]
        public string? PhoneNumber { get; set; } = null;

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
