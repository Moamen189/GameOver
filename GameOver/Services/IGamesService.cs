using GameOver.Models;

namespace GameOver.Services
{
	public interface IGamesService
	{
		Task Create(CreateGameViewModel model);

		Game? GetByID(int id);

		IEnumerable<Game> GetAll();
	}
}
