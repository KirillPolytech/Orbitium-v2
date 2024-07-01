using System.Linq;
using System.Text;

public static class TextParser
{
    private static readonly char[] Integers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

    public static string ParseTextToInt(string text)
    {
        StringBuilder output = new StringBuilder();
        foreach (char t1 in from t in text from t1 in Integers where t == t1 select t1)
        {
            output.Append(t1);
        }
        return output.ToString();
    }
}

