using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator.Services
{
    public class Parser : IParser
    {
        private const int maxNumber = 1000;

        public List<int> Parse(string stringToParse)
        {
            var numbers = new List<int>();
            var negativeNumbers = new List<int>();
            string[] parsedNumbers = { "" };

            if (!stringToParse.StartsWith("//")) {
               parsedNumbers = stringToParse.Split(new[] { ",", "\\n" }, StringSplitOptions.None);
            } else
            {
                parsedNumbers = ParseWithCustomDelimiter(stringToParse);
            }

            AssembleListOfNumbers(parsedNumbers, numbers, negativeNumbers);

            CheckForNegativeNumbers(negativeNumbers);

            return numbers;
        }

        private string[] ParseWithCustomDelimiter(string stringToParse)
        {
            string[] parsedNumbers = { "" };

            var parsedString = stringToParse.Split(new[] { "\\n" }, StringSplitOptions.None);

            if (parsedString.Length < 2)
            {
                throw new Exception("Invalid input");
            }

            var unparsedCustomDelimiter = parsedString[0];

            var singleDelimiter = @"(?<=\/\/)(.*)";
            var squareBrackets = @"\[(.*?)\]";

            string[] patterns = { squareBrackets, singleDelimiter };
            List<string> customDelimiters = new List<string> { };

            foreach (var pattern in patterns)
            {
                var matches = Regex.Matches(unparsedCustomDelimiter, pattern);
                if (matches.Count > 0)
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                       customDelimiters.Add(matches[i].Groups[1].Value);
                    }
                    break;
                }

            }

            if (customDelimiters.Count == 0)
            {
                throw new Exception("Invalid input");
            }

            parsedNumbers = parsedString[1].Split(customDelimiters.ToArray(), StringSplitOptions.None);

            return parsedNumbers;
        }

        private void AssembleListOfNumbers(string[] parsedNumbers, List<int> numbers, List<int> negativeNumbers) {
            foreach (var numberString in parsedNumbers)
            {
                if (Int32.TryParse(numberString, out int number) && number <= maxNumber)
                {
                    if (number >= 0)
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        negativeNumbers.Add(number);
                    }
                }
                else
                {
                    numbers.Add(0);
                }
            }
        }

        private void CheckForNegativeNumbers(List<int> negativeNumbers) {

            if (negativeNumbers.Any())
            {

                var numbersToString = negativeNumbers.ConvertAll(x => x.ToString());
                var csv = string.Join(",", numbersToString);
                throw new Exception($"Negative numbers not allowed: {csv}");

            }

        }
    }
}
