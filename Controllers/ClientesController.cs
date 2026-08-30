using GestorOS.Data;
using GestorOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorOS.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string? busca)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(busca))
            {
                query = query.Where(c => c.Nome.Contains(busca));
            }

            ViewBag.Busca = busca;

            return View(await query.OrderBy(c => c.Nome).ToListAsync());
        }
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Cliente Cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
            
        }
    }
}
