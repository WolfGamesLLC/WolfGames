using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

/// <summary>
/// Contains all the interfaces and classes needed to verify Moq
/// </summary>
namespace MockTestSuite
{
    /// <summary>
    /// Basic Moq tests
    /// </summary>
    public class MockShould
    {
        /// <summary>
        /// Interfaces mocked in all tests
        /// </summary>
        public interface TestMock
        {
            /// <summary>
            /// Associated class to mock
            /// </summary>
            TestClass Class { get; set; }

            /// <summary>
            /// Property mocked during testing
            /// </summary>
            int TestProperty { get; set; }

            /// <summary>
            /// Function mocked during testing
            /// </summary>
            /// <returns>an integer</returns>
            int TestReturn();
        }

        /// <summary>
        /// Class associated with the interface during testing
        /// </summary>
        public class TestClass
        {
            /// <summary>
            /// Class associated with the base class for testing hierarchy mocking
            /// </summary>
            public virtual TestAssociatedClass AssociatedClass { get; set; }

            /// <summary>
            /// Used for testing hierarchy mocking of functions
            /// </summary>
            /// <returns>false</returns>
            public virtual bool Submit() { return false; }
        }

        /// <summary>
        /// An associated class of a class for hierarchy mocking
        /// </summary>
        public class TestAssociatedClass
        {
            /// <summary>
            /// Used for testing hierarchy mocking of properties
            /// </summary>
            /// <returns>an integer</returns>
            public virtual int TestProperty { get; set; }
        }

        /// <summary>
        /// Test that moq will set a functions return value
        /// </summary>
        [Fact]
        public void SetFunctionToReturn5()
        {
            var mock = new Mock<TestMock>();
            mock.Setup(testMock => testMock.TestReturn())
                .Returns(5);

            Assert.Equal(5, mock.Object.TestReturn());
        }

        /// <summary>
        /// Test that moq will set a properties return value
        /// </summary>
        [Fact]
        public void SetPropertyToReturn5()
        {
            var mock = new Mock<TestMock>();
            mock.Setup(testMock => testMock.TestProperty).Returns(5);

            Assert.Equal(5, mock.Object.TestProperty);
        }

        /// <summary>
        /// Test that moq will set the return value of a base object's property
        /// </summary>
        [Fact]
        public void SetAssociatedClassPropertyToReturn5()
        {
            var mock = new Mock<TestMock>();
            mock.Setup(testMock => testMock.Class.AssociatedClass.TestProperty).Returns(5);

            Assert.Equal(5, mock.Object.Class.AssociatedClass.TestProperty);
        }

        /// <summary>
        /// Test that Moq will initialize a properties value
        /// </summary>
        [Fact]
        public void InitializePropertyTo5()
        {
            var mock = new Mock<TestMock>();
            mock.SetupSet(testMock => testMock.TestProperty = 5);

            Assert.Equal(5, mock.Object.TestProperty);
        }
    }
}
