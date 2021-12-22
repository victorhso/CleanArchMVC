﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.Application.DTOs
{
    public class CategoryDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string DS_NAME { get; set; }
    }
}