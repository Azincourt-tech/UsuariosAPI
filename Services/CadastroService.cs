using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Database.Dtos;
using UsuariosAPI.Database.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            
            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new [] {usuarioIdentity.Email}, "Link de Ativação", usuarioIdentity.Id, encodedCode);
                return Result.Ok()
                    .WithSuccess("Link de autenticação enviado para email com sucesso: " + code);
            }
            
            return Result.Fail("Falha ao cadastrar usuário");
    
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok().WithSuccess("Conta verificada com êxito");
            }
            return Result.Fail("Falha ao ativar conta do usuário");
        }

        public Result ExcluirContaPorID(int id)
        {
            var identityUser = _userManager
                .Users.FirstOrDefault(u => u.Id == id);

            var IdentityResult = _userManager.DeleteAsync(identityUser).Result;

            if (IdentityResult.Succeeded)
            {
                return Result.Ok().WithSuccess("Conta excluida com êxito");
            }
            return Result.Fail("Erro na operação");
           
        }


    }
}
