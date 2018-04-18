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
using restaurantsAPI.Code.Dish;

namespace restaurantsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/dishes")]
    public class DishesController : Controller
    {
		#region Atributos

		private readonly RestaurantContext _context;

		#endregion

		#region Construtores

		public DishesController(RestaurantContext context)
		{
			_context = context;
		}

		#endregion

		#region Métodos

		// GET: Get list Dishs on database
		/// <summary>
		/// Retorna uma lista de pratos
		/// </summary>
		/// <remarks>
		/// Retorna uma lista de pratos
		/// </remarks>
		/// <returns></returns>
		/// [HttpGet]
		[HttpGet]
		[SwaggerOperation(Tags = new[] { "Dishes" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "Nenhum registro encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public IActionResult GetDishs(string name = null)
		{
			try
			{
				if (!String.IsNullOrEmpty(name))
				{
					return Ok(_context.Dishs.Where(x => x.DishName.Contains(name)).ToList());
				}
				else
				{
					return Ok(_context.Dishs);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: Get dish on database
		/// <summary>
		/// Retorna um prato
		/// </summary>
		/// <remarks>
		/// Retorna um prato
		/// </remarks>
		/// <returns></returns>
		[HttpGet("{id}")]
		[SwaggerOperation(Tags = new[] { "Dishes" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "Nenhum registro encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> GetDish([FromRoute] int id)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var dish = await _context.Dishs.SingleOrDefaultAsync(m => m.Id == id);

				if (dish == null)
				{
					return NotFound();
				}

				return Ok(dish);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT: Update dish on database
		/// <summary>
		/// Atualiza um prato na base de dados
		/// </summary>
		/// <remarks>
		/// Atualiza um prato na base de dados
		/// </remarks>
		/// <returns></returns>
		[HttpPut]
		[SwaggerOperation(Tags = new[] { "Dishes" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "O prato informado não foi encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> PutDish([FromBody] Dish dish)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				DishBLL BLL = new DishBLL(_context);

				return Ok(await BLL.UpdateDish(dish));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DishExists(dish.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
		}

		// POST: Insert dish on database
		/// <summary>
		/// Insere um prato na base de dados
		/// </summary>
		/// <remarks>
		/// Insere um prato na base de dados
		/// </remarks>
		/// <returns></returns>
		[HttpPost]
		[SwaggerOperation(Tags = new[] { "Dishes" })]
		[SwaggerResponse(201, Description = "Prato criado com sucesso!")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> PostDish([FromBody] Dish dish)
		{
			try
			{

				DishBLL BLL = new DishBLL(_context);

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				await BLL.InsertDish(dish);

				return CreatedAtAction("GetDish", new { id = dish.Id }, dish);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE: Remove dish on database
		/// <summary>
		/// Remove um prato na base de dados
		/// </summary>
		/// <remarks>
		/// Remove um prato na base de dados
		/// </remarks>
		/// <returns></returns>
		[HttpDelete("{id}")]
		[SwaggerOperation(Tags = new[] { "Dishes" })]
		[SwaggerResponse(200, Description = "OK")]
		[SwaggerResponse(404, Description = "O prato informado não foi encontrado.")]
		[SwaggerResponse(400, Description = "Requisição inválida. Veja a mensagem para mais detalhes.")]
		public async Task<IActionResult> DeleteDish([FromRoute] int id)
		{
			try
			{
				DishBLL BLL = new DishBLL(_context);

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				return Ok(await BLL.DeleteDish(id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private bool DishExists(int id)
		{
			return _context.Dishs.Any(e => e.Id == id);
		}

		#endregion

	}
}