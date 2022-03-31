using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Models
{
    public class Usuario: IdentityUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Email { get; set; }
    }
}
