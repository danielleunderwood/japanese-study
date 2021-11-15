using Core.VerbFormModifiers;
using System.Collections.Generic;
using System.Linq;

namespace Conjugation.SuffixRetrieval;

public class SuffixRetrieverFactory
{
	private readonly IEnumerable<ISuffixRetriever> _suffixRetrievers;

	public SuffixRetrieverFactory(IEnumerable<ISuffixRetriever> suffixRetrievers)
	{
		_suffixRetrievers = suffixRetrievers;
	}

	public ISuffixRetriever GetSuffixRetriever(VerbForm verbForm)
	{
		return _suffixRetrievers.SingleOrDefault(suffixRetriever => suffixRetriever.Conjugates(verbForm));
	}
}
