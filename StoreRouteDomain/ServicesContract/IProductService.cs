using StoreRouteDomain.DTOs.Products;
using StoreRouteDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRouteDomain.ServicesContract
{
	public interface IProductService
	{
		//interface of endpoints you want to create so you created a DTOs classes to be as a Model view 
		Task<IEnumerable<ProductDto>>GetAllProductsAsync();
		Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
		Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
		Task<ProductDto> GetProductById(int id);

	}
}
