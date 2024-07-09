using UrbanGreen.Application.Models.Inspecao;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl
{
    public class InspecaoService : IInspecaoService
    {
        private readonly IInspecaoRepository _inspecaoRepository;
        public InspecaoService(IInspecaoRepository inspecaoRepository)
        {
            _inspecaoRepository = inspecaoRepository;
        }

        public async Task<bool> AtualizarInspecao(int id, UpdateInspecaoDto inspecaoDto)
        {
            var inspecao = await _inspecaoRepository.ConsultarInspecaoPorID(id);
            if (inspecao == null) return false;
            inspecao.Update(inspecaoDto.Data, inspecaoDto.SelecaoSemente, inspecaoDto.ControlePragas, inspecaoDto.Irrigacao, inspecaoDto.CuidadoSolo, inspecaoDto.Colheita);
            await _inspecaoRepository.UpdateAsync(inspecao);
            return true;
        }

        public async Task CadastrarInspecao(CreateInspecaoDto inspecaoDto)
        {
            var inspecao = new Inspecao(inspecaoDto.Data, inspecaoDto.SelecaoSemente, inspecaoDto.ControlePragas, inspecaoDto.Irrigacao, inspecaoDto.CuidadoSolo, inspecaoDto.Colheita);
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
                Colheita = inspecao.Colheita
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
                Colheita = inspecaoID.Colheita
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
}
