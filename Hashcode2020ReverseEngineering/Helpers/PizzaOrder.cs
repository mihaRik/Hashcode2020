using System;
using System.Collections.Generic;
using System.Linq;
using Hashcode2020ReverseEngineering.ViewModels;

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
                var min = pizzaSlicesSizes.LastOrDefault();
                var pizzaSliceSize = random.Next(min, pizzaLimit);
                pizzaSlicesSizes.Add(pizzaSliceSize);
            }

            return new PizzaViewModel
            {
                PizzaPiecesLimit = pizzaLimit,
                PizzaTypeCount = pizzaTypeCount,
                PizzaSlicesSizes = pizzaSlicesSizes
            };
        }
    }
}
