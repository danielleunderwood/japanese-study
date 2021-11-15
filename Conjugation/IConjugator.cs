using Core;
using Core.VerbFormModifiers;

namespace Conjugation;

public interface IConjugator
{
	VerbForm VerbForm { get; }

	bool Conjugates(VerbForm verbForm);

	string GetConjugation(Verb verb);

	string Conjugate(Verb verb);
}

