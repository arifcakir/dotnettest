
namespace MFFT.DataLayer
{
   public interface IMathRepository
    {
        int GetIntMax();
        int GetIntMin();
        bool IsNegative(int number);

        string IsNumber(string number);
    }
}
