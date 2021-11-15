using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.SuffixRetrieval.Indicative.Past.Plain;

public class PositiveSuffixRetriever : SuffixRetrieverBase
{
	private readonly ConjunctiveSuffixRetriever _conjunctiveSuffixRetriever;

	public PositiveSuffixRetriever(ConjunctiveSuffixRetriever conjunctiveSuffixRetriever)
	{
		_conjunctiveSuffixRetriever = conjunctiveSuffixRetriever;
	}

	public override VerbForm VerbForm => new()
	{
		RootForm = RootForm.Indicative,
		Tense = Tense.Past,
		PolitenessLevel = PolitenessLevel.Plain,
		Polarity = Polarity.Positive
	};

	public override string Conjugate(Verb verb)
	{
		var suffix = _conjunctiveSuffixRetriever.GetConjugation(verb);
		var finalKana = suffix.Last();
		return $"{suffix[..^1]}{Gojuuon.GetEquivalent(finalKana, 'あ')}";
	}
}
