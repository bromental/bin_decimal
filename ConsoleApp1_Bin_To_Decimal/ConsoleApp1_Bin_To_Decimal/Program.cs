using System;

namespace ConsoleApp1_Bin_To_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string binaryInput = GetValue("Please, enter the binary number for converting into decimal");
                bool isPositive = IsPositiveBinary(binaryInput);
                int decimalOutput;
                if (isPositive)
                {
                    decimalOutput = BinaryToDecimalPositive(binaryInput);
                }
                else
                {
                    decimalOutput = BinaryToDecimalNegative(binaryInput);
                }
                Console.WriteLine(decimalOutput);
                Console.WriteLine("Hoorrray!");
            }
        }

        private static bool IsPositiveBinary(string binaryInput)
        {
            if (binaryInput.Length == 32 && binaryInput[0] == '0')
            {
                return true;
            }
            else if (binaryInput.Length == 32 && binaryInput[0] == '1')
            {
                return false;
            }
            return true;
        }

        private static string GetValue(string line)
        {
            Console.WriteLine(line);
            string input = Console.ReadLine();
            return input;
        }

        private static int BinaryToDecimalPositive(string binaryInput)
        {
            int decimalNumber = GetPowerOfTwo(binaryInput, c => c == '1');
            return decimalNumber;
        }

        private static int BinaryToDecimalNegative(string binaryInput)
        {
            int decimalNumber = GetPowerOfTwo(binaryInput, c => c == '0');
            return (decimalNumber + 1) * - 1;
        }

        private static int GetPowerOfTwo(string binaryInput, Func<char, bool> comparator)
        {
            int decimalNumber = 0;
            for (int i = binaryInput.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (comparator(binaryInput[i]))
                {
                    decimalNumber = decimalNumber + (int)Math.Pow(2, j);
                }
            }
            return decimalNumber;
        }
    }
}
