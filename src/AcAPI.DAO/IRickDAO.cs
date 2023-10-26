using AcAPI.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcAPI.DAL
{
    public interface IRickDAO
    {
        Task<string> get();
         Task<string> put();
    }
}
