using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Web;
using UsuariosAPI.Database.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {

        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        private EmailResetService _emailResetService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, EmailResetService emailResetService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailResetService = emailResetService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultaIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultaIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());

                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
                return Result.Fail("Login falhou");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                _emailResetService.EnviarEmail(new[] { identityUser.Email }, "Token de Autenticação", codigoDeRecuperacao);
                return Result.Ok().WithSuccess("Codigo enviado para email com sucesso: " + codigoDeRecuperacao);


            }

            return Result.Fail("Falha ao solicitar o reset de senha");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult result = _signInManager
                .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (result.Succeeded) return Result.Ok().WithSuccess("Senha alterada com sucesso");

            return Result.Fail("Houve um erro na operação");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
