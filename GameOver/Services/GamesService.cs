using GameOver.Models;
using GameOver.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GameOver.Services
{
    public class GamesService : IGamesService
	{
		private readonly ApplicationDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;

		private readonly string _ImagePath;

		public GamesService(ApplicationDbContext context  , IWebHostEnvironment webHostEnvironment)
        {
			this.context = context;
			this.webHostEnvironment = webHostEnvironment;
			_ImagePath = $"{webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";

		}

        public IEnumerable<Game> GetAll()
        {
            return context.Games
           .Include(g => g.Category)
           .Include(g => g.Devices)
           .ThenInclude(d => d.Device)
           .AsNoTracking()
           .ToList();

        }
        public async Task Create(CreateGameViewModel model)
		{
			//guid with extension
			var CoverName = await SaveCover(model.Cover);

			Game game = new()
			{
				Name = model.Name,
				Description = model.Description,
				Cover = CoverName,
				CategoryId = model.CategoryId,
				Devices = model.SelectedDevices.Select(D => new GameDevice { DeviceId = D}).ToList()
			};
			context.Add(game) ;
			context.SaveChanges() ;	
				 
		}

        public Game? GetByID(int id)
        {
            return context.Games.Include(x => x.Name).Include(y => y.Devices).ThenInclude(d => d.Device).AsNoTracking().SingleOrDefault(g => g.Id == id);
        }

        public async Task<Game?> Update(EditGameFormViewModel model)
        {
			var game = context.Games.Include(x => x.Devices).SingleOrDefault(g => g.Id  == model.Id);

			if (game is null)
			{
				return null;
			}
			var hasNewCover = model.Cover is not null;
			var oldCover = game.Cover;
			game.Name = model.Name;
			game.Description = model.Description;
			game.CategoryId = model.CategoryId;
			game.Devices = model.SelectedDevices.Select(d => new GameDevice {DeviceId = d}).ToList();

			if(hasNewCover)
			{
				game.Cover = await SaveCover(model.Cover!);
			}

			var affectefRows = context.SaveChanges();
			if(affectefRows > 0) {

				if (hasNewCover)
				{
					var cover = Path.Combine(_ImagePath, oldCover);
					File.Delete(cover);
				}
				return game;

			}
			else
			{
                var cover = Path.Combine(_ImagePath, game.Cover);
                File.Delete(cover);
				return null;
            }
        }

		public async Task<string> SaveCover(IFormFile Cover)
		{
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";

            var path = Path.Combine(_ImagePath, CoverName);

            using var stream = File.Create(path);

            await Cover.CopyToAsync(stream);

			return CoverName ;
        }

        public bool Delete(int id)
        {
			var isDeleted = false;

			var game = context.Games.Find(id);

			if(game is null)
			{
				return isDeleted;
			}

			var affectefRows = context.SaveChanges();
            if ( affectefRows > 0)
            {
				var cover = Path.Combine(_ImagePath , game.Cover)
				; File.Delete(cover);
                
            }
            context.Games.Remove(game);
			return isDeleted;
        }
    }
}
