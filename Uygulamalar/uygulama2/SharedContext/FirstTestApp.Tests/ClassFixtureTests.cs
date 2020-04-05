using System;
using System.Collections.Generic;
using System.Text;
using FirstTestApp.Tests.Infra;
using Xunit;

namespace FirstTestApp.Tests
{

    [Trait("Category", "ClassFixture Tests")]
    public class ClassFixtureTests : IClassFixture<MyClassFixture>
    {
    MyClassFixture fixture;

    public ClassFixtureTests(MyClassFixture fixture)
    {
        this.fixture = fixture;
    }


    [Fact]
    public void AfterPushingItem_CountShouldReturnMore()
    {
        fixture.Persons.Add(new Person{Fullname = "Murat Çabuk"});

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
