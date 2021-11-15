using Conjugation.StemRetrieval;
using Conjugation.SuffixRetrieval;
using Core;
using Core.VerbFormModifiers;

namespace Conjugation;

public class Conjugator
{
	private readonly StemRetriever _stemRetriever;
	private readonly SuffixRetriever _suffixRetriever;

	public Conjugator(StemRetriever stemRetriever, SuffixRetriever suffixRetriever)
	{
		_stemRetriever = stemRetriever;
		_suffixRetriever = suffixRetriever;
	}

	public string Conjugate(Verb verb, VerbForm verbForm)
	{
		var stem = _stemRetriever.RetrieveStem(verb, verbForm);
		return $"{_suffixRetriever.RetrieveSuffix(stem, verbForm)}";
	}
}
