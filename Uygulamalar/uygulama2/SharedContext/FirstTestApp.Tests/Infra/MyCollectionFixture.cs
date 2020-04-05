using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FirstTestApp.Tests.Infra
{
    [CollectionDefinition("Collection Tests")]
    public class MyCollectionFixture : ICollectionFixture<MyClassFixture>
    {
      

    }
}
