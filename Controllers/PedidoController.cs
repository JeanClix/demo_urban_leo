using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using urban_leo.Data;

namespace urban_leo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly ApplicationDbContext _context;


        public PedidoController(ILogger<PedidoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedido.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}