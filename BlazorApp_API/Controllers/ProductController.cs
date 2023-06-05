using BlazorApp_Business.Repository.IRepository;
using BlazorApp_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int? productId)
        {
            if(productId == null || productId == 0)
            {
                return BadRequest(new ErrorDto()
                {
                    ErrorMessage = "Ugyldig Id.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var product = await _productRepository.GetById(productId.Value);
            if(product == null)
            {
                return BadRequest(new ErrorDto()
                {
                    ErrorMessage = "Produkt finnes ikke.",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return Ok(product);
        }
    }
}
