using AcAPI.DTL;

namespace AcAPI.DAO
{
    public interface IUsuario
    {
        List<UsuarioDTO> Listar();

        public UsuarioDTO Login(string Email, string Password);
        void Adicionar(UsuarioDTO usuario);
        void Atualizar(UsuarioDTO usuario);
        void Excluir(int id);
        public void Ativar(int id);
        public void Inativar(int id);
        public UsuarioDTO SelecionarUsuario(int id);
    }
}
