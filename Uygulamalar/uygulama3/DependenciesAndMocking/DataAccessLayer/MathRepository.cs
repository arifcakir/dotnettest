using CoreLib;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class MathRepository: IMathRepository
    {
        public MathRepository()
        {


        }

        public int GetIntMax()
        {
            return int.MaxValue;
        }

        public int GetIntMin()
        {
            return int.MinValue;
        }
        
        public bool IsNegative(int number)
        {

            return number < 0;

        }

        public bool IsNumber(string number)
        {
            var result = int.TryParse(number, out int outnumber);
            return result;

        }

        public List<int> GetFibonaccies()
        {
            return new List<int>{ 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };
        }
    }
}
