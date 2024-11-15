using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication.Models;
using WebApplication.services;

namespace WebApplication.Controllers

{
    public class DetteController
    {
        private readonly ILogger<DetteController> _logger;
        private readonly IDetteService _detteService;

        /* 
            ViewBag => Recupérer le même type
            ViewData => Dictionnaire durant une requête C => V | V => C
            TempData => Dictionnaire durant des requêtes successives
         */

        public DetteController(ILogger<DetteController> logger, IDetteService detteService)
        {
            _logger = logger;
            _detteService = detteService;
        }
        // Home/Index | Routes
        public async Task<IActionResult> Index()
        {

            return View();
        }

        public async Task<IActionResult> DetteClient(int clientId)
        {
            var dettes = await _detteService.GetDettesClientAsync(clientId);
            return View(dettes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
