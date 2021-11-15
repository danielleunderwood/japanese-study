using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.SuffixRetrieval.Indicative.NonPast.Plain;

public class NegativeSuffixRetriever : SuffixRetrieverBase
{
	private readonly Polite.PositiveSuffixRetriever _stemRetriever;

	public NegativeSuffixRetriever(Polite.PositiveSuffixRetriever stemRetriever)
	{
		_stemRetriever = stemRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.NonPast,
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Negative
	};

	public override string Conjugate(Verb verb)
	{
		var stem = _stemRetriever.GetConjugation(verb)[..^2];
		var suffix = "ない";

		if (verb.Type == VerbType.Godan)
		{
			suffix = $"{Gojuuon.GetEquivalent(stem.Last(), 'あ')}{suffix}";
			stem = stem[..^1];
		}

		return $"{stem}{suffix}";
	}
}
