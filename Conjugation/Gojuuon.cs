using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conjugation;

public static class Gojuuon
{
	private static readonly Dictionary<char, Dictionary<char, char>> _modifiedGojuuonMap = new()
	{
		['う'] = new Dictionary<char, char> { ['あ'] = 'わ', ['い'] = 'い', ['え'] = 'え', ['お'] = 'お' },
		['く'] = new Dictionary<char, char> { ['あ'] = 'か', ['い'] = 'き', ['え'] = 'け', ['お'] = 'こ' },
		['ぐ'] = new Dictionary<char, char> { ['あ'] = 'が', ['い'] = 'ぎ', ['え'] = 'げ', ['お'] = 'ご' },
		['す'] = new Dictionary<char, char> { ['あ'] = 'さ', ['い'] = 'し', ['え'] = 'せ', ['お'] = 'そ' },
		['つ'] = new Dictionary<char, char> { ['あ'] = 'た', ['い'] = 'ち', ['え'] = 'て', ['お'] = 'と' },
		['ぬ'] = new Dictionary<char, char> { ['あ'] = 'な', ['い'] = 'に', ['え'] = 'ね', ['お'] = 'の' },
		['ふ'] = new Dictionary<char, char> { ['あ'] = 'は', ['い'] = 'ひ', ['え'] = 'へ', ['お'] = 'ほ' },
		['む'] = new Dictionary<char, char> { ['あ'] = 'ま', ['い'] = 'み', ['え'] = 'め', ['お'] = 'も' },
		['る'] = new Dictionary<char, char> { ['あ'] = 'ら', ['い'] = 'り', ['え'] = 'れ', ['お'] = 'ろ' },
		['ゅ'] = new Dictionary<char, char> { ['あ'] = 'ゃ', ['お'] = 'ょ' },
		['ゆ'] = new Dictionary<char, char> { ['あ'] = 'や', ['お'] = 'よ' },
	};

	public static char GetEquivalent(char consonant, char vowel)
	{
		var baseKana = GetKanaWithoutDakuten(consonant);
		var matchingRow = GetRowContaining(baseKana);
		var result = matchingRow[vowel];
		return baseKana == consonant
			? result
			: GetKanaWithDakuten(result);
	}

	private static Dictionary<char, char> GetRowContaining(char baseKana)
	{
		if (!_modifiedGojuuonMap.TryGetValue(baseKana, out var matchingRow))
		{
			matchingRow = _modifiedGojuuonMap.Values.Single(row => row.ContainsValue(baseKana));
		}

		return matchingRow;
	}

	private static char GetKanaWithoutDakuten(char kana)
	{
		var str = kana.ToString();
		return str.Normalize(NormalizationForm.FormD).First();
	}

	private static char GetKanaWithDakuten(char kana)
	{
		var str = kana.ToString();
		return $"{str.First()}\u3099".Normalize(NormalizationForm.FormC).First();
	}
}
