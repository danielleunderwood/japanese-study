using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Passive;

[TestClass]
public class PassiveConjugationTests
{
	private readonly RootForm _rootForm = RootForm.Passive;
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見られませんでした")]
	[DataRow("歌う", "歌われませんでした")]
	[DataRow("立つ", "立たれませんでした")]
	[DataRow("怒る", "怒られませんでした")]
	[DataRow("読む", "読まれませんでした")]
	[DataRow("死ぬ", "死なれませんでした")]
	[DataRow("遊ぶ", "遊ばれませんでした")]
	[DataRow("続く", "続かれませんでした")]
	[DataRow("泳ぐ", "泳がれませんでした")]
	[DataRow("直す", "直されませんでした")]
	[DataRow("行く", "行かれませんでした")]
	[DataRow("する", "されませんでした")]
	[DataRow("来る", "来られませんでした")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = _rootForm,
			Tense = Tense.Past,
			PolitenessLevel = PolitenessLevel.Polite,
			Polarity = Polarity.Negative
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
