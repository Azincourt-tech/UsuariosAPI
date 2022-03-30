using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Database.Request
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }

    }
}
