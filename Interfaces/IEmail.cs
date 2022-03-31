using MailKit.Net.Smtp;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Interfaces
{
    public interface IEmail
    {


        public void EnviarEmail(string[] destinario, string assunto, string code)
        {
        }

       
        

    }
}
