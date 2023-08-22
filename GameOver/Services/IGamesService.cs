namespace GameOver.Services
{
	public interface IGamesService
	{
		Task Create(CreateGameViewModel model);
	}
}
