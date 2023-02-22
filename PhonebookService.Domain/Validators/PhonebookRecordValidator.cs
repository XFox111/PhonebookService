using System.ComponentModel.DataAnnotations;
using FluentValidation;
using PhonebookService.Domain.Models;

namespace PhonebookService.Domain.Validators;

/// <summary>
/// Validator class for <see cref="Models.PhonebookRecord"/>
/// </summary>
public class PhonebookRecordValidator : AbstractValidator<PhonebookRecord>
{
	public PhonebookRecordValidator()
	{
		RuleFor(i => i.Email).EmailAddress();
		RuleFor(i => i.PhoneNumber).Must(i => new PhoneAttribute().IsValid(i));	// The easiest way is to use .NET built-in validator
		RuleFor(i => i.FirstName).NotEmpty();
		RuleFor(i => i.LastName).NotEmpty();
		RuleFor(i => i.StreetAddress).NotEmpty();
		RuleFor(i => i.City).NotEmpty();
		// Fun fact: the longest settlement name is "Llanfair­pwllgwyngyll­gogery­chwyrn­drobwll­llan­tysilio­gogo­goch" (66 characters)
		// It is a village located in Wales, UK
		RuleFor(i => i.ZipCode).Must(i => new ZipCodeValidator().IsValid(i));
	}
}
