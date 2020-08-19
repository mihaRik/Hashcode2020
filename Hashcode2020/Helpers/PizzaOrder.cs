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
            var arrSum = pizza.PizzaSlicesSizes.Sum(s => s.Value);

            if (arrSum < pizza.PizzaPiecesLimit)
                WriteLine(arrSum);

            var helper = 0;

            while (arrSum - helper > pizza.PizzaPiecesLimit)
            {
                var diff = arrSum - pizza.PizzaPiecesLimit;

                helper = pizza.PizzaSlicesSizes.FirstOrDefault(s => s.Value >= diff).Value;

                if (arrSum - helper < pizza.PizzaPiecesLimit)
                    WriteLine(arrSum - helper);

                arrSum -= helper;
            }
        }

        public static IEnumerable<KeyValuePair<int, int>> ProcessOrderV2(PizzaViewModel pizza)
        {
            var avg = pizza.PizzaSlicesSizes.Average(s => s.Value);
            var takeCount = pizza.PizzaPiecesLimit / avg;

            var takenArr = pizza.PizzaSlicesSizes.Take((int)takeCount);

            return takenArr;
        }

        public static IEnumerable<KeyValuePair<int, int>> ProcessOrderV3(PizzaViewModel pizza)
        {
            var sum = 0;
            var arr = pizza.PizzaSlicesSizes.ToArray();
            var limit = pizza.PizzaPiecesLimit;
            var finalArr = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (sum + arr[i].Value <= limit)
                {
                    sum += arr[i].Value;
                    finalArr.Add(arr[i].Key, arr[i].Value);
                }
                else if (sum == limit) return finalArr;
                else if (arr.Any(a => a.Value == sum + arr[i].Value - limit))
                {
                    finalArr.Remove(arr.First(a => a.Value == sum + arr[i].Value - limit).Key);
                    finalArr.Add(arr[i].Key, arr[i].Value);
                    return finalArr;
                }
            }

            return finalArr;
        }

        public static IEnumerable<KeyValuePair<int, int>> ProcessOrderV4(PizzaViewModel pizza)
        {
            var sum = 0;
            var arr = pizza.PizzaSlicesSizes.ToArray();
            var limit = pizza.PizzaPiecesLimit;
            var finalArr = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (sum + arr[i].Value <= limit)
                {
                    sum += arr[i].Value;
                    finalArr.Add(arr[i].Key, arr[i].Value);
                }
                else if (sum == limit) return finalArr.OrderBy(a => a.Key);
                else if (arr.Any(a => a.Value > sum + arr[i].Value - limit))
                {
                    var elementToRemove = arr.First(a => a.Value >= sum + arr[i].Value - limit).Key;
                    finalArr.Remove(elementToRemove);
                    finalArr.Add(arr[i].Key, arr[i].Value);
                    return finalArr.OrderBy(a => a.Key);
                }
            }

            return finalArr.OrderBy(a => a.Key);
        }
    }
}
