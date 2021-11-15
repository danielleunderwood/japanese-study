using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.SuffixRetrieval.Presumptive.NonPast.Plain;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Presumptive,
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		var stem = verb.PlainForm[..^1];
		if (verb.Type == VerbType.Ichidan)
		{
			var newVerb = new Verb { PlainForm = $"{stem}ゆ", Type = VerbType.Godan };
			return GetConjugation(newVerb);
		}
		return $"{stem}{Gojuuon.GetEquivalent(verb.PlainForm.Last(), 'お')}う";
	}
}
