using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Imperative.Polite;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	private readonly Indicative.NonPast.Plain.NegativeSuffixRetriever _indicativeSuffixRetriever;

	public NegativeSuffixRetriever(Indicative.NonPast.Plain.NegativeSuffixRetriever indicativeSuffixRetriever)
	{
		_indicativeSuffixRetriever = indicativeSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Imperative,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		return $"{_indicativeSuffixRetriever.GetConjugation(verb)}でください";
	}
}
