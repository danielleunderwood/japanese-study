using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Presumptive.NonPast.Polite;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	private readonly Indicative.NonPast.Plain.NegativeSuffixRetriever _stemRetriever;

	public NegativeSuffixRetriever(Indicative.NonPast.Plain.NegativeSuffixRetriever stemRetriever)
	{
		_stemRetriever = stemRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Presumptive,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		var stem = _stemRetriever.GetConjugation(verb);
		return $"{stem}でしょう";
	}
}