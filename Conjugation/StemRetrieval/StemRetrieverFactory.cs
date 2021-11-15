using Core.VerbFormModifiers;
using System.Collections.Generic;
using System.Linq;

namespace Conjugation.StemRetrieval;

public class StemRetrieverFactory
{
	private readonly IEnumerable<IStemRetriever> _stemRetrievers;

	public StemRetrieverFactory(IEnumerable<IStemRetriever> stemRetrievers)
	{
		_stemRetrievers = stemRetrievers;
	}

	public IStemRetriever GetStemRetriever(VerbForm verbForm)
	{
		return _stemRetrievers.SingleOrDefault(stemRetriever => stemRetriever.Conjugates(verbForm));
	}
}
