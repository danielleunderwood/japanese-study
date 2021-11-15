using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Presumptive.NonPast.Polite;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ましょう")]
	[DataRow("歌う", "歌いましょう")]
	[DataRow("立つ", "立ちましょう")]
	[DataRow("怒る", "怒りましょう")]
	[DataRow("読む", "読みましょう")]
	[DataRow("死ぬ", "死にましょう")]
	[DataRow("遊ぶ", "遊びましょう")]
	[DataRow("続く", "続きましょう")]
	[DataRow("泳ぐ", "泳ぎましょう")]
	[DataRow("直す", "直しましょう")]
	[DataRow("行く", "行きましょう")]
	[DataRow("する", "しましょう")]
	[DataRow("来る", "来ましょう")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Presumptive,
			PolitenessLevel = PolitenessLevel.Polite
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
