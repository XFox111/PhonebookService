using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhonebookService.Domain.Models;

namespace PhonebookService.Infrastructure.ModelConfigurations;

/// <summary>
/// EF entity model configuration class for <see cref="Domain.Models.PhonebookRecord"/>
/// </summary>
public class PhonebookRecordEntityTypeConfiguration
	: IEntityTypeConfiguration<PhonebookRecord>
{
	public void Configure(EntityTypeBuilder<PhonebookRecord> builder)
	{
		builder.HasKey(i => i.Id);
		builder.Property(i => i.FirstName).IsRequired();
		builder.Property(i => i.LastName).IsRequired();
		builder.Property(i => i.Email).IsRequired();
		builder.Property(i => i.PhoneNumber).IsRequired();
		builder.Property(i => i.StreetAddress).IsRequired();
		builder.Property(i => i.City).IsRequired();
		builder.Property(i => i.ZipCode).IsRequired();
	}
}
