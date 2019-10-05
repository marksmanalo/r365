using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Services
{
    public class Parser : IParser
    {

        private readonly char[] delimiters = new char[] { ',' };
        private const int maxInputs = 2;

        public List<int> Parse(string stringToParse)
        {
            var numbers = new List<int>();
            var parsedString = stringToParse.Split(delimiters);

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

            if (numbers.Count > maxInputs)
            {
                throw new Exception("Exceeded maximum number of inputs!");
            }

            return numbers;
        }
    }
}
