using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalog.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>(); // boa prática iniciar a coleção que você vai usar para fazer a navegação
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }
        public ICollection<Product> Products { get; set; } // propriedade de navegação UM PARA MUITOS

    }
}
