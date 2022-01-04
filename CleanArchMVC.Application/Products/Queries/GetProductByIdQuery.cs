using CleanArchMVC.Domain.Entities;
using MediatR;

namespace CleanArchMVC.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ID { get; set; }

        public GetProductByIdQuery(int id)
        {
            ID = id;
        }
    }
}
