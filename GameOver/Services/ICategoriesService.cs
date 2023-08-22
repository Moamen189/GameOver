using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Services
{
	public interface ICategoriesService
	{
		IEnumerable<SelectListItem> GetSelectList();
	}
}
