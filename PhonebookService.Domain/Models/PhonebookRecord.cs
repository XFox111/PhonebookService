namespace PhonebookService.Domain.Models;

#pragma warning disable CS8618 // Non-nullable property must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

/// <summary>
/// Entity model that represents a record in a phonebook
/// </summary>
public class PhonebookRecord
{
	public int Id { get; set; }

	public string Email { get; set; }

	public string PhoneNumber { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string StreetAddress { get; set; }

	public string City { get; set; }

	public string ZipCode { get; set; }
}
