using CleanArchMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
