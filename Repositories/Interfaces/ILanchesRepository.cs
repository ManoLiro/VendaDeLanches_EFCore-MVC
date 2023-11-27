using VendaDeLanches.Models;

namespace VendaDeLanches.Repositories.Interfaces
{
	public interface ILanchesRepository
	{
		IEnumerable<Lanche> Lanches { get; }
		IEnumerable<Lanche> LanchesPreferidos { get; }
		Lanche GetLancheById(int id);
	}
}
