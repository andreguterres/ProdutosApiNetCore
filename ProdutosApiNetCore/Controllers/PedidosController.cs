using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PedidosController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Pedido>>> Adicionar(Pedido pedido)
        {
            if (pedido != null)
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return Ok(await _context.Pedidos.ToListAsync());
            }
            return BadRequest("Erro ao incluir");

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pedido>>> Pesquisar()
        {
            //var pedidos = await _context.Pedidos.AsNoTracking().ToListAsync();
            var pedidos = _context.Pedidos.Include(i => i.Itens).ToList();
                return Ok(pedidos.ToList());            

        }


    }
}
