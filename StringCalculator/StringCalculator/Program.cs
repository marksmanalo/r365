using StringCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace StringCalculator
{
    class Program
    {
   
        static void Main(string[] args)
        {

            var container = new UnityContainer();

            container.RegisterType<IParser, Parser>();

            var calculator = container.Resolve<MarksStringCalculator>();

            var temp = calculator.HelloWorld();

            Console.WriteLine(temp);

            Console.ReadLine();
        }
    }
}
