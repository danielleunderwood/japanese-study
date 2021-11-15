using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Imperative.Plain;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Imperative,
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		return $"{verb.PlainForm}な";
	}
}
