using Microsoft.AspNetCore.Mvc;

using VentasApp.Data;
using VentasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace VentasApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public ClienteController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Cliente> Lista = await _appDbContext.Clientes.ToListAsync();
            return View(Lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Cliente cliente)
        {

            await _appDbContext.Clientes.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Cliente cliente = await _appDbContext.Clientes.FirstAsync(e => e.Id == id);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {

            _appDbContext.Clientes.Update(cliente);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Cliente cliente = await _appDbContext.Clientes.FirstAsync(e => e.Id == id);

            _appDbContext.Clientes.Remove(cliente);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
