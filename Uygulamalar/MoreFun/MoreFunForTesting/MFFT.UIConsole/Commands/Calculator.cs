using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using MFFT.BusinessLayer;
using MFFT.DataLayer;
using Microsoft.Extensions.DependencyInjection;

namespace MFFT.UIConsole.Commands
{
   public class Calculator:RootCommand
    {
        private ICalculatorManager _calculatorManager;

        private  void SetupServices()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICalculatorManager, CalculatorManager>()
                .AddSingleton<IMathRepository, MathRepository>()
                .BuildServiceProvider();

            //configure console logging
            _calculatorManager = serviceProvider.GetService<ICalculatorManager>();
        }


        public Calculator() : base("calculator")
        {
            SetupServices();

            AddCommand(new Multiply
            {
                Handler = CommandHandler.Create<int,int>(multiply)
            });
            AddCommand(new Sum
            {
                Handler = CommandHandler.Create<int[]>(sum)
            });
            AddCommand(new Minus
            {
                Handler = CommandHandler.Create<int,int>(minus)
            });
            AddCommand(new Substract
            {
                Handler = CommandHandler.Create<int>(substract)
            });
            AddCommand(new Add
            {
                Handler = CommandHandler.Create<int>(add)
            });

            AddCommand(new Divide
            {
                Handler = CommandHandler.Create<int,int>(divide)
            });


            AddCommand(new IsNumber
            {
                Handler = CommandHandler.Create<string>(isnumber)
            });

            AddCommand(new IsNegative
            {
                Handler = CommandHandler.Create<int>(isnegative)
            });

        }

        public void sum(int[] numbers)
        {
            var result = _calculatorManager.Sum(numbers);
            Console.WriteLine($"result is {result}");
        }

        public void multiply(int number, int by)
        {
            var result = _calculatorManager.Multiply(number, by);
            Console.WriteLine($"result is {result}");
        }

        public void divide(int number, int by)
        {
            var result = _calculatorManager.Divide(number, by);
            Console.WriteLine($"result is {result}");
        }


        public void minus(int number, int from)
        {
            var result = _calculatorManager.Minus(number, from);
            Console.WriteLine($"result is {result}");
        }

        public void substract(int number)
        {
            var result = _calculatorManager.SubtractFromMaxInt(number);
            Console.WriteLine($"result is {result}");
        }

        public void add(int number)
        {
            var result = _calculatorManager.AddToMinInt(number);
            Console.WriteLine($"result is {result}");
        }

        public void isnumber(string number)
        {
            var result = _calculatorManager.IsNumber(number);
            Console.WriteLine($"result is: {result}");
        }


        public void isnegative(int number)
        {
            var result = _calculatorManager.IsNegative(number);
            Console.WriteLine($"result is: {result}");
        }

    }
}
