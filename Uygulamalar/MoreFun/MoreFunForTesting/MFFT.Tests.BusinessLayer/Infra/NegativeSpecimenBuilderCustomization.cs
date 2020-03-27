using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;

namespace MFFT.Tests.BusinessLayer.Infra
{
   public class NegativeSpecimenBuilderCustomization : ICustomization{
        private NegativeRequest _negativeRequest;
        //public NegativeSpecimenBuilderCustomization(NegativeRequest negativeRequest)
        //{

        //    _negativeRequest = negativeRequest;

        //}

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new NegativeSpecimenBuilder());
        }
    }
}
