using AcAPI.DTL;
using Org.BouncyCastle.Crypto.Tls;

namespace AcAPI.DAO
{
    public interface IUsuarioDAO
    {
        List<UsuarioDTO> Listar();

        public UsuarioDTO Login(string Email, string Password);
        void Incluir(UsuarioDTO usuario);
        void Atualizar(UsuarioDTO usuario);
        void Excluir(int id);
        public void Ativar(int id);
        public void Inativar(int id);
        UsuarioDTO SelecionarUsuario(int id);
    }
}
