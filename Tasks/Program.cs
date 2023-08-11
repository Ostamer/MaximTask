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
	private static void evenOrOdd(char[] chars)
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
	}
	private static void Main(string[] args)
	{
		string inputString = Console.ReadLine();
		char[] chars = inputString.ToCharArray();
		string result = englishLowRegister(chars);
		if (String.IsNullOrEmpty(result))
		{
			evenOrOdd(chars);
		}
		else
		{
			Console.WriteLine("Ошибка((( в строке находятся вот такие недопустимые символы: " + result);
		}
		Console.ReadLine();
	}
}