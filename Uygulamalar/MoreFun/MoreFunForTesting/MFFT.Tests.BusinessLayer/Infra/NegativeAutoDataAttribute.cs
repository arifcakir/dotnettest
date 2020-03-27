using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.Xunit2;

namespace MFFT.Tests.BusinessLayer.Infra
{
   public class NegativeAutoDataAttribute : AutoDataAttribute
    {

        private static NegativeRequest _negativeRequest;
        //public NegativeAutoDataAttribute(int count, int min, int max)
        //{
        //    _negativeRequest=new NegativeRequest
        //    {
        //        Count = count,
        //        Min=min,
        //        Max = max

        //    };
        //}

        public NegativeAutoDataAttribute()
            : base(new Fixture()
                .Customize(new NegativeSpecimenBuilderCustomization()))
        {


        }




    }

}
