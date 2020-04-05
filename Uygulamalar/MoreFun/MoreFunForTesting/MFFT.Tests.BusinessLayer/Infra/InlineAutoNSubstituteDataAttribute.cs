using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace MFFT.Tests.BusinessLayer.Infra
{
    public class InlineAutoNSubstituteDataAttribute : AutoFixture.Xunit2.InlineAutoDataAttribute
    {
        public InlineAutoNSubstituteDataAttribute(params object[] values) :
            base(new AutoNSubstituteDataAttribute(), values)
        {
        }


        //public InlineAutoDataAttribute(params object[] values)
        //    : this(new AutoDataAttribute(), values)
        //{
        //}


        //protected InlineAutoDataAttribute(DataAttribute autoDataAttribute, params object[] values)
        //    : base(new InlineDataAttribute(values), autoDataAttribute)
        //{
        //    this.AutoDataAttribute = autoDataAttribute;
        //    this.Values = values;
        //}



    }
}
