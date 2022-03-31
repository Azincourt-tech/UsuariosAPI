using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Database.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O campo Username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string Password { get; set; }
    }
}
