using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string DS_EMAIL { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string DS_PASSWORD { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("DS_PASSWORD", ErrorMessage = "As senhas não batem")]
        public string ConfirmPassword { get; set; }
    }
}
