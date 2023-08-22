using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Services
{
	public interface IDevicesService
	{
		IEnumerable<SelectListItem> GetSelectList();
	}
}
