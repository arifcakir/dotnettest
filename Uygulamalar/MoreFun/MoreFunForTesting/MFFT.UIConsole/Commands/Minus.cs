using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class Minus:Command
   {



       public Minus() : base("minus")
       {

           var optionNumber = new Option<int>("-number");
           optionNumber.AddAlias("-n");

           var optionFrom = new Option<int>("-from");
           optionFrom.AddAlias("-f");


            Add(optionNumber);
            Add(optionFrom);

        }


    }
}
