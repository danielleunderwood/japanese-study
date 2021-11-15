using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Presumptive.NonPast.Polite;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	private readonly Indicative.NonPast.Polite.PositiveSuffixRetriever _stemRetriever;
	private readonly Plain.PositiveSuffixRetriever _suffixRetriever;

	public PositiveSuffixRetriever(Indicative.NonPast.Polite.PositiveSuffixRetriever stemRetriever,
		Plain.PositiveSuffixRetriever suffixRetriever)
	{
		_stemRetriever = stemRetriever;
		_suffixRetriever = suffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Presumptive,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		var stem = _stemRetriever.GetConjugation(verb);
		stem = $"{stem[..^1]}しゅ";
		var newVerb = new Verb { PlainForm = stem, Type = VerbType.Godan };
		return _suffixRetriever.GetConjugation(newVerb);
	}
}
