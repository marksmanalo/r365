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

        public List<int> Parse(string stringToParse)
        {
            var numbers = new List<int>();
            var parsedString = stringToParse.Split(delimiters, StringSplitOptions.None);

            foreach (var numberString in parsedString)
            {
                if (Int32.TryParse(numberString, out int number))
                {
                    numbers.Add(number);
                }
                else {
                    numbers.Add(0);
                }
            }

            return numbers;
        }
    }
}
