using System.ComponentModel.DataAnnotations;

namespace Prjslnback.API.ViewModels
{
    public class CreatePasswordViewModel
    {
        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        [MinLength(15, ErrorMessage = "A senha deve ter no mínimo 15 caracteres.")]
        public string Password { get; set; }
    }
}
