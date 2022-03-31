using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Database.Request
{
    public class SolicitaResetRequest
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

    }
}
