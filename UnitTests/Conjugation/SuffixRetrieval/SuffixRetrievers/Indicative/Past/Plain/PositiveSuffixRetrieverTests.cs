using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.Past.Plain;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見た")]
	[DataRow("歌う", "歌った")]
	[DataRow("立つ", "立った")]
	[DataRow("怒る", "怒った")]
	[DataRow("読む", "読んだ")]
	[DataRow("死ぬ", "死んだ")]
	[DataRow("遊ぶ", "遊んだ")]
	[DataRow("続く", "続いた")]
	[DataRow("泳ぐ", "泳いだ")]
	[DataRow("直す", "直した")]
	[DataRow("行く", "行った")]
	[DataRow("する", "した")]
	[DataRow("来る", "来た")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.Past,
			PolitenessLevel = PolitenessLevel.Plain
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
