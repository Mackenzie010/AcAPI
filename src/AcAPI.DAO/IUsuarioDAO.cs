using AcAPI.DTL;

namespace AcAPI.DAL
{
    public interface IUsuarioDAO
    {
        void Adicionar(UsuarioDTO usuario);
                List<UsuarioDTO> Listar();
    }
}
