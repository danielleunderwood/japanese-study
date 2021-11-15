using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Presumptive.NonPast.Plain;

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
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		var stem = _stemRetriever.GetConjugation(verb);
		return $"{stem}だろう";
	}
}
