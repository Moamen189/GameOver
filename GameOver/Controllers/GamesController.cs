﻿using GameOver.Services;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext context;
		private readonly IDevicesService devicesService;
		private readonly IGamesService gamesService;
		private readonly ICategoriesService categoriesService;

		public GamesController(ApplicationDbContext context , IDevicesService devicesService , IGamesService gamesService , ICategoriesService categoriesService)
        {
            this.context = context;
			this.devicesService = devicesService;
			this.gamesService = gamesService;
			this.categoriesService = categoriesService;
		}
        public IActionResult Index()
        {
            var games = gamesService.GetAll();
            return View(games);
        }


        public IActionResult Details(int id)
        {
            var game = gamesService.GetByID(id);
            if (game is null)
            {

                return NotFound();
            }
            return View(game);

        }
        //Data Seeeding
        [HttpGet]

        public  IActionResult Create()
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
        // To Validate token Handelar
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid) {

                model.Categories = context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name, })
                .OrderBy(x => x.Text)
                .ToList();

                model.Devices = context.Devices.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, }).ToList();
                return View(model);
            }
            await gamesService.Create(model);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            var game  = gamesService.GetByID(id);

             if (game is null)
            {
                return NotFound();
            }

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = categoriesService.GetSelectList(),
                Devices = devicesService.GetSelectList(),
                CurrentCover = game.Cover
            };

            return View(viewModel);
        }

        [HttpPost]
        // To Validate token Handelar
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                model.Categories = context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name, })
                .OrderBy(x => x.Text)
                .ToList();

                model.Devices = context.Devices.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, }).ToList();
                return View(model);
            }
            var game = await gamesService.Update(model);

            if (game is  null)
            { return BadRequest(); }
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var isDeleted = gamesService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }


    }
}
