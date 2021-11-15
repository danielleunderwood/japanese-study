using Core;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval.Indicative.Past.Polite;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	private readonly NonPast.Polite.PositiveSuffixRetriever _politeSuffixRetriever;
	private readonly Plain.PositiveSuffixRetriever _pastSuffixRetriever;

	public PositiveSuffixRetriever(NonPast.Polite.PositiveSuffixRetriever politeSuffixRetriever,
		Plain.PositiveSuffixRetriever pastSuffixRetriever)
	{
		_politeSuffixRetriever = politeSuffixRetriever;
		_pastSuffixRetriever = pastSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.Past,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		var politeForm = _politeSuffixRetriever.GetConjugation(verb);
		var politeVerb = new Verb { PlainForm = politeForm, Type = VerbType.Godan };
		return _pastSuffixRetriever.GetConjugation(politeVerb);
	}
}
