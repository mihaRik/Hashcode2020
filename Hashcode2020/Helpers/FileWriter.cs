using Hashcode2020.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hashcode2020.Helpers
{
    class FileWriter
    {
        public static async Task ProcessOrderOutput(string inputType)
        {
            var pizza = await FileReader.GetPizza(inputType);
            var fileName = inputType.Replace(".in", ".out");

            using (var writer = new StreamWriter(Path.Combine(@"C:\Users\User\Desktop\hashcode 2020\outputs for excel", fileName)))
            {
                foreach (var line in pizza.PizzaSlicesSizes)
                {
                    await writer.WriteLineAsync(line.ToString());
                }
            }
        }
    }
}
