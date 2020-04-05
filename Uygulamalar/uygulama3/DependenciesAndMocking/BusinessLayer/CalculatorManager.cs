using DataAccessLayer;
using System.Linq;
using CoreLib;


namespace BusinessLayer
{
    public class CalculatorManager: ICalculatorManager
    {
        private readonly IMathRepository _mathRepositories;

        public CalculatorManager(IMathRepository mathRepositories)
        {
            _mathRepositories = mathRepositories;
        }

        public int Sum(int[] numbers)
        {
          return  numbers.Sum();
        }

        public float Divide(int number, int by)
        {
            return  (float)number / by;
        }

        public int Minus(int number, int from)
        {
            return from - number;
        }

        public int Multiply(int number, int by)
        {
            return number * by;
        }

        public int SubtractFromMaxInt(int number)
        {

            //numeric owerflow durumnda  exception patlatmak için
            int result;
            checked
            {
                result = _mathRepositories.GetIntMax() - number;
            }

            return result;
        }

        public int AddToMinInt(int number)
        {
            return _mathRepositories.GetIntMin() + number;
        }

        public bool IsNegative(int number)
        {
            var result = _mathRepositories.IsNegative(number);

    
            return (result && number<0);

        }


        public string IsNumber(string number)
        {

            var result= _mathRepositories.IsNumber(number);

           if(result)
               return Constants.NumberMessage;


           return Constants.NotNumberMessage;


        }
    }
}
