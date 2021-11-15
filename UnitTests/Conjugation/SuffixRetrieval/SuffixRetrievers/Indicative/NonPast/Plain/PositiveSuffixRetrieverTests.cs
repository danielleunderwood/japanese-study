using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.NonPast.Plain;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見る")]
	[DataRow("歌う", "歌う")]
	[DataRow("立つ", "立つ")]
	[DataRow("怒る", "怒る")]
	[DataRow("読む", "読む")]
	[DataRow("死ぬ", "死ぬ")]
	[DataRow("遊ぶ", "遊ぶ")]
	[DataRow("続く", "続く")]
	[DataRow("泳ぐ", "泳ぐ")]
	[DataRow("直す", "直す")]
	[DataRow("行く", "行く")]
	[DataRow("する", "する")]
	[DataRow("来る", "来る")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.NonPast,
			PolitenessLevel = PolitenessLevel.Plain
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
