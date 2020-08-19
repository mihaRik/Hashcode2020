using Hashcode2020.Constants;
using Hashcode2020.Helpers;
using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace Hashcode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaType = PizzaTypes.Example;

            var pizza = FileReader.GetPizzaAsync(pizzaType).Result;

            //PizzaOrder.ProcessOrderV1(pizza);

            //PizzaOrder.ProcessOrderV2(pizza);

            var result = PizzaOrder.ProcessOrderV4(pizza);

            WriteLine(result.Sum(r => r.Value));

            //FileWriter.CreateOutputFileForAllTypesAsync().Wait();
        }
    }
}
