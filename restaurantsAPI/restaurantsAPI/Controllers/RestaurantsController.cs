using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurantsAPI.Context;
using restaurantsAPI.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using restaurantsAPI.Code.Restaurant;

namespace restaurantsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
		#region Atributos e propriedades

		private readonly RestaurantContext _context;

		#endregion

		#region Construtores

		public RestaurantsController(RestaurantContext context)
		{
			_context = context;
		}

		#endregion

		#region Métodos

		// GET: Get list restaurants on database
		/// <summary>
		/// Retorna uma lista de restaurantes
		/// </summary>
		/// <remarks>
		/// Retorna uma lista de restaurantes
		/// </remarks>
		/// <returns></returns>
		[HttpGet]
		[SwaggerOperation(Tags = new[] { "Restaurants" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "Nenhum registro encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public IActionResult GetRestaurants(string name = null)
		{
			try
			{
				if (!String.IsNullOrEmpty(name))
				{
					return Ok(_context.Restaurants.Where(x => x.Name.Contains(name)).ToList());
				}
				else
				{
					return Ok(_context.Restaurants);
				}
				
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		// GET: Get restaurant on database
		/// <summary>
		/// Retorna um restaurante
		/// </summary>
		/// <remarks>
		/// Retorna um restaurante
		/// </remarks>
		/// <returns></returns>
		[HttpGet("{id}")]
		[SwaggerOperation(Tags = new[] { "Restaurants" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "Nenhum registro encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> GetRestaurant([FromRoute] int? id)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.Id == id);

				if (restaurant == null)
				{
					return NotFound();
				}

				return Ok(restaurant);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		// PUT: Update restaurant on database
		/// <summary>
		/// Atualiza restaurante na base de dados
		/// </summary>
		/// <remarks>
		/// Atualiza restaurante na base de dados
		/// </remarks>
		/// <returns></returns>
		[HttpPut]
		[SwaggerOperation(Tags = new[] { "Restaurants" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "O restaurante informado não foi encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> PutRestaurant([FromBody] Restaurant restaurant)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				RestaurantBLL BLL = new RestaurantBLL(_context);

				return Ok(await BLL.UpdateRestaurant(restaurant));
			}
			catch (DbUpdateConcurrencyException ex)
			{
				if (!RestaurantExists(restaurant.Id))
				{
					return NotFound();
				}
				else
				{
					return BadRequest(ex.Message);
				}
			}
		}

		// POST: Insert restaurant on database
		/// <summary>
		/// Insere um restaurante na base de dados
		/// </summary>
		/// <remarks>
		/// Insere um restaurante na base de dados
		/// </remarks>
		/// <returns></returns>
		[HttpPost]
		[SwaggerOperation(Tags = new[] { "Restaurants" })]
		[SwaggerResponse(201, Description = "Restaurante criado com sucesso!")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> PostRestaurant([FromBody] Restaurant restaurant)
		{
			try
			{
				RestaurantBLL BLL = new RestaurantBLL(_context);

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				await BLL.InsertRestaurant(restaurant);

				return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE: Remove restaurant on database
		/// <summary>
		/// Remove restaurante na base de dados
		/// </summary>
		/// <remarks>
		/// Remove restaurante na base de dados
		/// </remarks>
		/// <returns></returns>
		[HttpDelete("{id}")]
		[SwaggerOperation(Tags = new[] { "Restaurants" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "O restaurante informado não foi encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
		{
			try
			{
				RestaurantBLL BLL = new RestaurantBLL(_context);
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				return Ok(await BLL.DeleteRestaurant(id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private bool RestaurantExists(int id)
		{
			return _context.Restaurants.Any(e => e.Id == id);
		}

		#endregion

	}
}