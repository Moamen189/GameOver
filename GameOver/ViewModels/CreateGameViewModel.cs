using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.ViewModels
{
	public class CreateGameViewModel
	{

		[MaxLength(250)]
		public string Name { get; set; } = string.Empty;
		public int CategoryId { get; set; }

		public List<int> SelectedDevices { get; set; } = new List<int>();

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

		[MaxLength(1000)]
		public string Description { get; set; } = string.Empty;

		//form validation
		public IFormFile Cover { get; set; } = default!;

	}
}
