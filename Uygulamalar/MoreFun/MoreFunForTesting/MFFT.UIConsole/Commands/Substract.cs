using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class Substract:Command
   {



       public Substract() : base("substract")
       {

           var optionNumber = new Option<int>("-number");
           optionNumber.AddAlias("-n");

        
            Add(optionNumber);

        }


    }
}
