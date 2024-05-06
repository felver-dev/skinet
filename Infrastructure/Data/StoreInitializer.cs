using back.Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Data
{
	public class StoreInitializer
	{
		public static async void Seed(IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var services = scope.ServiceProvider;
			var context = services.GetRequiredService<StoreContext>();
			var logger = services.GetRequiredService<ILogger<Program>>();	
			
			try
			{
				var PendingMigrations = context.Database.GetPendingMigrations();
				if(PendingMigrations.Any())
				{
					await context.Database.MigrateAsync();	
				}
				
				await StoreContextSeed.SeedAsync(context);
				
			}catch(Exception ex)
			{
				logger.LogError(ex, "Skinet Logger Console: An Error occured during migrations");
			}
			
		}
	}
}