using GameOver.Models;
using GameOver.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameOver.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesService gamesService;

        public HomeController(ILogger<HomeController> logger , IGamesService gamesService)
        {
            _logger = logger;
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = gamesService.GetAll();
            return View(games);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}