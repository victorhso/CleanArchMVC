using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ID);

            if (product.Equals(null))
                throw new ApplicationException($"Entidade não encontrada.");
            else
            {
                product.Update(request.DS_NAME, request.DS_DESCRIPTION, request.VL_PRICE, request.QTY_STOCK, request.DS_IMAGE, request.ID_CATEGORY);

                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
