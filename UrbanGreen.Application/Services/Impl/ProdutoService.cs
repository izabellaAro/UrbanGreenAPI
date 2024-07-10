using UrbanGreen.Application.Models.Produto;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> AtualizarProduto(int id, UpdateProdutoDto produtoDto)
    {
        var produto = await _produtoRepository.ConsultarProdutoPorID(id);
        if (produto == null) return false;
        produto.Update(produtoDto.Nome, produtoDto.Quantidade, produtoDto.Valor);
        await _produtoRepository.UpdateAsync(produto);
        return true;
    }

    public async Task CadastrarProduto(CreateProdutoDto produtoDto)
    {
        var produto = new Produto(produtoDto.Nome, produtoDto.Quantidade, produtoDto.Valor);
        await _produtoRepository.AddAsync(produto);
    }

    public async Task<ReadProdutoDto> ConsultarProdutoPorID(int id)
    {
        var produtoID = await _produtoRepository.ConsultarProdutoPorID(id);

        if (produtoID == null) return null;

        return new ReadProdutoDto
        {
            Id = produtoID.Id,
            Nome = produtoID.Nome,
            Quantidade = produtoID.Quantidade,
            Valor = produtoID.Valor
        };
    }

    public async Task<IEnumerable<ReadProdutoDto>> ConsultarProdutos(int skip = 0, int take = 20)
    {
        var consultaProdutos = await _produtoRepository.ConsultarProdutos(skip, take);

        return consultaProdutos.Select(produto => new ReadProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Quantidade = produto.Quantidade,
            Valor = produto.Valor
        }).ToList();
    }

    public async Task<bool> DeletarProduto(int id)
    {
        var produto = await _produtoRepository.ConsultarProdutoPorID(id);
        if (produto == null) return false;
        await _produtoRepository.DeleteAsync(produto);
        return true;
    }
}