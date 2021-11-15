using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class ServiceConfiguration
{
	public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection serviceCollection)
	{
		serviceCollection
			.AddBlazoredLocalStorage()
			.AddScoped<VerbFormRepository>()
			.AddScoped<VerbRepository>();

		return serviceCollection;
	}
}
