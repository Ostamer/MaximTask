using System;

internal class Program
{
	private static string englishLowRegister(char[] chars)
	{
		string englishAlphabet = "qwertyuiopasdfghjklzxcvbnm";
		string result = "";
		for (int i = 0; i < chars.Length; i++)
		{
			if (!englishAlphabet.Contains(chars[i]))
			{
				result += chars[i];
			}
		}
		return result;
	}

	private static string evenOrOdd(char[] chars)
	{
		int lenString = chars.Length;
		string result = "";
		if (lenString % 2 != 0)
		{
			char[] reverseChar = new char[lenString];
			Array.Copy(chars, 0, reverseChar, 0, lenString);
			Array.Reverse(reverseChar);
			result = new string(reverseChar) + new string(chars);
			Console.WriteLine(result);
		}
		else
		{
			for (int i = chars.Length / 2 - 1; i >= 0; i--)
			{
				result += chars[i];
			}
			for (int i = chars.Length - 1; i >= chars.Length / 2; i--)
			{
				result += chars[i];
			}
			Console.WriteLine(result);
		}
		return result;
	}

	private static void countAllChars(string inputString)
	{
		char[] chars = inputString.ToCharArray();
		Dictionary<char, int> result = new Dictionary<char, int>();
		foreach (char c in chars)
		{
			if (result.ContainsKey(c))
			{
				result[c]++;
			}
			else
			{
				result[c] = 1;
			}
		}
		foreach (var c in result)
		{
			Console.WriteLine($"Буква: {c.Key} встречается: {c.Value} раз.");
		}
	}

	private static void maxSubString(string inputString)
	{
		char[] chars = inputString.ToCharArray();
		string alphabet = "aeoiuy";
		int first = -1;
		int second = -1;
		for (int i = 0; i < chars.Length; i++)
		{
			if (alphabet.Contains(chars[i]))
			{
				if (first == -1)
				{
					first = i;
				}
				else
				{
					second = i;
				}
			}
		}
		if (first == -1 || second == -1)
		{
			Console.WriteLine("В данной строке менее двух гласных букв");
		}
		else
		{
			char[] result= new char[second-first+1];
			Array.Copy(chars, first, result, 0, second - first+1);
			Console.WriteLine(new string(result));
        }
    }

	private static void Main(string[] args)
	{
		string inputString = Console.ReadLine();
		char[] chars = inputString.ToCharArray();
		string result = englishLowRegister(chars);
		if (String.IsNullOrEmpty(result))
		{
			string finalString = evenOrOdd(chars);
			countAllChars(finalString);
			maxSubString(finalString);
		}
		else
		{
			Console.WriteLine("Ошибка((( в строке находятся вот такие недопустимые символы: " + result);
		}
		Console.ReadLine();
	}
}