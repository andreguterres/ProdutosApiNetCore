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

          /*  var pedidos =*/ await _pedidos.Adicionar(pedidoDTO);

            return Ok();

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pedido>>> Pesquisar()
        {
            List<Pedido> pedido = await _pedidos.Pesquisar();

            return Ok(pedido);

        }


    }
}
