using AcAPI.DAO;
using AcAPI.DTL;

namespace AcAPI.BLL
{
    public class LoginDAO : ILogin
    {
        private readonly ILoginDAO _loginDAO;


        public bool Listar(string Email, string Password)
        {
            return UsuarioDTO.Listar(Email, Password);
        }
    }
}
