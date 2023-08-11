internal class Program
{
	private static void Main(string[] args)
	{
		string inputString = Console.ReadLine();
		int lenString = inputString.Length;
		char[] chars = inputString.ToCharArray();
		string result = "";
		if (lenString % 2 != 0)
		{
			Array.Reverse(chars);
			result = new string(chars) + inputString;
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
		Console.ReadLine();
	}
}