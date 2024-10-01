using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRouteDomain.DTOs.Products
{
	public class TypeBrandDto
	{
		public string Name { get; set; }
		public DateTime CreateTime { get; set; } = DateTime.Now;
	}
}
