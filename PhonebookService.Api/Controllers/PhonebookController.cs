using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PhonebookService.Domain.Models;
using PhonebookService.Domain.Queries;
using PhonebookService.Domain.Repositories;

namespace PhonebookService.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PhonebookController : Controller
{
	private readonly ILogger<PhonebookController> _logger;
	private readonly IPhonebookRepository _book;
	private readonly IValidator<PhonebookRecord> _validator;

	public PhonebookController(ILogger<PhonebookController> logger, IPhonebookRepository book, IValidator<PhonebookRecord> validator)
	{
		_logger = logger;
		_book = book;
		_validator = validator;
	}

	[HttpGet(Name = "Get")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAsync([FromQuery]PhonebookFilterQuery? query)
	{
		ICollection<PhonebookRecord> data = await _book.GetItemsAsync(query ?? new());

		return Json(data);
	}

	[HttpGet("{id}", Name = "GetOne")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetItemAsync(int id)
	{
		PhonebookRecord? record = await _book.GetItemByIdAsync(id);

		if (record is null)
			return NotFound();

		return Json(record);
	}

	[HttpPost(Name = "Create")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> CreateItemAsync([FromBody]PhonebookRecord item)
	{
		ValidationResult result = await _validator.ValidateAsync(item);

		if (!result.IsValid)
		{
			foreach (var i in result.Errors)
				ModelState.AddModelError(i.ErrorCode, i.ErrorMessage);

			return BadRequest();
		}

		PhonebookRecord entry = await _book.CreateItemAsync(item);

		return CreatedAtRoute("Get", routeValues: new { id = entry.Id }, value: entry);
	}

	[HttpPost("{id}", Name = "Update")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> UpdateItemAsync(int id, [FromBody]PhonebookRecord item)
	{
		ValidationResult result = await _validator.ValidateAsync(item);

		if (!result.IsValid)
		{
			foreach (var i in result.Errors)
				ModelState.AddModelError(i.ErrorCode, i.ErrorMessage);

			return BadRequest();
		}

		item.Id = id;
		PhonebookRecord entry = await _book.UpdateItemAsync(item);

		return Json(entry);
	}

	[HttpDelete("{id}", Name = "Delete")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> DeleteItemAsync(int id)
	{
		PhonebookRecord? item = await _book.GetItemByIdAsync(id);

		if (item is null)
			return NotFound();

		await _book.DeleteItemAsync(item);

		return NoContent();
	}
}
