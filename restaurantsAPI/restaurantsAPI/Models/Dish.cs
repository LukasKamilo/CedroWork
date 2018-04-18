using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsAPI.Models
{
	[Table("Dish")]
    public class Dish
    {
		[Key()]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string DishName { get; set; }

		[Required]
		public decimal DishPrice { get; set; }

		public string DishImage { get; set; }

		[ForeignKey("FK_Dish_Restaurant_RestaurantId")]
		public int? RestaurantId { get; set; }

		public virtual Restaurant Restaurants { get; set; }
	}
}
