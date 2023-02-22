using PhonebookService.Domain.Models;
using PhonebookService.Domain.Queries;

namespace PhonebookService.Domain.Repositories;

/// <summary>
/// Interface for the phonebook repository
/// </summary>
public interface IPhonebookRepository
{
	/// <summary>
	/// Get items list based on the provided query
	/// </summary>
	/// <param name="query">Parameters for filtering and pagination</param>
	/// <returns>Collection of <see cref="Models.PhonebookRecord"/></returns>
	Task<ICollection<PhonebookRecord>> GetItemsAsync(PhonebookFilterQuery query);

	/// <summary>
	/// Get one item by its ID
	/// </summary>
	/// <param name="id">Id of the item</param>
	/// <returns>Matched <see cref="Models.PhonebookRecord"/> or null if none found</returns>
	Task<PhonebookRecord?> GetItemByIdAsync(int id);

	/// <summary>
	/// Add new item to a database
	/// </summary>
	/// <param name="item"><see cref="Models.PhonebookRecord"/> entity</param>
	/// <returns>The result <see cref="Models.PhonebookRecord"/> with assigned Id</returns>
	Task<PhonebookRecord> CreateItemAsync(PhonebookRecord item);

	/// <summary>
	/// Updates provided item in a database
	/// </summary>
	/// <param name="item">item to update. Id is required</param>
	/// <returns>The result <see cref="Models.PhonebookRecord"/> with assigned Id</returns>
	Task<PhonebookRecord> UpdateItemAsync(PhonebookRecord item);

	/// <summary>
	/// Deletes provided item from a database
	/// </summary>
	/// <param name="item"><see cref="Models.PhonebookRecord"/> to delete</param>
	Task DeleteItemAsync(PhonebookRecord item);
}
