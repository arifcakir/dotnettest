using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using MFFT.DataLayer;
using NSubstitute;

namespace MFFT.Tests.BusinessLayer.Infra
{
    public class AutoNSubstituteDataAttribute : AutoFixture.Xunit2.AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute() :
            base(() =>
            {
                var fixture= new Fixture();

                fixture.Customize(new AutoNSubstituteCustomization());

                var t = Substitute.For<IMathRepository>();
                t.GetIntMax().Returns(Int32.MaxValue);
                t.GetIntMin().Returns(int.MinValue);

                fixture.Register(() => t);
                return fixture;

            })
        {
        }
    }
}
