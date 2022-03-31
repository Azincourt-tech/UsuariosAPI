using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Database.Dtos
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = "O campo Username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo RePassword é obrigatório")]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
