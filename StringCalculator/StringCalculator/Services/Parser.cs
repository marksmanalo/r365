using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Services
{
    public class Parser : IParser
    {

        private readonly string[] delimiters = new [] { ",", "\\n" };
        private const int maxNumber = 1000;

        public List<int> Parse(string stringToParse)
        {
            var numbers = new List<int>();
            var negativeNumbers = new List<int>();
            var parsedString = stringToParse.Split(delimiters, StringSplitOptions.None);

            foreach (var numberString in parsedString)
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
                else {
                    numbers.Add(0);
                }
            }

            if (negativeNumbers.Any()) {

                var numbersToString = negativeNumbers.ConvertAll(x => x.ToString());
                var csv = string.Join(",", numbersToString);
                throw new Exception($"Negative numbers not allowed: {csv}");

            }

            return numbers;
        }
    }
}
