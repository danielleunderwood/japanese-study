using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Imperative.Plain;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見るな")]
	[DataRow("歌う", "歌うな")]
	[DataRow("立つ", "立つな")]
	[DataRow("怒る", "怒るな")]
	[DataRow("読む", "読むな")]
	[DataRow("死ぬ", "死ぬな")]
	[DataRow("遊ぶ", "遊ぶな")]
	[DataRow("続く", "続くな")]
	[DataRow("泳ぐ", "泳ぐな")]
	[DataRow("直す", "直すな")]
	[DataRow("行く", "行くな")]
	[DataRow("する", "するな")]
	[DataRow("来る", "来るな")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Imperative,
			PolitenessLevel = PolitenessLevel.Plain,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
