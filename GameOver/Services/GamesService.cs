﻿using Microsoft.AspNetCore.Hosting;

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
			_ImagePath = $"{webHostEnvironment.WebRootPath}/assets/images/games";
        }
        public Task Create(CreateGameViewModel model)
		{
			//guid with extension
			var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";

			var path = Path.Combine(_ImagePath , CoverName) ;
		}
	}
}
