
using Microsoft.EntityFrameworkCore;
using StoreRouteDomain;
using StoreRouteDomain.Mapping.Products;
using StoreRouteDomain.ServicesContract;
using StoreRouteRepository;
using StoreRouteRepository.Data;
using StoreRouteRepository.Data.Contexts;
using StoreRouteService.Services.Products;

namespace StoreRouteAPI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//connection string
			builder.Services.AddDbContext<StoreDbContext>(option =>
			{
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

			
			});
			builder.Services.AddScoped<IProductService , ProductService>();			//dependency injection
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();					//dependency injection
			builder.Services.AddAutoMapper(M => M.AddProfile(new ProductProfile()));//dependency injection

			var app = builder.Build();

			using var Scope = app.Services.CreateScope();
			var Services = Scope.ServiceProvider;
			var Context = Services.GetRequiredService<StoreDbContext>();
			var loggerFactory = Services.GetRequiredService<ILoggerFactory>();


			try
			{
				await Context.Database.MigrateAsync();//update Database
				await StoreDbCOntextSeed.SeedAsync(Context);
			}
			catch (Exception ex) 
			{

				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "there are problems during apply migration");
			
			}

			////=============================================
			////Update Database Automarically
			//StoreDbContext context = new StoreDbContext();
			//context.Database.MigrateAsync();// Update Database
			////===============================================

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
