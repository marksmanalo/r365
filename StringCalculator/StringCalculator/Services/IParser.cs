﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Services
{
    public interface IParser
    {
        List<int> Parse(string stringToParse);

    }
}
