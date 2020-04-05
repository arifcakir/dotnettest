using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FirstTestApp.Tests
{
    [Trait("Category", "Constructure Dispose Tests")]
    public class ConstructureDisposeTests : IDisposable
    {
        //Constructor and Dispose

        List<int> list;

        public ConstructureDisposeTests()
        {
            list = new List<int>();
        }

        public void Dispose()
        {
            list.Clear();
        }


        [Fact]
        public void WithNoItems_CountShouldReturnZero()
        {
            var count = list.Count;

            Assert.Equal(0, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnOne()
        {
            list.Add(42);

            var count = list.Count;

            Assert.Equal(1, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnOneAgain()
        {
            list.Add(42);

            var count = list.Count;

            Assert.Equal(1, count);
        }

    }
}
