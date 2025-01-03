﻿using UrbanGreen.Application.Models.Inspecao;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

public class InspecaoService : IInspecaoService
{
    private readonly IInspecaoRepository _inspecaoRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly ITipoItemInspecaoRepository _tipoItemInspecaoRepository;
    public InspecaoService(IInspecaoRepository inspecaoRepository, IProdutoRepository produtoRepository,
        ITipoItemInspecaoRepository tipoItemInspecaoRepository)
    {
        _inspecaoRepository = inspecaoRepository;
        _produtoRepository = produtoRepository;
        _tipoItemInspecaoRepository = tipoItemInspecaoRepository;
    }

    public async Task<bool> AtualizarInspecao(int id, UpdateInspecaoDto inspecaoDto)
    {
        var produto = await _produtoRepository.ConsultarProdutoPorID(inspecaoDto.ProdutoId);
        var inspecao = await _inspecaoRepository.ConsultarInspecaoPorID(id);
        if (inspecao == null || produto == null) return false;

        foreach (var item in inspecaoDto.Itens)
        {
            inspecao.UpdateItem(item.Data, item.TipoId, item.Realizado);
        }

        inspecao.AtualizarComplementos(inspecaoDto.Registro, inspecaoDto.QntColhida);

        await _inspecaoRepository.UpdateAsync(inspecao);
        return true;
    }

    public async Task CadastrarInspecao(CreateInspecaoDto inspecaoDto)
    {
        var produto = await _produtoRepository.ConsultarProdutoPorID(inspecaoDto.ProdutoId);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        var inspecao = new Inspecao(produto.Id);

        foreach (var item in inspecaoDto.Itens)
        {
            inspecao.UpdateItem(item.Data, item.TipoId, item.Realizado);
        }

        inspecao.AtualizarComplementos(inspecaoDto.Registro, inspecaoDto.QntColhida);

        await _inspecaoRepository.AddAsync(inspecao);
        await _produtoRepository.UpdateAsync(produto);
    }

    public async Task<IEnumerable<ReadInspecaoDto>> ConsultarInspecao(int skip = 0, int take = 20)
    {
        var consultaInspecao = await _inspecaoRepository.ConsultarInspecao(skip, take);

        return consultaInspecao.Select(inspecao => new ReadInspecaoDto
        {
            Id = inspecao.Id,
            Registro = inspecao.Registro,
            Itens = inspecao.Itens
                .Select(item => new ReadItemInspecaoDto(item.Data, item.TipoItemInspecao.Nome, item.Realizado, item.TipoItemInspecaoId))
                .ToList(),
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
            Registro = inspecaoID.Registro,
            Itens = inspecaoID.Itens
                .Select(item => new ReadItemInspecaoDto(item.Data, item.TipoItemInspecao.Nome, item.Realizado, item.TipoItemInspecaoId))
                .ToList(),
            ProdutoId = inspecaoID.ProdutoId
        };
    }

    public async Task<ReadInspecaoDto> ConsultarInspecaoPorProdutoId(int id)
    {
        var inspecaoID = await _inspecaoRepository.ConsultarInspecaoAtivaPorProdutoId(id);

        if (inspecaoID == null) return null;

        return new ReadInspecaoDto
        {
            Id = inspecaoID.Id,
            Registro = inspecaoID.Registro,
            Itens = inspecaoID.Itens
                .Select(item => new ReadItemInspecaoDto(item.Data, item.TipoItemInspecao.Nome, item.Realizado, item.TipoItemInspecaoId))
                .ToList(),
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

    public async Task<IList<ReadTipoItensInspecaoDto>> ConsultarTiposItens()
    {
        var itens = await _tipoItemInspecaoRepository.ConsultarItens();
        return itens.Select(item => new ReadTipoItensInspecaoDto(item.Id, item.Nome)).ToList();
    }
}
