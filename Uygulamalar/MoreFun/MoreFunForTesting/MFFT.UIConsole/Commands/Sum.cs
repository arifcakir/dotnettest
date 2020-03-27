using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class Sum : Command
   {
       public Sum() : base("sum")
       {
           var option = new Option<int[]>("-numbers");
           option.AddAlias("-n");
           Add(option);
       }
    }
}
