using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanGreen.Core.Entities;
using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces
{
    public interface IInspecaoRepository : IBaseRepository<Inspecao>
    {
        Task<IEnumerable<Inspecao>> ConsultarInspecao(int skip, int take);
        Task<Inspecao> ConsultarInspecaoPorID(int id);
    }
}
