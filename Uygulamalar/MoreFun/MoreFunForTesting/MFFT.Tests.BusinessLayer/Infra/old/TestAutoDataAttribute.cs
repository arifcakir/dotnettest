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

    public class TestInlineData
    {
        public int[] Numbers;
        public int Result;

    }
    public  class TestAutoDataAttribute:AutoDataAttribute
    {
    public TestAutoDataAttribute(): base(new Fixture().Customize(new Customization()))
    {

    }
    
    public class Customization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<TestInlineData>(c => 
                c.With(x => x, createData()));
        }
    }


    private static  TestInlineData createData()
        {
            var inlineData = new TestInlineData();

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
