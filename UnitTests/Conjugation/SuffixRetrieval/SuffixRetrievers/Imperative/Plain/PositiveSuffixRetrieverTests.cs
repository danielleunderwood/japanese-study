using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Imperative.Plain;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ろ")]
	[DataRow("歌う", "歌え")]
	[DataRow("立つ", "立て")]
	[DataRow("怒る", "怒れ")]
	[DataRow("読む", "読め")]
	[DataRow("死ぬ", "死ね")]
	[DataRow("遊ぶ", "遊べ")]
	[DataRow("続く", "続け")]
	[DataRow("泳ぐ", "泳げ")]
	[DataRow("直す", "直せ")]
	[DataRow("行く", "行け")]
	[DataRow("する", "しろ")]
	[DataRow("来る", "来い")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Imperative,
			PolitenessLevel = PolitenessLevel.Plain
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
