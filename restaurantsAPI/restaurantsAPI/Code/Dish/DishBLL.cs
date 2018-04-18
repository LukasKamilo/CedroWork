using restaurantsAPI.Context;
using System.Threading.Tasks;

namespace restaurantsAPI.Code.Dish
{
	public class DishBLL
    {
		#region Atributos e propriedades

		private readonly RestaurantContext _context;

		#endregion

		#region Construtores

		public DishBLL(RestaurantContext context)
		{
			_context = context;
		}

		#endregion

		#region Métodos

		//INSERT
		public async Task<int> InsertDish(Models.Dish restaurant)
		{
			DishDAL DAL = new DishDAL(_context);
			return await DAL.InsertDish(restaurant);
		}

		//UPDATE
		public async Task<int> UpdateDish(Models.Dish restaurant)
		{
			DishDAL DAL = new DishDAL(_context);
			return await DAL.UpdateDish(restaurant);
		}

		//DELETE
		public async Task<int> DeleteDish(int id)
		{
			DishDAL DAL = new DishDAL(_context);
			return await DAL.DeleteDish(id);
		}

		#endregion
	}
}
