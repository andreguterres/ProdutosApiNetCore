using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Entity;
using ProdutosApiNetCore.Repo;

namespace ProdutosApiNetCore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {  

        private readonly IPedidos _pedidos;
        public PedidosController(IPedidos pedidoRepositorio)
        {
            _pedidos = pedidoRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<List<Pedido>>> Adicionar(Pedido pedido)
        {

            var pedidos = await _pedidos.Adicionar(pedido);

            return Ok(pedidos);

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pedido>>> Pesquisar()
        {
            List<Pedido> pedido = await _pedidos.Pesquisar();

            return Ok(pedido);

        }


    }
}
