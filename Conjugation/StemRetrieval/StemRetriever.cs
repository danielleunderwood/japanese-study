using Core;
using Core.Extensions;
using Core.VerbFormModifiers;

namespace Conjugation.StemRetrieval;

public class StemRetriever
{
	private readonly StemRetrieverFactory _stemRetrieverFactory;

	public StemRetriever(StemRetrieverFactory stemRetrieverFactory)
	{
		_stemRetrieverFactory = stemRetrieverFactory;
	}

	public Verb RetrieveStem(Verb verb, VerbForm verbForm)
	{
		var requiresStemChange = verbForm.RootForm.IsTensed() &&
			verbForm.RootForm != RootForm.Indicative;
		if (requiresStemChange)
		{
			var result = _stemRetrieverFactory.GetStemRetriever(verbForm).GetConjugation(verb);
			verb = new Verb { PlainForm = result, Type = VerbType.Ichidan };
		}

		return verb;
	}
}
