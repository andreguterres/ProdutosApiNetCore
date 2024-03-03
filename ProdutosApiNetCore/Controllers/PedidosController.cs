using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Controllers
{
    [Route("api/Pedido")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PedidosController (AplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Pedido>>> Adicionar (Pedido pedido)
        {
            if (pedido != null)
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return Ok(await _context.Pedidos.ToListAsync());
            }
            return BadRequest("Erro ao incluir");

        }

    }
}
