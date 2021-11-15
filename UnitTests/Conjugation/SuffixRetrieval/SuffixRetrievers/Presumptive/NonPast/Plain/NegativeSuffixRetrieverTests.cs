using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Presumptive.NonPast.Plain;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ないだろう")]
	[DataRow("歌う", "歌わないだろう")]
	[DataRow("立つ", "立たないだろう")]
	[DataRow("怒る", "怒らないだろう")]
	[DataRow("読む", "読まないだろう")]
	[DataRow("死ぬ", "死なないだろう")]
	[DataRow("遊ぶ", "遊ばないだろう")]
	[DataRow("続く", "続かないだろう")]
	[DataRow("泳ぐ", "泳がないだろう")]
	[DataRow("直す", "直さないだろう")]
	[DataRow("行く", "行かないだろう")]
	[DataRow("する", "しないだろう")]
	[DataRow("来る", "来ないだろう")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Presumptive,
			PolitenessLevel = PolitenessLevel.Plain,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
