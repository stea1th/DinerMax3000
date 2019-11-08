using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMaxConsole
{
    class Summ
    {
        public void Execute()
        {
            List<double> numbers = ReadNumbersFromConsole();
            WriteInConsole(SumNumbers(numbers));
        }

        private double SumNumbers(List<double> numbers)
        {
            return numbers.Sum();
        }

        private List<double> ReadNumbersFromConsole()
        {
            List<double> numbers = new List<double>();
            for (int i = 0; i < 2; i++)
            {
                numbers.Add(GetNumberFromConsole());
            }
            return numbers;
        }

        private void WriteInConsole(double result)
        {
            Console.WriteLine("Result is: " + result);
            Console.ReadKey();
        }

        private double GetNumberFromConsole()
        {
            Console.WriteLine("Enter Number: ");
            return Double.Parse(Console.ReadLine());
        }

    }
}
