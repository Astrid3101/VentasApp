using Microsoft.AspNetCore.Mvc;

using VentasApp.Data;
using VentasApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VentasApp.Controllers
{
    public class FacturaController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public FacturaController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Factura> Lista = await _appDbContext.Facturas.ToListAsync();
            return View(Lista);
        }


        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Factura factura)
        {

            await _appDbContext.Facturas.AddAsync(factura);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {

            var factura = await _appDbContext.Facturas
       .Include(p => p.Pedido)
       .FirstOrDefaultAsync(e => e.PedidoId == id);
            if (factura == null)
            {
                return NotFound();
            }

            ViewData["PedidoId"] = new SelectList(_appDbContext.Clientes, "Id", "Nombre", factura.PedidoId);
            return View(factura);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Factura factura)
        {

            _appDbContext.Facturas.Update(factura);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Factura factura = await _appDbContext.Facturas.FirstAsync(e => e.IdFactura == id);

            _appDbContext.Facturas.Remove(factura);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
