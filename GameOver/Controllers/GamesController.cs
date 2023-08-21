

namespace GameOver.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Create()
        {
            CreateGameViewModel model = new CreateGameViewModel();
            return View();
        }
    }
}
