using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Imperative.Polite;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	private readonly ConjunctiveSuffixRetriever _conjunctiveSuffixRetriever;

	public PositiveSuffixRetriever(ConjunctiveSuffixRetriever conjunctiveSuffixRetriever)
	{
		_conjunctiveSuffixRetriever = conjunctiveSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Imperative,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		return $"{_conjunctiveSuffixRetriever.GetConjugation(verb)}ください";
	}
}
