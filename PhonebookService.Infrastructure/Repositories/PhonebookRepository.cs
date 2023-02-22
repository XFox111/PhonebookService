using PhonebookService.Domain.Models;
using PhonebookService.Domain.Queries;
using PhonebookService.Domain.Repositories;

namespace PhonebookService.Infrastructure.Repositories;

/// <summary>
/// Phonebook repository implementation
/// </summary>
public class PhonebookRepository : IPhonebookRepository
{
	private readonly PhonebookContext _context;

	public PhonebookRepository(PhonebookContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	/// <inheritdoc/>
	public async Task<PhonebookRecord> CreateItemAsync(PhonebookRecord item)
	{
		var entry = await _context.Records.AddAsync(item);

		await _context.SaveChangesAsync();

		return entry.Entity;
	}

	/// <inheritdoc/>
	public async Task DeleteItemAsync(PhonebookRecord item)
	{
		_context.Records.Remove(item);

		await _context.SaveChangesAsync();
	}

	/// <inheritdoc/>
	public async Task<PhonebookRecord?> GetItemByIdAsync(int id)
	{
		var entry = await _context.Records.FindAsync(id);

		return entry;
	}

	/// <inheritdoc/>
	public Task<ICollection<PhonebookRecord>> GetItemsAsync(PhonebookFilterQuery query)
	{
		IQueryable<PhonebookRecord> dbQuery = _context.Records;

		if (query.FirstName is not null)
			dbQuery = dbQuery.Where(i => i.FirstName.Contains(query.FirstName));

		if (query.Phone is not null)
			dbQuery = dbQuery.Where(i => i.PhoneNumber == query.Phone);

		if (query.City is not null)
			dbQuery = dbQuery.Where(i => i.City == query.City);

		if (query.ZipCode is not null)
			dbQuery = dbQuery.Where(i => i.ZipCode == query.ZipCode);

		if (query.Sort == SortMode.Ascending)
			dbQuery = dbQuery.OrderBy(i => i.FirstName);
		else if (query.Sort == SortMode.Descending)
			dbQuery = dbQuery.OrderByDescending(i => i.FirstName);

		ICollection<PhonebookRecord> list = dbQuery.Skip((query.Page - 1) * 5).Take(5).ToList();

		return Task.FromResult(list);
	}

	/// <inheritdoc/>
	public async Task<PhonebookRecord> UpdateItemAsync(PhonebookRecord item)
	{
		var entry = _context.Records.Update(item);

		await _context.SaveChangesAsync();

		return entry.Entity;
	}
}
