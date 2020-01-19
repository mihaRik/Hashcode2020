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
            var pizza = FileReader.GetPizza(InputTypes.Example).Result;
            //PizzaOrder.ProcessOrderV1(pizza);

            PizzaOrder.ProcessOrderV2(pizza);
        }
    }
}
