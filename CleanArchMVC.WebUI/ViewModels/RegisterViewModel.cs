using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string DS_EMAIL { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string DS_PASSWORD { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha não é igual")]
        public string ConfirmPassword { get; set; }
    }
}
