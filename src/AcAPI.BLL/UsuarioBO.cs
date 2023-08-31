using AcAPI.DAL;
using AcAPI.DTL;

namespace AcAPI.BLL
{
    public class UsuarioBO : IUsuario
    {
        private readonly IUsuarioDAO _usuarioDAO;

        public UsuarioBO(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        public void Adicionar(UsuarioDTO usuario)
        {
            _usuarioDAO.Adicionar(usuario); 
        }

        public List<UsuarioDTO> Listar()
        {
            return _usuarioDAO.Listar();
        }
    }
}
