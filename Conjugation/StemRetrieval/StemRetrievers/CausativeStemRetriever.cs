using Core;
using Core.VerbFormModifiers;

namespace Conjugation.StemRetrieval.StemRetrievers;

public class CausativeStemRetriever : StemRetrieverBase
{
	private readonly PassiveStemRetriever _passiveStemRetriever;

	public CausativeStemRetriever(PassiveStemRetriever stemRetriever)
	{
		_passiveStemRetriever = stemRetriever;
	}

	public override VerbForm VerbForm => new() { RootForm = RootForm.Causative };

	public override string Conjugate(Verb verb)
	{
		if (verb.Type == VerbType.Ichidan)
		{
			verb = new() { Type = VerbType.Godan, PlainForm = $"{verb.PlainForm[..^1]}す" };
		}

		var stem = _passiveStemRetriever.GetConjugation(verb).ToCharArray();
		stem[^2] = 'せ';
		return new string(stem);
	}
}
