using Conjugation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Persistence;
using Tests.Mocks;

namespace Tests;

public static class ServiceLocator
{
	private static ServiceProvider _serviceProvider;

	public static T GetService<T>()
	{
		return GetServiceProvider().GetService<T>();
	}

	private static ServiceProvider GetServiceProvider()
	{
		if (_serviceProvider is null)
		{
			_serviceProvider = new ServiceCollection()
			.AddScoped<IJSRuntime, JSRuntimeMock>()
			.ConfigureConjugationServices()
			.ConfigurePersistenceServices().BuildServiceProvider();
		}

		return _serviceProvider;
	}
}
