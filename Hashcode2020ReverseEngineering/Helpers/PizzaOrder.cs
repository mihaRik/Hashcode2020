using System;
using System.Collections.Generic;
using System.Linq;
using Hashcode2020ReverseEngineering.ViewModels;
using static System.Console;

namespace Hashcode2020ReverseEngineering.Helpers
{
    public class PizzaOrder
    {
        public static PizzaViewModel CreatePizzaOrder(int pizzaLimit, int pizzaTypeCount)
        {
            var pizzaSlicesSizes = new List<int>();
            var random = new Random();

            for (int i = 0; i < pizzaTypeCount; i++)
            {
                var min = pizzaSlicesSizes.LastOrDefault() == 0 ? 2 : pizzaSlicesSizes.LastOrDefault();
                var percent = (random.Next(20, 150) / 100m) + 1;
                pizzaSlicesSizes.Add(min * (int)decimal.Floor(percent));
            }

            return new PizzaViewModel
            {
                PizzaPiecesLimit = pizzaLimit,
                PizzaTypeCount = pizzaTypeCount,
                PizzaSlicesSizes = pizzaSlicesSizes
            };
        }

        public static IEnumerable<double> FindPercentDiffBetweenSlices(Hashcode2020.ViewModels.PizzaViewModel pizza)
        {
            for (int i = 0; i < pizza.PizzaSlicesSizes.Count() - 1; i++)
            {
                var diffPercent = (double)pizza.PizzaSlicesSizes[i + 1] / pizza.PizzaSlicesSizes[i] * 100 - 100;
                yield return Math.Round(diffPercent, 4);
            }
        }

        public static IEnumerable<double> FindDiffBetweenSlices(Hashcode2020.ViewModels.PizzaViewModel pizza)
        {
            for (int i = 0; i < pizza.PizzaSlicesSizes.Count() - 1; i++)
            {
                var diff = pizza.PizzaSlicesSizes[i + 1] - pizza.PizzaSlicesSizes[i];
                yield return diff;
            }
        }
    }
}
