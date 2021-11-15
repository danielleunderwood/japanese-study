using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.Past.Polite;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ました")]
	[DataRow("歌う", "歌いました")]
	[DataRow("立つ", "立ちました")]
	[DataRow("怒る", "怒りました")]
	[DataRow("読む", "読みました")]
	[DataRow("死ぬ", "死にました")]
	[DataRow("遊ぶ", "遊びました")]
	[DataRow("続く", "続きました")]
	[DataRow("泳ぐ", "泳ぎました")]
	[DataRow("直す", "直しました")]
	[DataRow("行く", "行きました")]
	[DataRow("する", "しました")]
	[DataRow("来る", "来ました")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.Past,
			PolitenessLevel = PolitenessLevel.Polite
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
