using Microsoft.AspNetCore.Mvc;

using VentasApp.Data;
using VentasApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VentasApp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public PedidoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Pedido> Lista = await _appDbContext.Pedidos.ToListAsync();
            return View(Lista);
        }


        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Pedido pedido)
        {

            await _appDbContext.Pedidos.AddAsync(pedido);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {

            var pedido = await _appDbContext.Pedidos
       .Include(p => p.Cliente)
       .FirstOrDefaultAsync(e => e.IdPedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(_appDbContext.Clientes, "Id", "Nombre", pedido.ClienteId);
            return View(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Pedido pedido)
        {

            _appDbContext.Pedidos.Update(pedido);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Pedido pedido = await _appDbContext.Pedidos.FirstAsync(e => e.IdPedido == id);

            _appDbContext.Pedidos.Remove(pedido);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
