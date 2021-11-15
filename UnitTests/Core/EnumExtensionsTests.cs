using Core.Extensions;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core;

[TestClass]
public class EnumExtensionsTests
{
	[TestMethod]
	public void GetDescriptionTest()
	{
		Assert.AreEqual("non past", Tense.NonPast.GetDescription());
		Assert.AreEqual(string.Empty, Tense.Default.GetDescription());
	}
}
