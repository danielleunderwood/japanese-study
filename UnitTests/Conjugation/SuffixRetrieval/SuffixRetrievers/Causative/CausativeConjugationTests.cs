using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Causative;

[TestClass]
public class CausativeConjugationTests
{
	private readonly RootForm _rootForm = RootForm.Causative;
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見させませんでした")]
	[DataRow("歌う", "歌わせませんでした")]
	[DataRow("立つ", "立たせませんでした")]
	[DataRow("怒る", "怒らせませんでした")]
	[DataRow("読む", "読ませませんでした")]
	[DataRow("死ぬ", "死なせませんでした")]
	[DataRow("遊ぶ", "遊ばせませんでした")]
	[DataRow("続く", "続かせませんでした")]
	[DataRow("泳ぐ", "泳がせませんでした")]
	[DataRow("直す", "直させませんでした")]
	[DataRow("行く", "行かせませんでした")]
	[DataRow("する", "させませんでした")]
	[DataRow("来る", "来させませんでした")]
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
