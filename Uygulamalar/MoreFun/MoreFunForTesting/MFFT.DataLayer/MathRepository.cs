using MFFT.Core;

namespace MFFT.DataLayer
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

        public string IsNumber(string number)
        {


            if (int.TryParse(number, out int result))
            {

                return Constants.NumberMessage;
            }

            return Constants.NotNumberMessage;

        }


    }
}
