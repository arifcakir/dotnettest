﻿using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace MFFT.UIConsole.Commands
{
   public class Divide:Command
   {



       public Divide() : base("divide")
       {

           var optionNumber = new Option<int>("-number");
           optionNumber.AddAlias("-n");

           var optionBy = new Option<int>("-by");
           optionBy.AddAlias("-b");


            Add(optionNumber);
            Add(optionBy);

        }


    }
}
