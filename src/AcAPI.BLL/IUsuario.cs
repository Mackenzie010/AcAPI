using AcAPI.DTL;

namespace AcAPI.BLL
{
    public interface IUsuario
    {
        void Adicionar(UsuarioDTO usuario);

        List<UsuarioDTO> Listar();
       
    }
}