using System;
using System.Collections.Generic;
using System.Text;
using GenFu;
using GenFu.ValueGenerators.Internet;

namespace BusinessLayer.Tests.Infra
{
    public class WebAddressFiller : PropertyFiller<string>
    {
        public WebAddressFiller()
            : base(
                new[] { "object" },
                new[] { "website", "web", "webaddress" })
        {
        }

        public override object GetValue(object instance)
        {
            var domain = Domains.DomainName();

            return $"https://www.{domain}";
        }
    }
}
