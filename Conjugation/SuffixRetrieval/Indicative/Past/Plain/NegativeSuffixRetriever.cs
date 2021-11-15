using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Indicative.Past.Plain;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	private readonly NonPast.Plain.NegativeSuffixRetriever _nonPastSuffixRetriever;

	public NegativeSuffixRetriever(NonPast.Plain.NegativeSuffixRetriever nonPastSuffixRetriever)
	{
		_nonPastSuffixRetriever = nonPastSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.Past,
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		return $"{_nonPastSuffixRetriever.GetConjugation(verb)[..^1]}かった";
	}
}
