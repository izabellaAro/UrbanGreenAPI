using UrbanGreen.Application.Models.Insumo;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.DataAcess.Repositories.Interfaces;
using UrbanGreenAPI.Core.Entities;

namespace UrbanGreenAPI.Application.Services.Impl;

public class InsumoService : IInsumoService
{
    private readonly IInsumoRepository _insumoRepository;

    public InsumoService(IInsumoRepository insumoRepository)
    {
        _insumoRepository = insumoRepository;
    }

    public async Task<bool> AtualizarInsumo(int id, UpdateInsumoDto insumoDto)
    {
        var insumo = await _insumoRepository.ConsultarInsumoPorID(id);
        if (insumo == null) return false;
        insumo.Update(insumoDto.Nome, insumoDto.Quantidade, insumoDto.Valor);
        await _insumoRepository.UpdateAsync(insumo);
        return true;
    }

    public async Task CadastrarInsumo(CreateInsumoDto insumoDto)
    {
        var insumo = new Insumo(insumoDto.Nome, insumoDto.Quantidade, insumoDto.Valor);
        await _insumoRepository.AddAsync(insumo);
    }

    public async Task<IEnumerable<ReadInsumoDto>> ConsultarInsumos(int skip = 0, int take = 20)
    {
        var consultaInsumo = await _insumoRepository.ConsultarInsumos(skip, take);

        return consultaInsumo.Select(insumo => new ReadInsumoDto
        {
            Id = insumo.Id,
            Nome = insumo.Nome,
            Quantidade = insumo.Quantidade,
            Valor = insumo.Valor
        }).ToList();
    }

    public async Task<ReadInsumoDto> ConsultarInsumoPorID(int id)
    {
        var insumoID = await _insumoRepository.ConsultarInsumoPorID(id);

        if (insumoID == null) return null;

        return new ReadInsumoDto
        {
            Id = insumoID.Id,
            Nome = insumoID.Nome,
            Quantidade = insumoID.Quantidade,
            Valor = insumoID.Valor
        };
    }

    public async Task<bool> DeletarInsumo(int id)
    {
        var insumo = await _insumoRepository.ConsultarInsumoPorID(id);
        if (insumo == null) return false;
        await _insumoRepository.DeleteAsync(insumo);
        return true;
    }
}
