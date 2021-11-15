using Conjugation.SuffixRetrieval.Indicative.NonPast.Polite;
using Core;
using Core.VerbFormModifiers;
using System.Linq;

namespace Conjugation.SuffixRetrieval;

public class ConjunctiveSuffixRetriever : SuffixRetrieverBase
{
	private readonly PositiveSuffixRetriever _stemRetriever;

	public ConjunctiveSuffixRetriever(PositiveSuffixRetriever stemRetriever)
	{
		_stemRetriever = stemRetriever;
	}

	public override VerbForm VerbForm => new() { RootForm = RootForm.Conjunctive };

	public override string Conjugate(Verb verb)
	{
		var stem = verb.PlainForm[..^1];
		var suffix = verb.Type == VerbType.Ichidan
			? "て"
			: verb.PlainForm.Last() switch
			{
				'う' or 'つ' or 'る' => "って",
				'む' or 'ぬ' or 'ぶ' => "んで",
				'く' => "いて",
				'ぐ' => "いで",
				'す' => "して",
				_ => throw new System.NotImplementedException()
			};
		return $"{stem}{suffix}";
	}
}
