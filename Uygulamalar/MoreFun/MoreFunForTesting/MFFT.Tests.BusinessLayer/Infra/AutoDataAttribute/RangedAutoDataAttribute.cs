using System.Collections.Generic;
using System.Reflection;
using AutoFixture;

namespace MFFT.Tests.BusinessLayer.Infra.AutoDataAttribute
{
   public class RangedAutoDataAttribute : AutoFixture.Xunit2.AutoDataAttribute
    {

        private static RangedRequest _rangedRequest;
        //public NegativeAutoDataAttribute(int count, int min, int max)
        //{
        //    _rangedRequest=new RangedRequest
        //    {
        //        Count = count,
        //        Min=min,
        //        Max = max

        //    };
        //}

        public RangedAutoDataAttribute()
            : base(new Fixture()
                .Customize(new RangedSpecimenBuilderCustomization()))
        {


        }

        //public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        //{
        //    return base.GetData(testMethod);
        //}
    }

}
