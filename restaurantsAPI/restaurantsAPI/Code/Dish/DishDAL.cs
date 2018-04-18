using Microsoft.EntityFrameworkCore;
using restaurantsAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsAPI.Code.Dish
{
    public class DishDAL
    {
		#region Atributos e propriedades

		private readonly RestaurantContext _context;

		#endregion

		#region Construtores

		public DishDAL(RestaurantContext context)
		{
			_context = context;
		}

		#endregion

		#region Métodos

		//INSERT
		public async Task<int> InsertDish(Models.Dish dish)
		{
			_context.Dishs.Add(dish);
			return await _context.SaveChangesAsync();
		}

		//UPDATE
		public async Task<int> UpdateDish(Models.Dish dish)
		{
			try
			{
				_context.Entry(dish).State = EntityState.Modified;

				return await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		//DELETE
		public async Task<int> DeleteDish(int id)
		{
			var dish = await _context.Dishs.SingleOrDefaultAsync(m => m.Id == id);

			_context.Dishs.Remove(dish);
			return await _context.SaveChangesAsync();
		}

		#endregion
	}
}
