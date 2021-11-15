using Core.VerbFormModifiers;
using System.Collections.Generic;

namespace Core;

public class IrregularConjugations :
	Dictionary<RootForm,
		Dictionary<Tense,
			Dictionary<PolitenessLevel,
				Dictionary<Polarity, string>>>>
{
	public bool TryGetValue(VerbForm verbForm, out string value)
	{
		value = null;
		return TryGetValue(verbForm.RootForm, out var tenseDictionary)
			&& tenseDictionary.TryGetValue(verbForm.Tense, out var politenessLevelDictionary)
			&& politenessLevelDictionary.TryGetValue(verbForm.PolitenessLevel, out var polarityDictionary)
			&& polarityDictionary.TryGetValue(verbForm.Polarity, out value);
	}
}
