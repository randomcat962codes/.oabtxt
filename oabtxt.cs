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

    public static string Decode(string text) //Decodes entered text
    {
        string result = "";

        char charType = 'E'; //Used to store the type of character that is being processed.
        string currentCharacter = ""; //Stores compoments of the character for interperating it
        bool firstCharacter = true;

        foreach (char x in text) //Looks at each character to process the information
        {
            if (inArray(encodings['C'], x)) //If our character is notation
            {
                if (!firstCharacter) //Processes the gathered information for a character
                {
                    result += encodings[charType][Convert.ToInt32(currentCharacter)];

                    //Resets remaining information for next character
                    currentCharacter = "";
                }

                charType = x;
                firstCharacter = false;
            }
            else //If our character is a number
            {
                currentCharacter += x;
            }
        }

        //Processes the final character
        result += encodings[charType][Convert.ToInt32(currentCharacter)];

        return result;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        string encodedText = CharEncoding.Encode("Hello World!");
        Console.WriteLine(encodedText);
        Console.WriteLine(CharEncoding.Decode(encodedText));
    }
}