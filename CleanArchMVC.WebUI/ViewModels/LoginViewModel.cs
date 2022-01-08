using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string DS_EMAIL { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(20, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo " +
             "{1} caracteres de comprimento.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string DS_PASSWORD { get; set; }
        public string ReturnUrl { get; set; }
    }
}
