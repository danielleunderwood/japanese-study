using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Indicative.NonPast.Polite;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ます")]
	[DataRow("歌う", "歌います")]
	[DataRow("立つ", "立ちます")]
	[DataRow("怒る", "怒ります")]
	[DataRow("読む", "読みます")]
	[DataRow("死ぬ", "死にます")]
	[DataRow("遊ぶ", "遊びます")]
	[DataRow("続く", "続きます")]
	[DataRow("泳ぐ", "泳ぎます")]
	[DataRow("直す", "直します")]
	[DataRow("行く", "行きます")]
	[DataRow("する", "します")]
	[DataRow("来る", "来ます")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Indicative,
			Tense = Tense.NonPast,
			PolitenessLevel = PolitenessLevel.Polite
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
