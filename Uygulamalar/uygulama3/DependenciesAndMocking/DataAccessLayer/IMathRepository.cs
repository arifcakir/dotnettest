
using System.Collections.Generic;

namespace DataAccessLayer
{
   public interface IMathRepository
    {
        int GetIntMax();
        int GetIntMin();
        bool IsNegative(int number);

        bool IsNumber(string number);

        List<int> GetFibonaccies();
    }
}
