using System.Reflection;
using System.Text.Json;
using back.Core.Entities;
using back.Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Data
{
	public class StoreContextSeed
	{
		public static async Task SeedAsync(StoreContext context)
		{
			var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			
			if(!context.ProductBrands.Any())
			{
				var brandsData = File.ReadAllText("./Infrastructure/SeedData/brands.json");
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
				context.ProductBrands.AddRange(brands);
			}
			
			if(!context.ProductTypes.Any())
			{
				var typesData = File.ReadAllText("./Infrastructure/SeedData/types.json");
				var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
				context.ProductTypes.AddRange(types);	
			}
			
			if(!context.Products.Any())
			{
				var productData = File.ReadAllText("./Infrastructure/SeedData/products.json");
				var products = JsonSerializer.Deserialize<List<Product>>(productData);
				context.Products.AddRange(products);
			}

			if (context.ChangeTracker.HasChanges())
			{
				await context.SaveChangesAsync();
			}
		}
	}
}