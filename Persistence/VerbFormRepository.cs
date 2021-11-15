using Blazored.LocalStorage;
using Core.Extensions;
using Core.VerbFormModifiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence;

public class VerbFormRepository : ActivatableItemRepository<VerbForm>
{
	public VerbFormRepository(ILocalStorageService localStorage) : base(localStorage)
	{
	}

	public override VerbForm[] GetAll()
	{
		var verbForms = new List<VerbForm>
			{
				new VerbForm { RootForm = RootForm.Conjunctive }
			};

		foreach (var politenessLevel in Enum.GetValues<PolitenessLevel>().Where(politenessLevel => politenessLevel != PolitenessLevel.Default))
		{
			foreach (var polarity in Enum.GetValues<Polarity>())
			{
				foreach (var rootForm in Enum.GetValues<RootForm>())
				{
					if (rootForm.IsTensed())
					{
						foreach (var tense in Enum.GetValues<Tense>().Where(tense => tense != Tense.Default))
						{
							verbForms.Add(new VerbForm { Polarity = polarity, PolitenessLevel = politenessLevel, RootForm = rootForm, Tense = tense });
						}
					}
					else if (rootForm != RootForm.Conjunctive)
					{
						verbForms.Add(new VerbForm { Polarity = polarity, PolitenessLevel = politenessLevel, RootForm = rootForm });
					}
				}
			}
		}

		return verbForms.ToArray();
	}
}
