using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ProductDTO> GetById(int? ID)
        {
            var productByIdQuery = new GetProductByIdQuery(ID.Value);

            if(productByIdQuery.Equals(null))
                throw new Exception($"Entidade não foi carregada.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategory(int? ID)
        {
            var productByIdQuery = new GetProductByIdQuery(ID.Value);

            if (productByIdQuery.Equals(null))
                throw new Exception($"Entidade não foi carregada.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);

        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery.Equals(null))
                throw new Exception($"Entidade não foi carregada.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(productCreateCommand);
        }

        public async Task Remove(int? ID)
        {
            var productRemoveCommand = new ProductRemoveCommand(ID.Value);

            if (productRemoveCommand.Equals(null))
                throw new Exception($"Entidade não foi carregada.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productUpdateCommand);
        }
    }
}
