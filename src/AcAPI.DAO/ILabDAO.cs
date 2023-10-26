using AcAPI.DTL;

namespace AcAPI.DAO
{
    public interface ILabDAO
    {
        List<LabDTO> Listar(); 
        void Incluir(LabDTO lab);
        void Atualizar(LabDTO lab);
        void Excluir(int id);
        public void Ativar(int id);
        public void Inativar(int id);
        public LabDTO ListarPorID(int id);
    }
}