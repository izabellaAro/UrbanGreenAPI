using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Interface;
using UrbanGreen.Application.Models.FornecedorDto;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public FornecedorController(IFornecedorService fornecedorService, IPessoaJuridicaService pessoaJuridicaService)
        {
            _fornecedorService = fornecedorService;
            _pessoaJuridicaService = pessoaJuridicaService;
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarFornecedor([FromBody] CreateFornecedorDto fornecedorDto)
        {
            var pessoaJuridica = await _pessoaJuridicaService.ConsultarPJPorID(fornecedorDto.PessoaJuridicaId);

            if (pessoaJuridica == null)
            {
                throw new Exception("Pessoa Jurídica não encontrada.");
            }
            await _fornecedorService.CadastrarFornecedor(fornecedorDto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<ReadFornecedorDto>> ConsultarFornecedor([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return await _fornecedorService.ConsultarFornecedor(skip, take);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarFornecedorPorID(int id)
        {
            var fornecedor = await _fornecedorService.ConsultarFornecedorPorID(id);
            if (fornecedor == null) return NotFound();
            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFornecedor(int id, [FromBody] UpdateFornecedorDto fornecedorDto)
        {
            var fornecedorAtualizado = await _fornecedorService.AtualizarFornecedor(id, fornecedorDto);
            if (fornecedorAtualizado == false) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFornecedor(int id)
        {
            var fornecedor = await _fornecedorService.DeletarFornecedor(id);
            if (fornecedor == false) return NotFound();
            return NoContent();
        }
    }
}
