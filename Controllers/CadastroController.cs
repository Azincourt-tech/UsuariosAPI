using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using UsuariosAPI.Database.Dtos;
using UsuariosAPI.Database.Request;
using UsuariosAPI.Services;
using UsuariosAPI.Database;
using System.Linq;
using UsuariosAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UsuariosAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;
        private UserDbContext _userDbContext;

        public CadastroController(CadastroService cadastroService, UserDbContext context)
        {
            _cadastroService = cadastroService;
            _userDbContext = context;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
                return Ok(resultado.Successes);
        }

       [HttpGet("/ativa")]
       public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);
            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok(resultado.Successes);
       }

        [HttpDelete("/{id}")]
        public IActionResult ExcluirConta(int id)
        {
            Result result = _cadastroService.ExcluirContaPorID(id);
            if (result == null)
            {
                return NotFound();
                
            }
            _userDbContext.Remove(result);
            _userDbContext.SaveChanges();
            return NoContent();

        }

    }
}
