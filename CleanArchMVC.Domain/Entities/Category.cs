using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string DS_NAME { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string ds_name)
        {
            ValidateDomain(ds_name);
        }

        public Category(int id_category, string ds_name)
        {
            DomainExceptionValidation.When(id_category < 3, "Invalid ID value!");

            ID = id_category;
            ValidateDomain(ds_name);
        }

        private void ValidateDomain(string ds_name)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_name), "invalid name! Name is required.");

            DomainExceptionValidation.When(ds_name.Length < 3, "invalid name, too short, minimum 3 characters.");

            DS_NAME = ds_name;
        }
        public void Update(string ds_name)
        {
            ValidateDomain(ds_name);
        }
    }
}
