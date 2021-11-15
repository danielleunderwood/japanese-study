using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Stative;

[TestClass]
public class StativeConjugationTests
{
	private readonly RootForm _rootForm = RootForm.Stative;
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見ていませんでした")]
	[DataRow("歌う", "歌っていませんでした")]
	[DataRow("立つ", "立っていませんでした")]
	[DataRow("怒る", "怒っていませんでした")]
	[DataRow("読む", "読んでいませんでした")]
	[DataRow("死ぬ", "死んでいませんでした")]
	[DataRow("遊ぶ", "遊んでいませんでした")]
	[DataRow("続く", "続いていませんでした")]
	[DataRow("泳ぐ", "泳いでいませんでした")]
	[DataRow("直す", "直していませんでした")]
	[DataRow("行く", "行っていませんでした")]
	[DataRow("する", "していませんでした")]
	[DataRow("来る", "来ていませんでした")]
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
