using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Imperative.Polite;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見てください")]
	[DataRow("歌う", "歌ってください")]
	[DataRow("立つ", "立ってください")]
	[DataRow("怒る", "怒ってください")]
	[DataRow("読む", "読んでください")]
	[DataRow("死ぬ", "死んでください")]
	[DataRow("遊ぶ", "遊んでください")]
	[DataRow("続く", "続いてください")]
	[DataRow("泳ぐ", "泳いでください")]
	[DataRow("直す", "直してください")]
	[DataRow("行く", "行ってください")]
	[DataRow("する", "してください")]
	[DataRow("来る", "来てください")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Imperative,
			PolitenessLevel = PolitenessLevel.Polite
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
