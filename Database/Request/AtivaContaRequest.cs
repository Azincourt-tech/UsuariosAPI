using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Database.Request
{
    public class AtivaContaRequest
    {

        [Required(ErrorMessage = "O campo UsuarioId é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo CodigoDeAtivação é obrigatório")]
        public string CodigoDeAtivacao { get; set; }
    }
}
