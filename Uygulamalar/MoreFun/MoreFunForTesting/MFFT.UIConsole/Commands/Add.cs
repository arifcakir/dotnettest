using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class Add:Command
   {



       public Add() : base("add")
       {

           var optionNumber = new Option<int>("-number");
           optionNumber.AddAlias("-n");



            Add(optionNumber);

        }


    }
}
