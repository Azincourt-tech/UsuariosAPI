using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Database.Request
{
    public class EfetuaResetRequest
    {
        [Required(ErrorMessage = "O campo Password é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo RePassword é obrigatório")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senha e confirmação são diferentes.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Token é obrigatório")]
        public string Token { get; set; }
    }
}
