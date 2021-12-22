using CleanArchMVC.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMVC.Application.DTOs
{
    public class ProductDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string DS_NAME { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string DS_DESCRIPTION { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal VL_PRICE { get; set; }

        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int QTY_STOCK { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string DS_IMAGE { get; set; }

        public Category Category { get; set; }

        [DisplayName("Categories")]
        public int ID_CATEGORY { get; set; }
    }
}
