using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreRouteDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRouteRepository.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p=> p.Name).HasMaxLength(255).IsRequired();
			builder.Property(p=> p.PictureUrl).IsRequired(true);
			builder.Property(p=> p.Price).HasColumnType("decimal(18,2)");
			builder.HasOne(p=> p.brand).WithMany().HasForeignKey(p=>p.BrandId).OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.TypeId).OnDelete(DeleteBehavior.SetNull);

			builder.Property(p=> p.BrandId).IsRequired(false);
			builder.Property(p => p.TypeId).IsRequired(false);

		}
	}
}
