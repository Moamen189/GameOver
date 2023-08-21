

using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext context;

        public GamesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Create()
        {
            CreateGameViewModel model = new CreateGameViewModel()
            {
                Categories= context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString() ,  Text = c.Name,})
                .OrderBy(x => x.Text)
                .ToList(),
            };
            return View(model);
        }
    }
}
