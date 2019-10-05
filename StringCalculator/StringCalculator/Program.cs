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

        private static UnityContainer container;
   
        static void Main(string[] args)
        {

            SetupDependencyInjectionContainer();

            var calculator = container.Resolve<MarksStringCalculator>();

            var enteredString = PromptTheUser();

            var sum = calculator.Add(enteredString);

            Console.WriteLine("The sum is: {0}", sum);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static string PromptTheUser() {

            Console.WriteLine("String Calcualtor!\n\n");
            Console.WriteLine("Enter your numbers to add separated by a comma");

            return Console.ReadLine();

        }

        private static void SetupDependencyInjectionContainer() {

            container = new UnityContainer();

            container.RegisterType<IParser, Parser>();

        }
    }
}
