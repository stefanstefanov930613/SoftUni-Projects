using System;
using System.Text;
using System.Linq;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            char[] two = new char[] { 'a', 'b', 'c' };
            char[] three = new char[] { 'd', 'e', 'f' };
            char[] four = new char[] { 'g', 'h', 'i' };
            char[] five = new char[] { 'j', 'k', 'l' };
            char[] six = new char[] { 'm', 'n', 'o' };
            char[] seven = new char[] { 'p', 'q', 'r', 's' };
            char[] eight = new char[] { 't', 'u', 'v' };
            char[] nine = new char[] { 'w', 'x', 'y', 'z' };
            var sb = new StringBuilder();


            for (int i = 0; i < input; i++)
            {

                string digits = Console.ReadLine();

                var length = digits.Length;

                var charToAppend = ' ';

                if (digits[0] == '2')
                {
                    charToAppend = two[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '3')
                {
                    charToAppend = three[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '4')
                {
                    charToAppend = four[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '5')
                {
                    charToAppend = five[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '6')
                {
                    charToAppend = six[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '7')
                {
                    charToAppend = seven[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '8')
                {
                    charToAppend = eight[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits[0] == '9')
                {
                    charToAppend = nine[length - 1];
                    sb.Append(charToAppend);
                }
                else if (digits == "0")
                {
                    sb.Append(" ");
                }

            }

            Console.WriteLine(sb.ToString());
        }
    }
}
