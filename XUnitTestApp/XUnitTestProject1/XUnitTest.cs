using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;
using Moq;

namespace XUnitTestSuite
{
    /// <summary>
    /// The <see cref="XUnitTestSuite"/> namespace contains classes for 
    /// testing the XUnit NuGet package
    /// </summary>

    [System.Runtime.CompilerServices.CompilerGenerated]
    public class NamespaceDoc
    {
    }

    /// <summary>
    /// Class used to test DI of a test fixture
    /// </summary>
    public class Fixture
    {
        /// <summary>
        /// Method used to test DI of a test fixture
        /// </summary>
        public void Method()
        {
            Assert.True(true);
        }
    }

    /// <summary>
    /// Tests that XUnit functions as expected and provides examples of use
    /// </summary>
    public class XUnitTestShould : IClassFixture<Fixture>, IDisposable
    {
        /// <summary>
        /// Required to output to the console from a test
        /// </summary>
        private readonly ITestOutputHelper output;

        /// <summary>
        /// The constructor runs before every test
        /// </summary>
        /// <param name="fixture">Allows custom fixtures to be inserted to each test</param>
        /// <param name="testOutputHelper">Required to write output to the console from tests</param>
        public XUnitTestShould(Fixture fixture, ITestOutputHelper testOutputHelper)
        {
            Assert.True(true);
            fixture.Method();
            output = testOutputHelper;
            output.WriteLine("Constructing XUnitTest object");
        }

        /// <summary>
        /// Run after every test
        /// </summary>
        public void Dispose()
        {
            Assert.True(true);
            output.WriteLine("Destroying XUnitTest object");
        }

        /// <summary>
        /// Test Assert.True and writing to the console from a test
        /// </summary>
        [Fact]
        public void BeTrue()
        {
            Assert.True(true);
            output.WriteLine("Running ShouldBeTrue test");
        }

        /// <summary>
        /// Test Assert.False
        /// </summary>
        [Fact]
        public void Befalse()
        {
            Assert.False(false);
            output.WriteLine("Running ShouldBeFalse test");
        }

        /// <summary>
        /// Test Assert.DoesNotContain
        /// </summary>
        [Fact]
        public void NotContainHi()
        {
            Assert.DoesNotContain("Hi", "Hello");
        }

        /// <summary>
        /// Test Assert.DoesNotContain
        /// </summary>
        [Fact]
        public void NotContaing()
        {
            Assert.DoesNotContain("g", "Hello");
        }

        /// <summary>
        /// Test Assert.DoesNotContain
        /// </summary>
        [Fact]
        public void NotContainp()
        {
            Assert.DoesNotContain("p", "Hello");
        }

        /// <summary>
        /// Test Assert.Contains
        /// </summary>
        [Fact]
        public void ContainEmptyString()
        {
            Assert.Contains("", " ");
        }

        /// <summary>
        /// Test Assert.DoesNotContain
        /// </summary>
        [Fact]
        public void NotContainSpace()
        {
            Assert.DoesNotContain(" ", "A");
        }

        /// <summary>
        /// Test Assert.DoesNotContain
        /// </summary>
        [Fact]
        public void NotContainValue()
        {
            List<int> list = new List<int>() { 5, 6, 7 };
            Assert.DoesNotContain<int>(1, list);
        }

        /// <summary>
        /// Test Assert.DoesNotContain
        /// </summary>
        [Fact]
        public void NotContainList()
        {
            List<List<int>> list = new List<List<int>>() { new List<int>() { 1, 2, 3 }, new List<int> { 4, 5, 6} };
            List<int> expected = new List<int>() { 5, 6, 7 };
            Assert.DoesNotContain<List<int>>(expected, list);
        }

        /// <summary>
        /// Test Assert.Contains
        /// </summary>
        [Fact]
        public void Containll()
        {
            Assert.Contains("ll", "Hello");
        }

        /// <summary>
        /// Test Assert.Contains
        /// </summary>
        [Fact]
        public void ContainValue()
        {
            List<int> list = new List<int>() { 5, 6, 7 };
            Assert.Contains<int>(5, list);
        }

        /// <summary>
        /// Test Assert.Contains
        /// </summary>
        [Fact]
        public void ContainList()
        {
            List<List<int>> list = new List<List<int>>() { new List<int>() { 1, 2, 3 }, new List<int> { 4, 5, 6 } };
            List<int> expected = new List<int>() { 4, 5, 6 };
            Assert.Contains<List<int>>(expected, list);
        }

        /// <summary>
        /// Test Assert.Empty
        /// </summary>
        [Fact]
        public void BeEmpty()
        {
            Assert.Empty(new List<int>());
        }

        /// <summary>
        /// Test Assert.NotEmpty
        /// </summary>
        [Fact]
        public void NotBeEmpty()
        {
            Assert.NotEmpty(new List<int>() { 1 });
        }

        /// <summary>
        /// Test Assert.Equal
        /// </summary>
        [Fact]
        public void EqualString()
        {
            Assert.Equal("A", "A");
        }

        /// <summary>
        /// Test Assert.Equal
        /// </summary>
        [Fact]
        public void EqualChar()
        {
            Assert.Equal('A', 'A');
        }

        /// <summary>
        /// Test Assert.Equal
        /// </summary>
        [Fact]
        public void EqualInt()
        {
            Assert.Equal(1, 1);
        }

        /// <summary>
        /// Test Assert.Equal
        /// </summary>
        [Fact]
        public void EqualLong()
        {
            Assert.Equal(1L, 1L);
        }

        /// <summary>
        /// Test Assert.Equal
        /// </summary>
        [Fact]
        public void EqualDoubleToPrecision3()
        {
            Assert.Equal(1.11111, 1.11112, 3);
        }

        /// <summary>
        /// Test Assert.Equal
        /// </summary>
        [Fact]
        public void NotEqualDoubleToPrecision6()
        {
            Assert.NotEqual(1.11111, 1.11112, 6);
        }


        /// <summary>
        /// Test a theory
        /// </summary>
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
//        [InlineData(6)]
        public void CheckValueIsOdd(int value)
        {
            Assert.True(IsOdd(value));
        }

        /// <summary>
        /// Function used to test a theory
        /// </summary>
        /// <param name="value">any int value</param>
        /// <returns>true if the passed value is odd</returns>
        private bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        /// <summary>
        /// Test exception handling test
        /// </summary>
        [Fact]
        public void ThrowNotImplementedException()
        {
            Exception ex = Assert.Throws<NotImplementedException>(() => NotImplementedException());
            output.WriteLine(ex.Message);
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        /// <summary>
        /// Funtion used to throw an exception for exception handling test
        /// </summary>
        private void NotImplementedException()
        {
            throw new NotImplementedException();
        }

        // https://xunit.github.io/#documentation
        // Other asserts
        // InRange
        // IsNotType and IsNotType
        // IsType
        // NotInRange
        // NotNull
        // NotSame
        // Null
        // Same
        // Throws and Throws

    }
}
