using Microsoft.EntityFrameworkCore;
using PhonebookService.Domain.Models;
using PhonebookService.Infrastructure.ModelConfigurations;

namespace PhonebookService.Infrastructure;

/// <summary>
/// Phonebook EF database context
/// </summary>
public class PhonebookContext : DbContext
{
	public DbSet<PhonebookRecord> Records { get; set; }

#pragma warning disable CS8618 // Non-nullable property must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

	public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options) {}

#pragma warning restore CS8618 // Non-nullable property must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfiguration(new PhonebookRecordEntityTypeConfiguration());
	}
}
