using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using FirstTestApp.Tests.Infra;
using Xunit;
using Xunit.Abstractions;

namespace FirstTestApp.Tests
{

    [Trait("Category", "Collection Tests")]
    [Collection("Collection Tests")]
    public class CollectionFixtureTests2
    {



        MyClassFixture fixture;

        public CollectionFixtureTests2(MyClassFixture fixture)
        {
            this.fixture = fixture;
        }





        [Fact]
        public void AfterPushingItem_CountShouldReturnMore()
        {
            fixture.Persons.Add(new Person { Fullname = "Murat Çabuk" });

            var count = fixture.Persons.Count;

            Assert.Equal(count, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnMoreAgain()
        {
            fixture.Persons.Add(new Person { Fullname = "Murat Çabuk" });

            var count = fixture.Persons.Count;

            Assert.Equal(count, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnMoreAgainAgain()
        {
            fixture.Persons.Add(new Person { Fullname = "Murat Çabuk" });

            var count = fixture.Persons.Count;

            Assert.Equal(count, count);
        }



    }
}
