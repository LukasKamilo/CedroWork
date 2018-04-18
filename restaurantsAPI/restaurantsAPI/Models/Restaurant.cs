using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurantsAPI.Models
{
	[Table("Restaurant")]
    public class Restaurant
    {
		[Key()]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		public virtual ICollection<Dish> Dishs{get;set;}
	}
}
