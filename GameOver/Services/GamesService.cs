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
			var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";

			var path = Path.Combine(_ImagePath , CoverName) ;

			using var stream = File.Create(path) ;

			await model.Cover.CopyToAsync(stream) ;

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
    }
}
