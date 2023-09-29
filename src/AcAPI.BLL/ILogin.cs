using AcAPI.DTL;

namespace AcAPI.BLL
{
    public interface ILogin
    {
        List<LoginDTO> Listar();
        bool Login(string Email, string Password);          
    }
}