using Microsoft.AspNetCore.Mvc;
using System;
using UsuariosAPI.Database.Dtos;

namespace UsuariosAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            return Ok(createDto);
        }

       
    }
}
