using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using MFFT.BusinessLayer;
using MFFT.DataLayer;
using MFFT.UIConsole.Commands;

namespace MFFT.UIConsole
{
   public class Program
    {

     
        static void Main(string[] args)
        {
          
            var cliRootCommand=new Calculator();

           // cliRootCommand.Invoke("sum -n 1 2 3");

            cliRootCommand.Invoke(args);

           // Console.ReadLine();

        }

       

    }
}
