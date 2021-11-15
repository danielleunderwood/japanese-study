using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval;

public class SuffixRetriever
{
	private readonly SuffixRetrieverFactory _suffixRetrieverFactory;

	public SuffixRetriever(SuffixRetrieverFactory suffixRetrieverFactory)
	{
		_suffixRetrieverFactory = suffixRetrieverFactory;
	}

	public string RetrieveSuffix(Verb verb, VerbForm verbForm)
	{
		return _suffixRetrieverFactory.GetSuffixRetriever(verbForm) is { } suffixRetriever
			? suffixRetriever.GetConjugation(verb)
			: verb.PlainForm;
	}
}
