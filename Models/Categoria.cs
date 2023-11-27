using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{

	[Table("Categorias")]
	public class Categoria
	{
		[Key]
        public int CategoriaId { get; set; }
		[Required(ErrorMessage = "Informe o Nome da Categoria")]
		[StringLength(100, ErrorMessage = "O tamanho máximo é de 100 Catacteres")]
		[Display(Name = "Nome")]
		public string CategoriaNome { get; set; }
		[Required(ErrorMessage = "Informe a Descricao da Categoria")]
		[StringLength(200, ErrorMessage = "O tamanho máximo é de 200 Catacteres")]
		[Display(Name = "Descricao")]
		public string Descricao { get; set; }

		public List<Lanche> Lanches { get; set;}
    }
}
