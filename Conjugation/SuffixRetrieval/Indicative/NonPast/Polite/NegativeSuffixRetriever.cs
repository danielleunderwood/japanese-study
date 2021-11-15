using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Indicative.NonPast.Polite;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	private readonly PositiveSuffixRetriever _positiveSuffixRetriever;

	public NegativeSuffixRetriever(PositiveSuffixRetriever positiveSuffixRetriever)
	{
		_positiveSuffixRetriever = positiveSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.NonPast,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		return $"{_positiveSuffixRetriever.GetConjugation(verb)[..^1]}せん";
	}
}
