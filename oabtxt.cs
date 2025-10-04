public static class CharEncoding //Contains the data and functions for encoding text
{
    private static Dictionary<char, char[]> encodings = new() //Contains the encoded text
    {
        {'C', ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z']},
        {'L', ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']},
        {'N', ['1','2','3','4','5','6','7','8','9','0']},
        {'P', ['.',',','!','?']},
        {'S', [' ','~','`','@','#','$','%','^','&','*','(',')','_','-','+','=','|','\\','{','}','[',']',':',';','"','\'','<','>','/']}
    };

    private static bool inArray(char[] arr, char val)
    {
        foreach (char x in arr)
        {
            if (val == x)
            {
                return true;
            }
        }
        return false;
    }

    public static string Encode(string text) //Encodes entered text
    {
        string result = "";

        foreach (char x in text) //Look at each character and add it's encoding to the result
        {
            if (inArray(encodings['C'], x)) //Capital
            {
                result += "C" + Convert.ToString(Array.IndexOf(encodings['C'], x));
            }
            else if (inArray(encodings['L'], x)) //Lowercase
            {
                result += "L" + Convert.ToString(Array.IndexOf(encodings['L'], x));
            }
            else if (inArray(encodings['N'], x)) //Number
            {
                result += "N" + Convert.ToString(Array.IndexOf(encodings['N'], x));
            }
            else if (inArray(encodings['P'], x)) //Punctuation
            {
                result += "P" + Convert.ToString(Array.IndexOf(encodings['P'], x));
            }
            else if (inArray(encodings['S'], x)) //Special
            {
                result += "S" + Convert.ToString(Array.IndexOf(encodings['S'], x));
            }
        }

        return result;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(CharEncoding.Encode("Hello World!"));
    }
}