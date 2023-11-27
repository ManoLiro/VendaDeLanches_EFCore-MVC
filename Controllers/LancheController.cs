using Microsoft.AspNetCore.Mvc;
using VendaDeLanches.Repositories;
using VendaDeLanches.Repositories.Interfaces;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Controllers
{
	public class LancheController : Controller
	{

		private readonly ILanchesRepository _repository;
        public LancheController(ILanchesRepository lancheRepository)
        {
            _repository = lancheRepository;
        }
        public IActionResult List()
		{
			ViewData["Titulo"] = "Todos os Lanches";
			//var lanches = _repository.Lanches;
			var lanchesViewModel = new LancheListViewModel();
			lanchesViewModel.Lanches = _repository.Lanches;
			lanchesViewModel.CategoriaAtual = "Categoria A";

			return View(lanchesViewModel);
		}
	}
}
