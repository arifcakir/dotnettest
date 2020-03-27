using System.Globalization;
using System.Threading;

namespace SMS.Tests.BBD.Infra
{
   public class BaseTest
    {
        public BaseTest()
        {

            Thread.CurrentThread.CurrentCulture=new CultureInfo("en-US");
        }
    }
}
