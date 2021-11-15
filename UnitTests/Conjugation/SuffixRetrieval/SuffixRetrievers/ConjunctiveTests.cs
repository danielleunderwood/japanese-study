using Conjugation;
using Core.VerbFormModifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Conjugation.SuffixRetrieval.SuffixRetrievers;

[TestClass]
public class ConjunctiveSuffixRetrieverTests
{
	private readonly Conjugator _conjugator = ServiceLocator.GetService<Conjugator>();

	[DataTestMethod]
	[DataRow("見る", "見て")]
	[DataRow("歌う", "歌って")]
	[DataRow("立つ", "立って")]
	[DataRow("怒る", "怒って")]
	[DataRow("読む", "読んで")]
	[DataRow("死ぬ", "死んで")]
	[DataRow("遊ぶ", "遊んで")]
	[DataRow("続く", "続いて")]
	[DataRow("泳ぐ", "泳いで")]
	[DataRow("直す", "直して")]
	[DataRow("行く", "行って")]
	[DataRow("する", "して")]
	[DataRow("来る", "来て")]
	public void ConjugatesCorrectly(string plainForm, string expected)
	{
		var verbForm = new VerbForm { RootForm = RootForm.Conjunctive };
		Assert.AreEqual(expected, _conjugator.Conjugate(VerbLocator.GetVerb(plainForm), verbForm));
	}
}
