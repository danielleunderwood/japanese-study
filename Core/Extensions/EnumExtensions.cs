using System;
using System.Text;

namespace Core.Extensions;

public static class EnumExtensions
{
	public static string GetDescription<T>(this T enumValue) where T : struct, Enum
	{
		var defaultValue = Enum.GetValues<T>()[0];
		return enumValue.Equals(defaultValue)
			? string.Empty
			: ConvertPascalCaseToWordBreaks(enumValue);
	}

	private static string ConvertPascalCaseToWordBreaks<T>(T enumValue)
	{
		var result = enumValue.ToString();
		var stringBuilder = new StringBuilder();
		for (var i = 0; i < result.Length; i++)
		{
			AppendLowercaseCharacter(stringBuilder, result[i]);
		}

		return stringBuilder.ToString().Trim();
	}

	private static void AppendLowercaseCharacter(StringBuilder stringBuilder, char character)
	{
		if (char.IsUpper(character))
		{
			stringBuilder.Append(' ');
			character = char.ToLower(character);
		}
		stringBuilder.Append(character);

	}
}
