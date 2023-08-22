﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Services
{
	public class CategoriesService : ICategoriesService
	{
		private readonly ApplicationDbContext context;

		public CategoriesService(ApplicationDbContext context)
        {
			this.context = context;
		}
        public IEnumerable<SelectListItem> GetSelectList()
		{
			return context.Categories.Select(c => new SelectListItem {Value = c.Id.ToString(), Text = c.Name})
				.OrderBy(c => c.Text)
				.AsNoTracking()
				.ToList();
		}
	}
}
