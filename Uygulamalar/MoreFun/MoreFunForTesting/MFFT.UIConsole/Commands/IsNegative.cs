using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class IsNegative:Command
   {



       public IsNegative() : base("isnegative")
       {
           var optionNumber = new Option<int>("-number");
           optionNumber.AddAlias("-n");
           Add(optionNumber);
        }


    }
}
