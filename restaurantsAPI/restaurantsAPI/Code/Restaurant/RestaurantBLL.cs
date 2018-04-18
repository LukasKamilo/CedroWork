using restaurantsAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsAPI.Code.Restaurant
{
    public class RestaurantBLL
    {

		#region Atributos e propriedades

		private readonly RestaurantContext _context;

		#endregion

		#region Construtores

		public RestaurantBLL(RestaurantContext context)
		{
			_context = context;
		}

		#endregion

		#region Métodos

		//INSERT
		public async Task<int> InsertRestaurant(Models.Restaurant restaurant)
		{
			RestaurantDAL DAL = new RestaurantDAL(_context);
			return await DAL.InsertRestaurant(restaurant);
		}

		//UPDATE
		public async Task<int> UpdateRestaurant(Models.Restaurant restaurant)
		{
			RestaurantDAL DAL = new RestaurantDAL(_context);
			return await DAL.UpdateRestaurant(restaurant);
		}

		//DELETE
		public async Task<int> DeleteRestaurant(int id)
		{
			RestaurantDAL DAL = new RestaurantDAL(_context);
			return await DAL.DeleteRestaurant(id);
		}

		#endregion

	}
}
