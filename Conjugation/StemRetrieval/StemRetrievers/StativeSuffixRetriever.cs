using Conjugation.SuffixRetrieval;
using Core;
using Core.VerbFormModifiers;

namespace Conjugation.StemRetrieval.StemRetrievers;

public class StativeSuffixRetriever : StemRetrieverBase
{
	private readonly ConjunctiveSuffixRetriever _conjunctiveSuffixRetriever;

	public StativeSuffixRetriever(ConjunctiveSuffixRetriever conjunctiveSuffixRetriever)
	{
		_conjunctiveSuffixRetriever = conjunctiveSuffixRetriever;
	}

	public override VerbForm VerbForm => new() { RootForm = RootForm.Stative };

	public override string Conjugate(Verb verb)
	{
		return $"{_conjunctiveSuffixRetriever.GetConjugation(verb)}いる";
	}
}
