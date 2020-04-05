using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;

namespace MFFT.Tests.BusinessLayer.Infra.AutoDataAttribute
{
    public class RangedSpecimenBuilderCustomization : ICustomization{
        private RangedRequest _rangedRequest;
        //public NegativeSpecimenBuilderCustomization(RangedRequest rangedRequest)
        //{

        //    _rangedRequest = negativeRequest;

        //}

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new RangedSpecimenBuilder());
        }
    }
}
