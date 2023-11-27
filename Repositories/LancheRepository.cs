using Microsoft.EntityFrameworkCore;
using VendaDeLanches.Context;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;
using System.Linq;

namespace VendaDeLanches.Repositories
{
	public class LancheRepository : ILanchesRepository
	{
		private readonly AppDbContext _context;
		public LancheRepository(AppDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

		public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(p => p.IsLanchePreferido).Include(c => c.Categoria);

		public Lanche GetLancheById(int id) => _context.Lanches.FirstOrDefault(p => p.LancheId == id);
	}
}
