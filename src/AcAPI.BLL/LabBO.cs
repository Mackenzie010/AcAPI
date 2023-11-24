using AcAPI.DAO;
using AcAPI.DTL;

namespace AcAPI.BLL
{
    public class LabBO : ILab
    {
        private readonly ILabDAO _labDAO;

        public LabBO(ILabDAO labDAO)
        {
            _labDAO = labDAO;
        }

        public void Adicionar(LabDTO lab)
        {
            _labDAO.Incluir(lab);
        }
        public void IncluirAgendamento(AgendamentoDTO agendamento)
        {
            _labDAO.IncluirAgendamento(agendamento);
        }
        public void Excluir(int id)
        {
            _labDAO.Excluir(id);
        }

        public List<LabDTO> Listar()
        {
            return _labDAO.Listar();
        }

        public List<AgendamentoDTO> ListarAgendamentosPorLab(int idLab)
        {
            return _labDAO.ListarAgendamentosPorLab(idLab);
        }

        public void Atualizar(LabDTO lab)
        {
            _labDAO.Atualizar(lab);
        }
        public LabDTO ListarPorID(int id)
        {
            return _labDAO.ListarPorID(id);
        }
        void ILab.Ativar(int id)
        {
            _labDAO.Ativar(id);
        }
        void ILab.Inativar(int id)
        {
            _labDAO.Inativar(id);
        }
    }
}

