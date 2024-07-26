using System.Text;

namespace OldPhoneSolution
{

    class OldPhoneConverter
    {

        // Dictionary with key maps with read only access
        private static readonly Dictionary<char, string> KeyMap = new()
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"}
        };

        internal static String OldPhonePad(string input)
        {
            StringBuilder result = new();
            char prevChar = '\0';
            int count = 0;

            foreach (char currChar in input)
            {
                if (currChar == '#')
                {
                    if(prevChar != '\0')
                    {
                        string keysOption = KeyMap[prevChar];
                        result.Append(keysOption[count % keysOption.Length]);

                    }
                    break;
                }

                if (currChar ==  '*') 
                {
                    if(result.Length > 0)
                    {
                        string keysOption = KeyMap[prevChar];
                        result.Append(keysOption[count % keysOption.Length]);
                        --result.Length;
                    }
                    prevChar = '\0';
                    count = 0;

                }
                else if (currChar == ' ')
                {
                    if(count >= 0 && prevChar != '\0')
                    {
                        string keysOption = KeyMap[prevChar];
                        result.Append(keysOption[count % keysOption.Length]);
                        count = 0;
                    }
                    // reset previous char
                    prevChar = '\0';
                }
                else
                {
                    // check for repeting char
                    if (currChar == prevChar)
                    {
                        ++count;
                    }
                    else
                    {
                        if (prevChar != '\0')
                        {
                            string keysOption = KeyMap[prevChar];
                            result.Append(keysOption[count % keysOption.Length]);
                        }
                        prevChar = currChar;
                        count = 0;
                    }
                }
            }

            return result.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string test = OldPhoneConverter.OldPhonePad("2222211#");
            Console.WriteLine(test);
        }
    }
}