using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanGreen.Application.Models.FornecedorDto;
using UrbanGreenAPI.Application.Models;

namespace UrbanGreen.Application.Interface
{
    public interface IFornecedorService
    {
        Task CadastrarFornecedor(CreateFornecedorDto FornecedorDto);
        Task<IEnumerable<ReadFornecedorDto>> ConsultarFornecedor(int skip = 0, int take = 20);
        Task<ReadFornecedorDto> ConsultarFornecedorPorID(int id);
        Task<bool> AtualizarFornecedor(int id, UpdateFornecedorDto FornecedorDto);
        Task<bool> DeletarFornecedor(int id);
    }
}
