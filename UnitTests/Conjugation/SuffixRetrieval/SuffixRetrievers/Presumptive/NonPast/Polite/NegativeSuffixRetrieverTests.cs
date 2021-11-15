using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Presumptive.NonPast.Polite;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ないでしょう")]
	[DataRow("歌う", "歌わないでしょう")]
	[DataRow("立つ", "立たないでしょう")]
	[DataRow("怒る", "怒らないでしょう")]
	[DataRow("読む", "読まないでしょう")]
	[DataRow("死ぬ", "死なないでしょう")]
	[DataRow("遊ぶ", "遊ばないでしょう")]
	[DataRow("続く", "続かないでしょう")]
	[DataRow("泳ぐ", "泳がないでしょう")]
	[DataRow("直す", "直さないでしょう")]
	[DataRow("行く", "行かないでしょう")]
	[DataRow("する", "しないでしょう")]
	[DataRow("来る", "来ないでしょう")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Presumptive,
			PolitenessLevel = PolitenessLevel.Polite,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
