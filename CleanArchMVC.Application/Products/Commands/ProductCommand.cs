using CleanArchMVC.Domain.Entities;
using MediatR;

namespace CleanArchMVC.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string DS_NAME { get; set; }
        public string DS_DESCRIPTION { get; set; }
        public decimal VL_PRICE { get; set; }
        public int QTY_STOCK { get; set; }
        public string DS_IMAGE { get; set; }
        public int ID_CATEGORY { get; set; }
    }
}
