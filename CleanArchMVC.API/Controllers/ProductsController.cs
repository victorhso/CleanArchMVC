using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var produtos = await _productService.GetProducts();

            if (produtos == null)
                return NotFound("Nenhum produto foi encontrado.");

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound("Produto não encontrado.");
            
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("Dados inválidos.");

            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.ID }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if(id != productDTO.ID || productDTO == null)
                return BadRequest("Dados inválidos.");

            await _productService.Update(productDTO);

            return Ok(productDTO);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound("Produto não encontrado.");

            await _productService.Remove(id);

            return Ok(product);
        }
    }
}
