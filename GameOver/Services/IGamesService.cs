using GameOver.Models;

namespace GameOver.Services
{
	public interface IGamesService
	{
		Task Create(CreateGameViewModel model);

		IEnumerable<Game> GetAll();
	}
}
