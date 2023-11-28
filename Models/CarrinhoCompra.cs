using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using VendaDeLanches.Context;
using VendaDeLanches.Migrations;

namespace VendaDeLanches.Models
{
    [Table("CarrinhoCompras")]
    public class CarrinhoCompra
    {
        private readonly AppDbContext _Context;

        public CarrinhoCompra(AppDbContext context)
        {
            _Context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public CarrinhoCompraItem CarrinhoCompraItem { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems = new List<CarrinhoCompraItem>();
        public static CarrinhoCompra GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var context = service.GetService<AppDbContext>();
            string CarringoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", CarringoId);
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = CarringoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _Context.CarrinhoCompraItens.FirstOrDefault(
                s=> s.Lanche.LancheId == lanche.LancheId &&
                s.CarrinhoCompraId == CarrinhoCompraId
                );

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _Context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _Context.SaveChanges();

        }

        public void RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _Context.CarrinhoCompraItens.FirstOrDefault(
              s => s.Lanche.LancheId == lanche.LancheId &&
              s.CarrinhoCompraId == CarrinhoCompraId
              );

            int QuantidadeLocal = 0;

            if( carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                
            }
            else
            {
                _Context.Remove( carrinhoCompraItem );
            }
            _Context.SaveChanges();
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ?? 
                (CarrinhoCompraItems = 
                _Context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s=> s.Lanche)
                .ToList());
        }
        public void LimparCarrinho()
        {
           var CarrinhoCompraItem = _Context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);
            _Context.Remove(CarrinhoCompraItem);
            _Context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _Context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }

    }
}
