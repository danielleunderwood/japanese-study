using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Potential;

[TestClass]
public class PotentialConjugationTests
{
	private readonly RootForm _rootForm = RootForm.Potential;
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見られませんでした")]
	[DataRow("歌う", "歌えませんでした")]
	[DataRow("立つ", "立てませんでした")]
	[DataRow("怒る", "怒れませんでした")]
	[DataRow("読む", "読めませんでした")]
	[DataRow("死ぬ", "死ねませんでした")]
	[DataRow("遊ぶ", "遊べませんでした")]
	[DataRow("続く", "続けませんでした")]
	[DataRow("泳ぐ", "泳げませんでした")]
	[DataRow("直す", "直せませんでした")]
	[DataRow("行く", "行けませんでした")]
	[DataRow("する", "できませんでした")]
	[DataRow("来る", "来られませんでした")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), new VerbForm
		{
			RootForm = _rootForm,
			Tense = Tense.Past,
			PolitenessLevel = PolitenessLevel.Polite,
			Polarity = Polarity.Negative
		}));
	}
}
