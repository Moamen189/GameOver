using GameOver.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext context;
		private readonly IDevicesService devicesService;
		private readonly ICategoriesService categoriesService;

		public GamesController(ApplicationDbContext context , IDevicesService devicesService , IGamesService gamesService , ICategoriesService categoriesService)
        {
            this.context = context;
			this.devicesService = devicesService;
			this.categoriesService = categoriesService;
		}
        public IActionResult Index()
        {
            return View();
        }

        //Data Seeeding
        [HttpGet]

        public IActionResult Create()
        {
            CreateGameViewModel model = new CreateGameViewModel()
            {
                Categories= context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString() ,  Text = c.Name,})
                .OrderBy(x => x.Text)
                .ToList(),

                Devices = context.Devices.Select(x => new SelectListItem { Value = x.Id.ToString() ,Text = x.Name, }).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid) {

                model.Categories = context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name, })
                .OrderBy(x => x.Text)
                .ToList();

                model.Devices = context.Devices.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, }).ToList();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
