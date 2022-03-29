using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using UsuariosAPI.Database.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastroUsuario(createDto);
            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
            
            return Ok();
        }

       
    }
}
