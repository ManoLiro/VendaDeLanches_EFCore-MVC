using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{
	[Table("Lanches")]
	public class Lanche
	{
		[Key]
		public int LancheId { get; set; }
		[Required(ErrorMessage = "Informe o Nome do Lanche")]
		[Display(Name = "Nome do Lanche")]
		[StringLength(80, MinimumLength = 10, ErrorMessage = "{0} deve ter no minimo {1} e no maximo {2} caractteres")]
		public string CategoriaNome { get; set; }
		[Required(ErrorMessage = "Informe a descricao curta do Lanche")]
		[Display(Name = "Descricao Curta do Lanche")]
		[StringLength(200, MinimumLength = 20, ErrorMessage = "{0} deve ter no minimo {1} e no maximo {2} caractteres")]
		public string DescricaoCurta { get; set; }
		[Required(ErrorMessage = "Informe a Decricao detalhada do Lanche")]
		[Display(Name = "Descricao Detalhada do Lanche")]
		[StringLength(200, MinimumLength = 20, ErrorMessage = "{0} deve ter no minimo {1} e no maximo {2} caractteres")]
		public string DescricaoDetalhada { get; set; }
		[Required(ErrorMessage = "Informe o Valor do Lanche")]
		[Display(Name = "Valor do Lanche")]
		[Column(TypeName="decimal(10,2)")]
		[Range(1,999.99,ErrorMessage = "O valor deve estar entre 1 e 999,99")]
		public decimal Preco { get; set; }
		[Display(Name = "URL da Imagem")]
		[StringLength(200,ErrorMessage = "{0} Deve ter no maximo {1} caracteres")]
		public string ImagemUrl { get; set; }
		[Display(Name = "URL da Thumbnail")]
		[StringLength(200, ErrorMessage = "{0} Deve ter no maximo {1} caracteres")]
		public string ImagemThumbnailUrl { get; set; }
		[Display(Name = "Preferido?")]
		public bool IsLanchePreferido { get; set; }
		[Display(Name = "Estoque?")]
		public bool EmEstoque { get; set; }

		public int CategoriaId { get; set; }
		public virtual Categoria Categoria { get; set; }
	}
}
