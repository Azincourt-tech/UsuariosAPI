using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace UsuariosAPI.Database
{
    public class UserDbContext: IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {


        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // Reescreve metodo OnConfiguring, passando a string de conexão com o banco;
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", false, true)
                 .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("UsuarioConnection"));
        }


       
    }
}
