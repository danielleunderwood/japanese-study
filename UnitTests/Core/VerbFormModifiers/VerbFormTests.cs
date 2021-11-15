using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core.VerbFormModifiers;

[TestClass]
public class VerbFormTests
{
	[TestMethod]
	public void EqualsTest()
	{
		Assert.IsTrue(GetTestVerbForm().Equals(GetTestVerbForm()));
	}

	[TestMethod]
	public void OperatorEqualsTest()
	{
		Assert.IsTrue(GetTestVerbForm() == GetTestVerbForm());
	}

	private static VerbForm GetTestVerbForm()
	{
		return new VerbForm
		{
			Polarity = Polarity.Positive,
			PolitenessLevel = PolitenessLevel.Polite,
			RootForm = RootForm.Indicative,
			Tense = Tense.NonPast
		};
	}
}
