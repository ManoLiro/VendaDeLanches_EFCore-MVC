using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendaDeLanches.Context;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Controllers
{
	public class HomeController : Controller
	{

		private readonly ILanchesRepository _lanchesRepository;

        public HomeController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult Index()
		{
			var LanchesFavoritos = _lanchesRepository.LanchesPreferidos;

			var LanchesPreferidos = new HomeIndexViewModel()
			{
                LanchePreferidos = LanchesFavoritos
			};

            return View(LanchesPreferidos);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
