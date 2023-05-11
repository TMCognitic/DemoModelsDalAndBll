using BLL.Entities;
using BLL.Repositories;
using DemoModels.Dto;
using DemoModels.Infrastrucutre;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productRepository.Get().ToList());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product? product = _productRepository.Get(id);
            return product is null ? NotFound() : Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDto dto)
        {
            return Ok(_productRepository.Insert(new Product(dto.Name, dto.Price)));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public CallResult Put(int id, [FromBody] UpdateProductDto dto)
        {
            try
            {
                Product? product = _productRepository.Get(id);
            
                if(product is null)
                {
                    return CallResult.Failure(HttpStatusCode.NotFound, "Produit non trouvé", new { Id = id });
                }

                product.Price = dto.Price;

                if (!_productRepository.Update(product))
                {
                    return CallResult.Failure(HttpStatusCode.NotFound, "Produit non trouvé lors de la modification", new { Id = id });
                }

                return CallResult.Success();
            }
            catch (Exception ex)
            {
                return CallResult.Failure(HttpStatusCode.InternalServerError, ex.Message, new { InnerErrorMessage = ex.InnerException?.Message, ExceptionType = ex.GetType().ToString() });
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_productRepository.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
