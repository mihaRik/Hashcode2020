using Hashcode2020.Constants;
using Hashcode2020.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Hashcode2020.Helpers
{
    class FileWriter
    {
        public static async Task ProcessOrderOutputForExcelAsync(string inputType)
        {
            var pizza = await FileReader.GetPizzaAsync(inputType);
            var fileName = inputType.Replace(".in", ".out");

            using (var writer = new StreamWriter(Path.Combine(@"C:\Users\User\Desktop\hashcode 2020\outputs for excel", fileName)))
            {
                foreach (var line in pizza.PizzaSlicesSizes)
                {
                    await writer.WriteLineAsync(line.ToString());
                }
            }
        }

        private static async Task CreateOutputFileAsync(IEnumerable<KeyValuePair<int, int>> resultArr, string inputType)
        {
            var fileName = inputType.Replace(".in", ".out");
            using (var writer = new StreamWriter(Path.Combine(@"C:\Users\User\Desktop\hashcode 2020\outputs", fileName)))
            {
                await writer.WriteLineAsync(resultArr.Count().ToString());

                foreach (var pizza in resultArr)
                {
                    await writer.WriteAsync($"{ pizza.Key.ToString()} ");
                }
            }
        }

        public static async Task CreateOutputFileForAllTypesAsync()
        {
            await Task.Run(() =>
            {
                var pizzaTasks = new Task<PizzaViewModel>[]
                {
                FileReader.GetPizzaAsync(PizzaTypes.Example),
                FileReader.GetPizzaAsync(PizzaTypes.Small),
                FileReader.GetPizzaAsync(PizzaTypes.Medium),
                FileReader.GetPizzaAsync(PizzaTypes.QuiteBig),
                FileReader.GetPizzaAsync(PizzaTypes.AlsoBig)
                };

                Task.WaitAll(pizzaTasks);

                var exampleResultArr = PizzaOrder.ProcessOrderV4(pizzaTasks[0].Result);
                var smallResultArr = PizzaOrder.ProcessOrderV4(pizzaTasks[1].Result);
                var mediumResultArr = PizzaOrder.ProcessOrderV4(pizzaTasks[2].Result);
                var quiteBigResultArr = PizzaOrder.ProcessOrderV4(pizzaTasks[3].Result);
                var alsoBigResultArr = PizzaOrder.ProcessOrderV4(pizzaTasks[4].Result);

                var resultTasks = new Task[]
                {
                    CreateOutputFileAsync(exampleResultArr, PizzaTypes.Example),
                    CreateOutputFileAsync(smallResultArr, PizzaTypes.Small),
                    CreateOutputFileAsync(mediumResultArr, PizzaTypes.Medium),
                    CreateOutputFileAsync(quiteBigResultArr, PizzaTypes.QuiteBig),
                    CreateOutputFileAsync(alsoBigResultArr, PizzaTypes.AlsoBig)
                };

                Task.WaitAll(resultTasks);
            });
        }
    }
}