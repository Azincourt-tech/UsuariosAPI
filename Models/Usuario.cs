using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Models
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Email { get; set; }
    }
}
