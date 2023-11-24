using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcAPI.DTL
{
    public class AgendamentoDTO
    {
        public int Id { get; set; }
        public int IdLab { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public string NmUsuario { get; set; }
        public string NmLab { get; set; }

    }
}
