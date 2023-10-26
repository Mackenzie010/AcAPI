using AcAPI.BLL;
using AcAPI.DAO;
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
        [HttpGet]
        [Route(nameof(ListarPorID))]
        public IActionResult ListarPorID(int id)
        {
            var usuario = _usuario.ListarPorID(id);

            if (usuario == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        errors = "Este Usuario n�o existe"
                    }
                });
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPost]
        [Route(nameof(Adicionar))]
        public IActionResult Adicionar(UsuarioDTO usuario)
        {
            _usuario.Adicionar(usuario);
            return Ok();

        }

        [HttpDelete]
        [Route(nameof(Excluir))]
        public IActionResult Excluir(int id)
        {
            _usuario.Excluir(id);

            var usuario = _usuario.ListarPorID(id);
            if (usuario == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        errors = "Usu�rio n�o encontrado"
                    }
                });
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPut]
        [Route(nameof(Atualizar))]
        public IActionResult Atualizar(UsuarioDTO usuario)
        {
            _usuario.Atualizar(usuario);
            return Ok();
        }

        [HttpPut]
        [Route(nameof(Ativar))]
        public IActionResult Ativar(int id)
        {
            _usuario.Ativar(id);

            var usuario = _usuario.ListarPorID(id);
            if (usuario == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        errors = "Usu�rio n�o encontrado"
                    }
                });
            }
            else
            {
                var mensagem = "Enviamos um link de confirma��o no seu email, por gentileza fa�a a verifica��o";
                return Ok(new
                {
                    data = new
                    {
                        message = mensagem,
                    }
                });
            }
        }
        [HttpPut]
        [Route(nameof(Inativar))]
        public IActionResult Inativar(int id)
        {
            _usuario.Inativar(id);

            var usuario = _usuario.ListarPorID(id);
            if (usuario == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        message = "Usu�rio n�o encontrado"
                    }
                });
            }
            else
            {
                return Ok(new
                {
                    data = new
                    {
                        message = "Usu�rio inativado com sucesso"
                    }
                });
            }
        }
    }
}
