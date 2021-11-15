using Core;
using Core.VerbFormModifiers;

namespace Conjugation;

public abstract class ConjugatorBase : IConjugator
{
	public abstract VerbForm VerbForm { get; }

	public abstract bool Conjugates(VerbForm verbForm);

	public string GetConjugation(Verb verb)
	{
		return verb.IrregularConjugations != null && verb.IrregularConjugations.TryGetValue(VerbForm, out var irregularConjugation)
			? irregularConjugation
			: Conjugate(verb);
	}

	public abstract string Conjugate(Verb verb);
}
