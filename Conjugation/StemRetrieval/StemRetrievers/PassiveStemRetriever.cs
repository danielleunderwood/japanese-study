using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.StemRetrieval.StemRetrievers;

public class PassiveStemRetriever : StemRetrieverBase
{
	public override VerbForm VerbForm => new() { RootForm = RootForm.Passive };

	public override string Conjugate(Verb verb)
	{
		var suffix = Gojuuon.GetEquivalent(verb.PlainForm.Last(), 'あ');
		return $"{verb.PlainForm[..^1]}{suffix}れる";
	}
}
