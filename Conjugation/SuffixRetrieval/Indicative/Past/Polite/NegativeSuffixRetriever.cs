using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Indicative.Past.Polite;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	private readonly NonPast.Polite.NegativeSuffixRetriever _nonPastSuffixRetriever;

	public NegativeSuffixRetriever(NonPast.Polite.NegativeSuffixRetriever nonPastSuffixRetriever)
	{
		_nonPastSuffixRetriever = nonPastSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.Past,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		return $"{_nonPastSuffixRetriever.GetConjugation(verb)}でした";
	}
}
