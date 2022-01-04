using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.DS_NAME, request.DS_DESCRIPTION, request.VL_PRICE, request.QTY_STOCK, request.DS_IMAGE);

            if (product.Equals(null))
                throw new ApplicationException($"Erro ao criar entidade.");
            else
            {
                product.ID_CATEGORY = request.ID_CATEGORY;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
