using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PhonebookService.Domain.Repositories;
using PhonebookService.Infrastructure.Repositories;

namespace PhonebookService.Infrastructure;

/// <summary>
/// Extension class that helps to setup infrastructure layer
/// </summary>
public static class PhonebookInfrastructureExtensions
{
	/// <summary>
	/// Configure infrastructure layer
	/// </summary>
	/// <param name="services">Collection of webapp services</param>
	/// <param name="configuration">Webapp configuration entity</param>
	/// <param name="enableSensitiveDataLogging">If set true, EF will not hide personal data (e.g. passwords) when logging. Use only on debug!</param>
	public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration, bool enableSensitiveDataLogging = false)
	{
		services.AddDbContext<PhonebookContext>(options =>
		{
			options.UseInMemoryDatabase("PhonebookDatabase");
			// options.UseSqlServer(configuration.GetConnectionString("PhonebookDatabase"));

			if (enableSensitiveDataLogging)
				options.EnableSensitiveDataLogging();
		});

		services.AddScoped<IPhonebookRepository, PhonebookRepository>();

		return services;
	}
}
