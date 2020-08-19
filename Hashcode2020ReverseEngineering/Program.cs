using Hashcode2020;
using Hashcode2020.Constants;
using Hashcode2020ReverseEngineering.Helpers;
using Hashcode2020ReverseEngineering.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using static System.Console;

namespace Hashcode2020ReverseEngineering
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizza = PizzaOrder.CreatePizzaOrder(100, 10);


            //foreach (var slice in pizza.PizzaSlicesSizes)
            //{
            //    WriteLine(slice);
            //}

            var pizza2 = FileReader.GetPizzaAsync(PizzaTypes.Small).Result;
            var percents = PizzaOrder.FindDiffBetweenSlices(pizza2);

            //percents = percents.Skip(Array.IndexOf(percents.ToArray(), percents.Max()) + 1);

            WriteLine($"index: { Array.IndexOf(percents.ToArray(), percents.Max()) }");
            WriteLine($"min: { percents.Min() }");
            WriteLine($"max: { percents.Max() }");
            WriteLine($"avg: { percents.Average() }");
            foreach (var percent in percents)
            {
                WriteLine(percent);
            }
        }
    }
}
