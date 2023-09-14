﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalog.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,1)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }
        public float Stock { get; set; }
        public DateTime DateRegister { get; set; }
        public int CategoryId { get; set; } // chave estrangeira

        [JsonIgnore] // Acabar com o mapeamento 
        public Category Category { get; set; }

    }
}
// propriedades de navegação não são mapeadas 