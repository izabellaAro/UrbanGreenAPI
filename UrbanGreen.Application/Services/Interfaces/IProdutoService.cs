using UrbanGreen.Application.Models.Produto;

namespace UrbanGreen.Application.Services.Interfaces;

public interface IProdutoService
{
    Task CadastrarProduto(CreateProdutoDto produtoDto);
    Task<IEnumerable<ReadProdutoDto>> ConsultarProdutos(int skip = 0, int take = 20);
    Task<ReadProdutoDto> ConsultarProdutoPorID(int id);
    Task<bool> AtualizarProduto(int id, UpdateProdutoDto produtoDto);
    Task<bool> DeletarProduto(int id);
    Task<GetImagemProdutoDto> ObterImagemProduto(int id);
}
