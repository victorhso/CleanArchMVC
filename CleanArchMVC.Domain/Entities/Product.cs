using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string DS_NAME { get; private set; }
        public string DS_DESCRIPTION { get; private set; }
        public decimal VL_PRICE { get; private set; }
        public int QTY_STOCK { get; private set; }
        public string DS_IMAGE{ get; private set; }

        public int ID_CATEGORY { get; set; }
        public Category Category { get; set; }

        public Product(string ds_name, string ds_description, decimal vl_price, int qty_stock, string ds_image)
        {
            ValidateDomain(ds_name, ds_description, vl_price, qty_stock, ds_image);
        }

        public Product(int id_product, string ds_name, string ds_description, decimal vl_price, int qty_stock, string ds_image)
        {
            DomainExceptionValidation.When(id_product < 0, "Invalid ID value");

            ID = id_product;
            ValidateDomain(ds_name, ds_description, vl_price, qty_stock, ds_image);
        }

        private void ValidateDomain(string ds_name, string ds_description, decimal vl_price, int qty_stock, string ds_image)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_name), "invalid name! Name is required.");

            DomainExceptionValidation.When(ds_name.Length < 3, "invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_description), "invalid description! Description is required.");

            DomainExceptionValidation.When(ds_description.Length < 5, "invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(vl_price < 0, "invalid price value.");

            DomainExceptionValidation.When(qty_stock < 0, "invalid stock value.");

            DomainExceptionValidation.When(ds_image.Length >= 250, "invalid image name, too long, maximum 250 characters.");

            DS_NAME = ds_name;  
            DS_DESCRIPTION = ds_description;    
            VL_PRICE = vl_price;
            QTY_STOCK = qty_stock;
            DS_IMAGE = ds_image;
        }
        public void Update(string ds_name, string ds_description, decimal vl_price, int qty_stock, string ds_image, int id_category)
        {
            ValidateDomain(ds_name, ds_description, vl_price, qty_stock, ds_image);
            ID_CATEGORY = id_category;
        }
    }
}
