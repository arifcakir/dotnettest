
namespace MFFT.DataLayer
{
   public interface ICalculatorManager
   {
       int Sum(int[] numbers);
       float Divide(int number, int by);
       int Minus(int number,int from);
       int Multiply(int number, int by);
       int SubtractFromMaxInt(int number);
       int AddToMinInt(int number);

       bool IsNegative(int number);

       string IsNumber(string number);

   }
}
