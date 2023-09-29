using AcAPI.DTL;

namespace AcAPI.BLL
{
    public interface ILab
    {
        List<LabDTO> Listar();     
        void Adicionar(LabDTO lab);
        void Atualizar(LabDTO lab);
        void Excluir(int id);
        public void Ativar(int id);
        public void Inativar(int id);
        public LabDTO SelecionarLab(int id);
    }
}