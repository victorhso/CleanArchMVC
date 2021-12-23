using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        public async Task<ProductDTO> GetById(int? ID)
        {
            var productEntity = await _productRepository.GetByIdAsync(ID);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? ID)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(ID);

            return _mapper.Map<ProductDTO>(productEntity);

        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Remove(int? ID)
        {
            var productEntity = _productRepository.GetByIdAsync(ID).Result;
            await _productRepository.RemoveAsync(productEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
