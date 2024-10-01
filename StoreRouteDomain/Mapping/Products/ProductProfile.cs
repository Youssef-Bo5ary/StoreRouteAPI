using AutoMapper;
using StoreRouteDomain.DTOs.Products;
using StoreRouteDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRouteDomain.Mapping.Products
{
	public class ProductProfile : Profile
	{
        public ProductProfile()
        {
			CreateMap<Product, ProductDto>()
				.ForMember(d=>d.BrandName,options=> options.MapFrom(s=>s.brand.Name))
				.ForMember(d => d.TypeName, options => options.MapFrom(s => s.ProductType.Name));
			CreateMap<ProductBrand, TypeBrandDto>();
			CreateMap<ProductType, TypeBrandDto>();
		}
    }
}
