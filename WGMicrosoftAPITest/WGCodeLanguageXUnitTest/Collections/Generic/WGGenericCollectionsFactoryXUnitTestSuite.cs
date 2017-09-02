using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WGSystem.Collections.Generic;
using System.Collections;

namespace WGSystemXUnitTest.Collections.Generic
{
    public class WGGenericCollectionsFactoryXUnitTestSuite
    {
        [Fact]
        public void ShouldCreateWGGenericCollectionsFactory()
        {
            Assert.NotNull(new WGGenericCollectionsFactory());
        }

        [Fact]
        public void ShouldCreateIListObject()
        {
            Assert.IsAssignableFrom<IList<int>>(new WGGenericCollectionsFactory().CreateList<int>());
        }
    }
}
