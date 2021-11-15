using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.NonPast.Plain;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ない")]
	[DataRow("歌う", "歌わない")]
	[DataRow("立つ", "立たない")]
	[DataRow("怒る", "怒らない")]
	[DataRow("読む", "読まない")]
	[DataRow("死ぬ", "死なない")]
	[DataRow("遊ぶ", "遊ばない")]
	[DataRow("続く", "続かない")]
	[DataRow("泳ぐ", "泳がない")]
	[DataRow("直す", "直さない")]
	[DataRow("行く", "行かない")]
	[DataRow("する", "しない")]
	[DataRow("来る", "来ない")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.NonPast,
			PolitenessLevel = PolitenessLevel.Plain,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
