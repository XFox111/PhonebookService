namespace PhonebookService.Domain.Queries;

/// <summary>
/// A model that represents a search/filter query for phonebook
/// </summary>
public class PhonebookFilterQuery
{
	/// <summary>
	/// Number of a page to show. Starts from one.
	/// </summary>
	/// <value>Default is 1</value>
	public int Page { get; set; } = 1;

	/// <summary>
	/// Optional property to filter records that contain the value in their <see cref="Models.PhonebookRecord.FirstName"/>
	/// </summary>
	public string? FirstName { get; set; }

	/// <summary>
	/// Optional property to filter records that match the city name
	/// </summary>
	public string? City { get; set; }

	/// <summary>
	/// Optional property to filter records that match the phone number
	/// </summary>
	public string? Phone { get; set; }

	/// <summary>
	/// Optional property to filter records that match the zip code
	/// </summary>
	public string? ZipCode { get; set; }

	/// <summary>
	/// Optional property to sort the result collection by <see cref="FirstName"/>
	/// </summary>
	/// <value>Default is 0 (None)</value>
	public SortMode Sort { get; set; } = SortMode.None;
}
