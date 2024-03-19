using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Dto;
using ProdutosApiNetCore.Entity;
using ProdutosApiNetCore.Repo;

namespace ProdutosApiNetCore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {  

        private readonly IPedidos _pedidos;
        private readonly IMapper _mapper;


        public PedidosController(IPedidos pedidoRepositorio, IMapper mapper)
        {
            _pedidos = pedidoRepositorio;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<Pedido>>> Adicionar(AdicionarDto pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pedidoDTO = _mapper.Map<Pedido>(pedido);

            await _pedidos.Adicionar(pedidoDTO);

            return Ok("Pedido criado com sucesso!");

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pedido>>> Pesquisar()
        {
            List<Pedido> pedido = await _pedidos.Pesquisar();

            return Ok(pedido);

        }

        [HttpGet("/api/PesquisarId")]
        public async Task<ActionResult<List<Pedido>>> PesquisarId(int id)
        {
            List<Pedido> pedido = await _pedidos.PesquisarPorId(id);

            return Ok(pedido);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pedidos.Deletar(id);

            return Ok("Foi deletado!");
        }

    }
}
