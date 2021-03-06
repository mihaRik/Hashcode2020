﻿using Hashcode2020.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hashcode2020
{
    public class FileReader
    {
        public static async Task<PizzaViewModel> GetPizzaAsync(string inputTypes)
        {
            var fileLines = await File.ReadAllLinesAsync(Path.Combine(@"C:\Users\User\Desktop\hashcode 2020", inputTypes));

            var firstLine = fileLines[0];
            var secondLine = fileLines[1];

            var firstLineDatas = firstLine.Split(' ');

            var limit = int.Parse(firstLineDatas[0]);
            var typeCount = int.Parse(firstLineDatas[1]);
            var slicesCountString = secondLine.Split(' ');

            var slicesCounts = new Dictionary<int, int>();
            var key = 0;
            slicesCountString.ToList().ForEach(s =>
            {
                slicesCounts.Add(key, int.Parse(s));
                key++;
            });

            return new PizzaViewModel
            {
                PizzaPiecesLimit = limit,
                PizzaTypeCount = typeCount,
                PizzaSlicesSizes = slicesCounts
            };
        }
    }
}
