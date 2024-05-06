using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.context
{
	public static class ServicesCollectionsExtensions
	{
		public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<StoreContext>(options => 
			{
				var DefaultConnection = configuration.GetConnectionString("DefaultConnection");
				options.UseMySql(DefaultConnection, ServerVersion.AutoDetect(DefaultConnection));
			});
			
			return services;
		}
	}
}