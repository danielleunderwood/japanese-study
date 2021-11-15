using Conjugation.StemRetrieval;
using Conjugation.SuffixRetrieval;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Conjugation;

public static class ServiceConfiguration
{
	public static IServiceCollection ConfigureConjugationServices(this IServiceCollection serviceCollection)
	{
		return serviceCollection
			.AddSingleton<StemRetriever>()
			.AddSingleton<SuffixRetriever>()
			.AddSingleton<StemRetrieverFactory>()
			.AddSingleton<SuffixRetrieverFactory>()
			.AddAllImplementations<ISuffixRetriever>()
			.AddAllImplementations<IStemRetriever>()
			.AddSingleton<Conjugator>();
	}

	private static IServiceCollection AddAllImplementations<T>(this IServiceCollection serviceCollection)
	{
		var serviceType = typeof(T);
		var implementations = Assembly.GetAssembly(serviceType)
			.GetTypes()
			.Where(type => type.IsAssignableTo(serviceType) && type != serviceType && !type.IsAbstract);

		foreach (var type in implementations)
		{
			serviceCollection.AddImplementation<T>(type);
		}

		return serviceCollection;
	}

	private static IServiceCollection AddImplementation<TService>(this IServiceCollection serviceCollection, Type implementation)
	{
		return serviceCollection
			.AddSingleton(implementation)
			.AddSingleton(typeof(TService), implementation);
	}
}
