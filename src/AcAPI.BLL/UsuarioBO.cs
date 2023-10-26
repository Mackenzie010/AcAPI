using AcAPI.DAO;
using AcAPI.DTL;

namespace AcAPI.BLL
{
    public class UsuarioBO : IUsuario
    {
        private readonly IUsuarioDAO _usuariosDAO;

        public UsuarioBO(IUsuarioDAO usuarioDAO)
        {
            _usuariosDAO = usuarioDAO;
        }

        void IUsuario.Adicionar(UsuarioDTO usuario)
        {
            _usuariosDAO.Incluir(usuario);
        }

        void IUsuario.Excluir(int id)
        {
            _usuariosDAO.Excluir(id);
        }

        List<UsuarioDTO> IUsuario.Listar()
        {
            return _usuariosDAO.Listar();
        }
        public UsuarioDTO Login(string Email, string Password)
        {
            return _usuariosDAO.Login(Email,Password);
        }

        void IUsuario.Atualizar(UsuarioDTO usuario)
        {
            _usuariosDAO.Atualizar(usuario);
        }
        void IUsuario.Ativar(int id)
        {
            _usuariosDAO.Ativar(id);
        }

        public UsuarioDTO ListarPorID(int id)
        {
            return _usuariosDAO.ListarPorID(id);
        }
        void IUsuario.Inativar(int id)
        {
            _usuariosDAO.Inativar(id);
        }
    }
}
