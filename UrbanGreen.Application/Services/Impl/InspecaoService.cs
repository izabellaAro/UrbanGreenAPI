using UrbanGreen.Application.Models.Inspecao;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

public class InspecaoService : IInspecaoService
{
    private readonly IInspecaoRepository _inspecaoRepository;
    private readonly IProdutoRepository _produtoRepository;
    public InspecaoService(IInspecaoRepository inspecaoRepository, IProdutoRepository produtoRepository)
    {
        _inspecaoRepository = inspecaoRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> AtualizarInspecao(int id, UpdateInspecaoDto inspecaoDto)
    {
        var produto = await _produtoRepository.ConsultarProdutoPorID(inspecaoDto.ProdutoId);
        var inspecao = await _inspecaoRepository.ConsultarInspecaoPorID(id);
        if (inspecao == null || produto == null) return false;
        inspecao.Update(inspecaoDto.Data, inspecaoDto.SelecaoSemente, inspecaoDto.ControlePragas, inspecaoDto.Irrigacao, inspecaoDto.CuidadoSolo, inspecaoDto.Colheita, produto, produto.Id);
        await _inspecaoRepository.UpdateAsync(inspecao);
        return true;
    }

    public async Task CadastrarInspecao(CreateInspecaoDto inspecaoDto)
    {
        var produto = await _produtoRepository.ConsultarProdutoPorID(inspecaoDto.ProdutoId);
        var inspecao = new Inspecao(inspecaoDto.Data, inspecaoDto.SelecaoSemente, inspecaoDto.ControlePragas, inspecaoDto.Irrigacao, inspecaoDto.CuidadoSolo, inspecaoDto.Colheita, produto, produto.Id);
        await _inspecaoRepository.AddAsync(inspecao);
    }

    public async Task<IEnumerable<ReadInspecaoDto>> ConsultarInspecao(int skip = 0, int take = 20)
    {
        var consultaInspecao = await _inspecaoRepository.ConsultarInspecao(skip, take);

        return consultaInspecao.Select(inspecao => new ReadInspecaoDto
        {
            Id = inspecao.Id,
            Data = inspecao.Data,
            SelecaoSemente = inspecao.SelecaoSemente,
            ControlePragas = inspecao.ControlePragas,
            Irrigacao = inspecao.Irrigacao,
            CuidadoSolo = inspecao.CuidadoSolo,
            Colheita = inspecao.Colheita,
            ProdutoId = inspecao.ProdutoId
        }).ToList();
    }

    public async Task<ReadInspecaoDto> ConsultarInspecaoPorID(int id)
    {
        var inspecaoID = await _inspecaoRepository.ConsultarInspecaoPorID(id);

        if (inspecaoID == null) return null;

        return new ReadInspecaoDto
        {
            Id = inspecaoID.Id,
            Data = inspecaoID.Data,
            SelecaoSemente = inspecaoID.SelecaoSemente,
            ControlePragas = inspecaoID.ControlePragas,
            Irrigacao = inspecaoID.Irrigacao,
            CuidadoSolo = inspecaoID.CuidadoSolo,
            Colheita = inspecaoID.Colheita,
            ProdutoId = inspecaoID.ProdutoId
        };
    }

    public async Task<bool> DeletarInspecao(int id)
    {
        var inspecao = await _inspecaoRepository.ConsultarInspecaoPorID(id);
        if (inspecao == null) return false;
        await _inspecaoRepository.DeleteAsync(inspecao);
        return true;
    }
}
