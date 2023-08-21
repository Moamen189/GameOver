namespace GameOver.ViewModels
{
	public class CreateGameViewModel
	{

		[MaxLength(250)]
		public string Name { get; set; } = string.Empty;


		[MaxLength(1000)]
		public string Description { get; set; } = string.Empty;

		public int CategoryId { get; set; }

		public List<int> SelectedDevices { get; set; } = new List<int>();

		public IFormFile Cover { get; set; } = default!;

	}
}
