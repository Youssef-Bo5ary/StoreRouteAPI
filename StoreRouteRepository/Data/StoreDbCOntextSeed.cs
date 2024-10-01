using Microsoft.Identity.Client;
using StoreRouteDomain.Entities;
using StoreRouteRepository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreRouteRepository.Data
{
	public class StoreDbCOntextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context)
		{
			if (_context.Brands.Count() == 0)
			{
				//Brand 
				//1. read data from json file

				var brandData = File.ReadAllText(@"..\StoreRouteRepository\Data\DataSeed\brands.json");

				//2. convert Json string to List<T>
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);//carry json file

				//3. seed data to DB
				if (brands is not null && brands.Count() > 0)
				{
					await _context.Brands.AddRangeAsync(brands); // put the json file in database
					await _context.SaveChangesAsync(); /// save changes


				}
			           //C: \Users\youusseff\source\repos\StoreRouteAPI\StoreRouteRepository\Data\DataSeed
				if (_context.Types.Count() == 0)
				{
					//Types 
					//1. read data from json file

					var TypeData = File.ReadAllText(@"..\StoreRouteRepository\Data\DataSeed\types.json");

					//2. convert Json string to List<T>
					var types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);//carry json file

					//3. seed data to DB
					if (types is not null && types.Count() > 0)
					{
						await _context.Types.AddRangeAsync(types); // put the json file in database
						await _context.SaveChangesAsync(); /// save changes

					}

				}

				if (_context.Products.Count() == 0)
				{
					//product 
					//1. read data from json file

					var ProductData = File.ReadAllText(@"..\StoreRouteRepository\Data\DataSeed\products.json");

					//2. convert Json string to List<T>
					var prod = JsonSerializer.Deserialize<List<Product>>(ProductData);//carry json file

					//3. seed data to DB
					if (prod is not null && prod.Count() > 0)
					{
						await _context.Products.AddRangeAsync(prod);
						await _context.SaveChangesAsync(); 

					}

				}

			}
		}
	}
}

