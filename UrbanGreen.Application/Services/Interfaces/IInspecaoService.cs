using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanGreen.Application.Models.Inspecao;
using UrbanGreen.Application.Models.Insumo;

namespace UrbanGreen.Application.Services.Interfaces
{
    public interface IInspecaoService
    {
        Task CadastrarInspecao(CreateInspecaoDto inspecaoDto);
        Task<IEnumerable<ReadInspecaoDto>> ConsultarInspecao(int skip = 0, int take = 20);
        Task<ReadInspecaoDto> ConsultarInspecaoPorID(int id);
        Task<bool> AtualizarInspecao(int id, UpdateInspecaoDto inspecaoDto);
        Task<bool> DeletarInspecao(int id);
    }
}
