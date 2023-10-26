using AcAPI.BLL;
using AcAPI.DAL;
using AcAPI.DAO;
using AcAPI.DTL;
using Microsoft.AspNetCore.Mvc;

namespace AcAPI
{
    [ApiController]
    [Route("[Controller]")]
    public class LabController : ControllerBase
    {
        private readonly ILab _lab;
        private readonly IRickDAO _rickDAO;
        public LabController(ILab lab, IRickDAO rickDAO)
        {
            _lab = lab;
            _rickDAO = rickDAO;
        }

        [HttpGet]
        [Route(nameof(Listar))]
        public IActionResult Listar()
        {
            return Ok(_lab.Listar());
        }

        [HttpGet]
        [Route(nameof(ListarPorID))]
        public IActionResult ListarPorID(int id)
        {
            var lab = _lab.ListarPorID(id);

            if (lab == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        errors = "Este Lab não existe"
                    }
                });
            }
            else
            {
                return Ok(lab);
            }
        }
        [HttpPost]
        [Route(nameof(Adicionar))]
        public IActionResult Adicionar(LabDTO lab)
        {
            _lab.Adicionar(lab);
            return Ok();
        }

        [HttpDelete]
        [Route(nameof(Excluir))]
        public IActionResult Excluir(int id)
        {
            _lab.Excluir(id);

            var lab = _lab.ListarPorID(id);
            if (lab == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        errors = "Lab não encontrado"
                    }
                });
            }
            else
            {
                return Ok(lab);
            }
        }

        [HttpPut]
        [Route(nameof(Atualizar))]
        public IActionResult Atualizar(LabDTO lab)
        {
            _lab.Atualizar(lab);
            return Ok();
        }

        [HttpPut]
        [Route(nameof(Ativar))]
        public IActionResult Ativar(int id)
        {
            _lab.Ativar(id);

            var lab = _lab.ListarPorID(id);
            if (lab == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        message = "Lab não encontrado"
                    }
                });
            }
            else
            {
                return Ok(new
                {
                    data = new
                    {
                        message = "Lab ativado com sucesso!"
                    }
                });
            }

        }
        [HttpPut]
        [Route(nameof(Inativar))]
        public IActionResult Inativar(int id)
        {
            _lab.Inativar(id);

            var lab = _lab.ListarPorID(id);
            if (lab == null)
            {
                return NotFound(new
                {
                    data = new
                    {
                        message = "Lab não encontrado"
                    }
                });
            }
            else
            {
                return Ok(new
                {
                    data = new
                    {
                        message = "Lab desativado com sucesso!"
                    }
                });
            }
        }
        [HttpGet]
        [Route(nameof(getTeste))]
        public IActionResult getTeste()
        {
            var retorno  =_rickDAO.get();
            return Ok(retorno);
        }
        [HttpPost]
        [Route(nameof(putTeste))]
        public IActionResult putTeste()
        {
            var retorno = _rickDAO.put();
            return Ok(retorno);
        }
    }
}


