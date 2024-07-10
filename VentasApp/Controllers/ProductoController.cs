using Microsoft.AspNetCore.Mvc;

using VentasApp.Data;
using VentasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace VentasApp.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public ProductoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Producto> Lista = await _appDbContext.Productos.ToListAsync();
            return View(Lista);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string searchString)
        {
            var productos = from p in _appDbContext.Productos select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(p => p.NombreProducto.Contains(searchString) ||
                                                  p.IdProducto.ToString().Contains(searchString) ||
                                                  p.CodigoProducto.Contains(searchString) ||
                                                  p.CodigoBarras.Contains(searchString) ||
                                                  p.SKU.Contains(searchString));
            }

            return View(await productos.ToListAsync());

        }

            [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Producto producto)
        {

            await _appDbContext.Productos.AddAsync(producto);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Producto producto = await _appDbContext.Productos.FirstAsync(e => e.IdProducto == id);
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Producto producto)
        {

            _appDbContext.Productos.Update(producto);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Producto producto = await _appDbContext.Productos.FirstAsync(e => e.IdProducto == id);

            _appDbContext.Productos.Remove(producto);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }



    }
}
