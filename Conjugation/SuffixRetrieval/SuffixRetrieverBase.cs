using Core.Extensions;
using Core.VerbFormModifiers;

namespace Conjugation.SuffixRetrieval;

public abstract class SuffixRetrieverBase : ConjugatorBase, ISuffixRetriever
{
	public override bool Conjugates(VerbForm verbForm)
	{
		return verbForm == VerbForm ||
			verbForm.RootForm.IsTensed() &&
			VerbForm.RootForm == RootForm.Indicative &&
			verbForm.Tense == VerbForm.Tense &&
			verbForm.PolitenessLevel == VerbForm.PolitenessLevel &&
			verbForm.Polarity == VerbForm.Polarity;
	}
}
