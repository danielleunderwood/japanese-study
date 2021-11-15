using Core.VerbFormModifiers;
using System;
using System.Linq;

namespace Core.Extensions;

public static class RootFormExtensions
{
	private static readonly RootForm[] _untensedRootForms = new[] {
		RootForm.Imperative,
		RootForm.Presumptive,
		RootForm.Conjunctive
	};

	public static bool IsTensed(this RootForm value)
	{
		return !_untensedRootForms.Contains(value);
	}
}
