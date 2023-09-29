using AcAPI.BLL;
using AcAPI.DAO;
using Microsoft.AspNetCore.Mvc;

namespace AcAPI
{

    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public LoginController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpPost]
        [Route(nameof(Login))]
        public IActionResult Login(string? Email, string? Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                return Unauthorized(new
                {
                    data = new
                    {
                        errors = "Informe o campo email e senha corretamente."
                    }
                });
            }
            var usuario = _usuario.Login(Email, Password);

            if (usuario == null)
            {
                return Unauthorized(new
                {
                    data = new
                    {
                        errors = "Os campos Senha e(ou) Email estão inválidos."
                    }
                });
            }
            else
            {
                return Ok(usuario);
            }
        }
    }
}



