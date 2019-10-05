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

        public MarksStringCalculator (IParser parser) {
            _parser = parser;
        }

        public string HelloWorld()
        {
            return _parser.Parse();
        }
    }
}
