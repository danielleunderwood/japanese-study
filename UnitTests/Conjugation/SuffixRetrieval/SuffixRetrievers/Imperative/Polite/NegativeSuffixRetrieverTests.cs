using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Imperative.Polite;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ないでください")]
	[DataRow("歌う", "歌わないでください")]
	[DataRow("立つ", "立たないでください")]
	[DataRow("怒る", "怒らないでください")]
	[DataRow("読む", "読まないでください")]
	[DataRow("死ぬ", "死なないでください")]
	[DataRow("遊ぶ", "遊ばないでください")]
	[DataRow("続く", "続かないでください")]
	[DataRow("泳ぐ", "泳がないでください")]
	[DataRow("直す", "直さないでください")]
	[DataRow("行く", "行かないでください")]
	[DataRow("する", "しないでください")]
	[DataRow("来る", "来ないでください")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Imperative,
			PolitenessLevel = PolitenessLevel.Polite,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
