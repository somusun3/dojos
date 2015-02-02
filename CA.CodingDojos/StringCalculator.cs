using System;
using System.Linq;

namespace CA.CodingDojos
{
    public class StringCalculator
    {
        private const string DelimiterIndicator = "//";
        private string delimiters = ",\n";

        public int Add(string input)
        {
            if (InputIsNullOrEmpty(input))
                return HandleNullAndEmptyInput();
            return HandleNonNullInput(input);
        }

        private int HandleNonNullInput(string input)
        {
            input = HandleCustomDelimiter(input);
            var numbers = input.Split(delimiters.ToCharArray());
            var parsedNumbers = numbers.Select(ParseNumber).ToArray();
            HandleNegativeNumbers(parsedNumbers);
            return parsedNumbers.Sum();
        }

        private static void HandleNegativeNumbers(int[] parsedNumbers)
        {
            if (parsedNumbers.Any(n => n < 0))
            {
                var negativeNumbers = string.Join(", ", parsedNumbers.Where(n => n < 0));
                throw new ArgumentOutOfRangeException("Negatives are not allowed. Input contains '" + negativeNumbers + "'");
            }
        }

        private string HandleCustomDelimiter(string input)
        {
            if (HasCustomDelimiter(input))
            {
                delimiters = delimiters + input.Substring(2, 1);
                input = input.Substring(3);
            }
            return input;
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith(DelimiterIndicator);
        }

        private static int ParseNumber(string input)
        {
            return int.Parse(input);
        }

        private static int HandleNullAndEmptyInput()
        {
            return 0;
        }

        private static bool InputIsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}