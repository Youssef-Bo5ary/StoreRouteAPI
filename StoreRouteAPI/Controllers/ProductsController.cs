using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreRouteDomain.ServicesContract;

namespace StoreRouteAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
        {
			_productService = productService;
		}


        [HttpGet]// Gey BaseUrl/ api / Products
		public async Task<IActionResult> GetAllProducts()
		{ 
			var result =  await _productService.GetAllProductsAsync();
			return Ok(result);
		}

		[HttpGet("brands")]// Gey BaseUrl/ api / Products/brands ====> change in segment to avoid error
		public async Task<IActionResult> GetAllBrands()
		{ 
			var result = await  _productService.GetAllBrandsAsync();
			return Ok(result);
		}

		[HttpGet("types")]

		public async Task<IActionResult> GetAllTypesAsync()
		{ 
			var result =await _productService.GetAllTypesAsync();
			return Ok(result);
		
		}
		[HttpGet("id")]
		public async Task<IActionResult> GetProductById(int? id)
		{
			if (id == null) return BadRequest("id invalid!!");
			var result = await _productService.GetProductById(id.Value);
			return Ok(result);
		}
	}
}
