using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Services
{
    public class MarksStringCalculator : IStringCalculator
    {

        private readonly IParser _parser;
        private string _calculationString;

        public MarksStringCalculator (IParser parser) {
            _parser = parser;
        }

        public string CalculationString => _calculationString;

        public int Add(string rawInputString)
        {

            var sum = 0;
            var numbersToAdd = _parser.Parse(rawInputString);

            var numbersToAddAsStrings = numbersToAdd.ConvertAll(x => x.ToString());
            _calculationString = string.Join("+", numbersToAddAsStrings);

            foreach ( var number in numbersToAdd )
            {
                sum += number;
            }

            return sum;
        }

    }
}
