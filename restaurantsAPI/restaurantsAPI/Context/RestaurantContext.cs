using Microsoft.EntityFrameworkCore;
using restaurantsAPI.Models;


namespace restaurantsAPI.Context
{
	public class RestaurantContext : DbContext
    {
		#region Atributos e propriedades

		public DbSet<Restaurant> Restaurants { get; set; }

		public DbSet<Dish> Dishs { get; set; }

		#endregion

		#region Construtores

		public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

		#endregion

		#region Métodos

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Dish>()
				.HasOne(p => p.Restaurants)
				.WithMany(b => b.Dishs)
				.OnDelete(DeleteBehavior.Cascade);
		}

		#endregion
	}
}
