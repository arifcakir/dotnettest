using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDTestProject.BusinessLayer
{
   public static class Extensions
    {
        public static int ToMultiply(this int[] numbers)
        {
            return numbers.Aggregate((a, x) => a * x);
        }

    }
}
