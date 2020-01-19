using Hashcode2020.Constants;
using Hashcode2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Hashcode2020.Helpers
{
    public class PizzaOrder
    {
        public static void ProcessOrderV1(PizzaViewModel pizza)
        {
            var arrSum = pizza.PizzaSlicesSizes.Sum();

            if (arrSum < pizza.PizzaPiecesLimit)
                WriteLine(arrSum);

            var helper = 0;

            while (arrSum - helper > pizza.PizzaPiecesLimit)
            {
                var diff = arrSum - pizza.PizzaPiecesLimit;

                helper = pizza.PizzaSlicesSizes.FirstOrDefault(s => s >= diff);

                if (arrSum - helper < pizza.PizzaPiecesLimit)
                    WriteLine(arrSum - helper);

                arrSum -= helper;
            }
        }

        public static void ProcessOrderV2(PizzaViewModel pizza)
        {
            var avg = pizza.PizzaSlicesSizes.Average();
            var takeCount = pizza.PizzaPiecesLimit / avg;

            var takenArr = pizza.PizzaSlicesSizes.Take((int)takeCount);

            WriteLine(takenArr.Sum());
        }
    }
}
