using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.NonPast.Polite;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ません")]
	[DataRow("歌う", "歌いません")]
	[DataRow("立つ", "立ちません")]
	[DataRow("怒る", "怒りません")]
	[DataRow("読む", "読みません")]
	[DataRow("死ぬ", "死にません")]
	[DataRow("遊ぶ", "遊びません")]
	[DataRow("続く", "続きません")]
	[DataRow("泳ぐ", "泳ぎません")]
	[DataRow("直す", "直しません")]
	[DataRow("行く", "行きません")]
	[DataRow("する", "しません")]
	[DataRow("来る", "来ません")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.NonPast,
			PolitenessLevel = PolitenessLevel.Polite,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
