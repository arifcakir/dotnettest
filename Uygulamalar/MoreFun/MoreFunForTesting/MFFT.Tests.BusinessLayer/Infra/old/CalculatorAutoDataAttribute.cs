using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace MFFT.Tests.BusinessLayer.Infra
{

    public class InlineData
    {
        public int[] Numbers;
        public int Result;

    }
    public  class CalculatorAutoDataAttribute:AutoDataAttribute
    {


        public CalculatorAutoDataAttribute() : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
        {

        }



        private static InlineData createData()
        {
            var inlineData = new InlineData();

            var r1 = new Random().Next(-100, -1);
            var r2 = new Random().Next(-100, -1);
            var r3 = new Random().Next(-100, -1);

            var result = r1 + r2 + r3;

            inlineData.Numbers = new[] { r1, r2, r3 };
            inlineData.Result = result;

            return inlineData;
        }

    }
}
