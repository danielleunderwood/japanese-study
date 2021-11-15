using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.Past.Plain;

[TestClass]
public class NegativeSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見なかった")]
	[DataRow("歌う", "歌わなかった")]
	[DataRow("立つ", "立たなかった")]
	[DataRow("怒る", "怒らなかった")]
	[DataRow("読む", "読まなかった")]
	[DataRow("死ぬ", "死ななかった")]
	[DataRow("遊ぶ", "遊ばなかった")]
	[DataRow("続く", "続かなかった")]
	[DataRow("泳ぐ", "泳がなかった")]
	[DataRow("直す", "直さなかった")]
	[DataRow("行く", "行かなかった")]
	[DataRow("する", "しなかった")]
	[DataRow("来る", "来なかった")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.Past,
			PolitenessLevel = PolitenessLevel.Plain,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
