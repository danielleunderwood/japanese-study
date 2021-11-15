using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers.Presumptive.NonPast.Plain;

[TestClass]
public class PositiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見よう")]
	[DataRow("歌う", "歌おう")]
	[DataRow("立つ", "立とう")]
	[DataRow("怒る", "怒ろう")]
	[DataRow("読む", "読もう")]
	[DataRow("死ぬ", "死のう")]
	[DataRow("遊ぶ", "遊ぼう")]
	[DataRow("続く", "続こう")]
	[DataRow("泳ぐ", "泳ごう")]
	[DataRow("直す", "直そう")]
	[DataRow("行く", "行こう")]
	[DataRow("する", "しよう")]
	[DataRow("来る", "来よう")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm
		{
			RootForm = RootForm.Presumptive,
			PolitenessLevel = PolitenessLevel.Plain
		};
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
