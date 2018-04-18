using Microsoft.EntityFrameworkCore;
using restaurantsAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsAPI.Code.Restaurant
{
    public class RestaurantDAL
    {
		#region Atributos e propriedades

		private readonly RestaurantContext _context;

		#endregion

		#region Construtores

		public RestaurantDAL(RestaurantContext context)
		{
			_context = context;
		}

		#endregion

		#region Métodos

		//INSERT
		public async Task<int> InsertRestaurant(Models.Restaurant restaurant)
		{
			_context.Restaurants.Add(restaurant);
			return await _context.SaveChangesAsync();
		}

		//UPDATE
		public async Task<int> UpdateRestaurant(Models.Restaurant restaurant)
		{
			try
			{
				_context.Entry(restaurant).State = EntityState.Modified;

				return await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		//DELETE
		public async Task<int> DeleteRestaurant(int id)
		{
			var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.Id == id);

			_context.Restaurants.Remove(restaurant);
			return await _context.SaveChangesAsync();
		}

		#endregion

	}
}
