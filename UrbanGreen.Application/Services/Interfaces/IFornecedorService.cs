using UrbanGreen.Application.Models.Fornecedor;

namespace UrbanGreen.Application.Interface;

public interface IFornecedorService
{
    Task CadastrarFornecedor(CreateFornecedorDto FornecedorDto);
    Task<IEnumerable<ReadFornecedorDto>> ConsultarFornecedor(int skip = 0, int take = 20);
    Task<ReadFornecedorDto> ConsultarFornecedorPorID(int id);
    Task<bool> AtualizarFornecedor(int id, UpdateFornecedorDto FornecedorDto);
    Task<bool> DeletarFornecedor(int id);
}
