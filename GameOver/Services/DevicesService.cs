using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameOver.Services
{
	public class DevicesService : IDevicesService
	{
		private readonly ApplicationDbContext context;

		public DevicesService(ApplicationDbContext context)
        {
			this.context = context;
		}
        public IEnumerable<SelectListItem> GetSelectList()
		{
			return context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name}).OrderBy(x => x.Text).AsNoTracking().ToList();
		}
	}
}
