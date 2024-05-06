using back.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.context
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options) : base(options) 
		{}

		// public DbSet<Product> Products { get; set; }
		public DbSet<Product> Products => Set<Product>();	
		
	}
}