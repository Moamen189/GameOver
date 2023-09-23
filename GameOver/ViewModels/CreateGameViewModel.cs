using GameOver.Attributes;
using GameOver.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.ViewModels
{
	public class CreateGameViewModel:GameFormViewModel
	{

        [AllowedExtensions(FileSettings.AllowsExtenstions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;

    }
}
