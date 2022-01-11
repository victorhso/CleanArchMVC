using CleanArchMVC.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CleanArchMVC.Application.DTOs
{
    public class ProductDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string DS_NAME { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string DS_DESCRIPTION { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal VL_PRICE { get; set; }

        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int QTY_STOCK { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem do produto")]
        public string DS_IMAGE { get; set; }

        [DisplayName("Categoria")]
        [JsonIgnore]
        public Category Category { get; set; }

        [DisplayName("Categorias")]
        public int ID_CATEGORY { get; set; }
    }
}
