using AcAPI.BLL;
using AcAPI.DTL;
using Microsoft.AspNetCore.Mvc;

namespace AcAPI
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        [Route(nameof(Listar))]
        public IActionResult Listar()
        {
            return Ok(_usuario.Listar());
        }

        [HttpPost]
        [Route(nameof(Adicionar))]
        public IActionResult Adicionar(UsuarioDTO usuario)
        {
            _usuario.Adicionar(usuario);
            return Ok();
        }   
    }
}
