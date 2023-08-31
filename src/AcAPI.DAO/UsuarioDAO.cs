using AcAPI.DAL;
using AcAPI.DTL;

namespace AcAPI.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly List<UsuarioDTO> _usuarios;

        public UsuarioDAO()
        {
            _usuarios = new List<UsuarioDTO>();
        }

        public void Adicionar(UsuarioDTO usuario)
        {
            usuario.Id = _usuarios.Count > 0 ? _usuarios.Last().Id + 1 : 1;

            if (_usuarios.Count > 2)
            {
                _usuarios.Remove(_usuarios.First());
            }
            _usuarios.Add(usuario);
        }

        public List<UsuarioDTO> Listar()
        {
            return _usuarios;
        }
    }
}