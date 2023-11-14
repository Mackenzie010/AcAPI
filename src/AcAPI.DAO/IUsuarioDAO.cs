using AcAPI.DTL;

namespace AcAPI.DAO
{
    public interface IUsuarioDAO
    {
        List<UsuarioDTO> Listar();

        UsuarioDTO Login(string Email, string Password);
        void Incluir(UsuarioDTO usuario);
        void Atualizar(UsuarioDTO usuario);
        void Excluir(int id);
        void Ativar(int id);
        void Inativar(int id);
        UsuarioDTO ListarPorID(int id);
    }
}
