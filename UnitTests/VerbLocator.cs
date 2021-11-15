using Core;
using Persistence;
using System.Linq;

namespace Tests;

public static class VerbLocator
{
	public static Verb GetVerb(string plainForm)
	{
		var verbRepository = ServiceLocator.GetService<VerbRepository>();
		return verbRepository.GetAll().Single(verb => verb.PlainForm == plainForm);
	}
}
