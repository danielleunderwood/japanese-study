using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.Past.Polite;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ませんでした")]
	[DataRow("歌う", "歌いませんでした")]
	[DataRow("立つ", "立ちませんでした")]
	[DataRow("怒る", "怒りませんでした")]
	[DataRow("読む", "読みませんでした")]
	[DataRow("死ぬ", "死にませんでした")]
	[DataRow("遊ぶ", "遊びませんでした")]
	[DataRow("続く", "続きませんでした")]
	[DataRow("泳ぐ", "泳ぎませんでした")]
	[DataRow("直す", "直しませんでした")]
	[DataRow("行く", "行きませんでした")]
	[DataRow("する", "しませんでした")]
	[DataRow("来る", "来ませんでした")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.Past,
			PolitenessLevel = PolitenessLevel.Polite,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
