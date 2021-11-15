using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.SuffixRetrieval.Imperative.Plain;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	private readonly Indicative.NonPast.Polite.PositiveSuffixRetriever _stemRetriever;

	public PositiveSuffixRetriever(Indicative.NonPast.Polite.PositiveSuffixRetriever stemRetriever)
	{
		_stemRetriever = stemRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Imperative,
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		var initial = _stemRetriever.GetConjugation(verb)[..^2];
		var result = initial;
		if (verb.Type == VerbType.Ichidan)
		{
			result = $"{initial}ろ";
		}
		else
		{
			var suffix = Gojuuon.GetEquivalent(initial.Last(), 'え');
			result = $"{initial[..^1]}{suffix}";
		}
		return result;
	}
}
