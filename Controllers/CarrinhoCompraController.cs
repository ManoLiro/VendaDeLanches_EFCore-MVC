using Microsoft.AspNetCore.Mvc;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Controllers
{
    public class CarrinhoCompraController : Controller
    {

        public readonly ILanchesRepository _Lanche;
        public readonly CarrinhoCompra _CarrinhoCompra;

        public CarrinhoCompraController(ILanchesRepository lanche, CarrinhoCompra carrinhoCompra)
        {
            _Lanche = lanche;
            _CarrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _CarrinhoCompra.GetCarrinhoCompraItems();

            _CarrinhoCompra.CarrinhoCompraItems = itens;

            CarrinhoCompraViewModel vm = new CarrinhoCompraViewModel()
            {
                CarrinhoCompra = _CarrinhoCompra,
                CarrinhoCompraTotal = _CarrinhoCompra.GetCarrinhoCompraTotal(),
            };

            return View(vm);
        }
        public RedirectToActionResult AdicionarItemCarrinhoDeCompra(int LancheId)
        {
            var lancheSelecionado = _Lanche.GetLancheById(LancheId);
            if (lancheSelecionado != null) {
                _CarrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoverItemCarrinhoDeCompra(int LancheId)
        {
            var lancheSelecionado = _Lanche.GetLancheById(LancheId);
            if (lancheSelecionado != null)
            {
                _CarrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
