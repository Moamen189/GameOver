using GameOver.Attributes;
using GameOver.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.ViewModels
{
	public class CreateGameViewModel
	{

		[MaxLength(250)]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Category")]
		public int CategoryId { get; set; }
		[Display(Name = " Supported Devices")]

		public List<int> SelectedDevices { get; set; } = default!;

		//for Selection by IEnumrable
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

		[MaxLength(1000)]
		public string Description { get; set; } = string.Empty;

		//form validation
		[AllowedExtensions(FileSettings.AllowsExtenstions) , MaxFileSize(FileSettings.MaxFileSizeInBytes)]
		
		public IFormFile Cover { get; set; } = default!;

	}
}
