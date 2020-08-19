using System;
using System.Collections.Generic;
using System.Text;

namespace Hashcode2020.ViewModels
{
    public class PizzaViewModel
    {
        public int PizzaPiecesLimit { get; set; }
        public int PizzaTypeCount { get; set; }
        public Dictionary<int, int> PizzaSlicesSizes { get; set; }
    }
}
