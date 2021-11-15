using Core.Extensions;
using System;
using System.Linq;

namespace Core.VerbFormModifiers;

public class VerbForm
{
	public RootForm RootForm { get; set; }
	public Tense Tense { get; set; }
	public PolitenessLevel PolitenessLevel { get; set; }
	public Polarity Polarity { get; set; }

	public override string ToString()
	{
		return string.Join(" ",
			new[] {
				Polarity.GetDescription(),
				PolitenessLevel.GetDescription(),
				Tense.GetDescription(),
				RootForm.ToString()
			}.Where(element => !string.IsNullOrEmpty(element)))
			.ToLower();
	}

	public static bool operator ==(VerbForm lhs, VerbForm rhs)
	{
		return lhs is null && rhs is null ||
			   lhs is not null && rhs is not null &&
			   lhs.RootForm == rhs.RootForm &&
			   lhs.PolitenessLevel == rhs.PolitenessLevel &&
			   lhs.Polarity == rhs.Polarity &&
			   lhs.Tense == rhs.Tense;
	}

	public static bool operator !=(VerbForm lhs, VerbForm rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object obj)
	{
		return this == (VerbForm)obj;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(
				RootForm.GetHashCode(),
				Tense.GetHashCode(),
				PolitenessLevel.GetHashCode(),
				Polarity.GetHashCode()
			);
	}
}
