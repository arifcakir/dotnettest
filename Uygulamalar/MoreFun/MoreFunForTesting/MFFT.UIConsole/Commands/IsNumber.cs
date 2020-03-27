using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class IsNumber:Command
   {



       public IsNumber() : base("isnumber")
       {
           var optionNumber = new Option<string>("-number");
           optionNumber.AddAlias("-n");
           Add(optionNumber);
        }


    }
}
