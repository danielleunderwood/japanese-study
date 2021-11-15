using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.StemRetrieval.StemRetrievers;

public class PotentialStemRetriever : StemRetrieverBase
{
	private readonly PassiveStemRetriever _passiveStemRetriever;

	public PotentialStemRetriever(PassiveStemRetriever stemRetriever)
	{
		_passiveStemRetriever = stemRetriever;
	}

	public override VerbForm VerbForm => new() { RootForm = RootForm.Potential };

	public override string Conjugate(Verb verb)
	{
		if (verb.Type == VerbType.Ichidan)
		{
			return _passiveStemRetriever.GetConjugation(verb);
		}

		var suffix = Gojuuon.GetEquivalent(verb.PlainForm.Last(), 'え');
		return $"{verb.PlainForm[..^1]}{suffix}る";
	}
}
