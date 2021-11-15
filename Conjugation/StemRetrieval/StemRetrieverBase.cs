using Core.VerbFormModifiers;

namespace Conjugation.StemRetrieval;

public abstract class StemRetrieverBase : ConjugatorBase, IStemRetriever
{
	public override bool Conjugates(VerbForm verbForm)
	{
		return verbForm.RootForm == VerbForm.RootForm;
	}
}
