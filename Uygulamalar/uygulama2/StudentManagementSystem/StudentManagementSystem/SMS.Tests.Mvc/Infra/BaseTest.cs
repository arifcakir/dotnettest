using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace SMS.Tests.Mvc.Infra
{
   public class BaseTest
    {
        public BaseTest()
        {

            Thread.CurrentThread.CurrentCulture=new CultureInfo("en-US");
        }
    }
}
