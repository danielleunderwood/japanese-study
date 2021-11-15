using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.SuffixRetrieval.Indicative.NonPast.Polite;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.NonPast,
		PolitenessLevel = PolitenessLevel.Polite,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		var suffix = "ます";

		if (verb.Type == VerbType.Godan)
		{
			suffix = $"{Gojuuon.GetEquivalent(verb.PlainForm.Last(), 'い')}{suffix}";
		}

		return $"{verb.PlainForm[..^1]}{suffix}";
	}
}
