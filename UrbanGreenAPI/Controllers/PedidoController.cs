using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.Pedido;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly ILogger<ProdutoController> _logger;

        public PedidoController(IPedidoService pedidoservice, ILogger<ProdutoController> logger)
        {
            _pedidoService = pedidoservice;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPedido([FromBody] CreatePedidoDto pedidoDto)
        {
            try
            {
                await _pedidoService.CadastrarPedido(pedidoDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Erro de argumento: {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado: {Message}", ex.Message);
                return StatusCode(500, new { message = "Ocorreu um erro ao cadastrar o pedido.", detalhe = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IEnumerable<ReadPedidoDto>> ConsultarPedido([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return await _pedidoService.ConsultarPedido(skip, take);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPedidoPorID(int id)
        {
            var pedido = await _pedidoService.ConsultarPedidoPorID(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody] UpdatePedidoDto pedidoDto)
        {
            var pedidoAtualizado = await _pedidoService.AtualizarPedido(id, pedidoDto);
            if (pedidoAtualizado == false) return NotFound();
            return Ok(pedidoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPedido(int id)
        {
            var pedido = await _pedidoService.DeletarPedido(id);
            if (pedido == false) return NotFound();
            return NoContent();
        }
        [HttpGet("listarItens")]
        public async Task<IActionResult> ListarItens()
        {
            var itens = await _pedidoService.ListarItens();
            return Ok(itens);
        }
    }

}

