using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WGSystem.ComponentModel.DataAnnotations;
using Moq;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the <see cref="WGBasicValidation"/> implementation of the model validation client interface
    /// </summary>
    public class WGBasicValidationShould
    {
        /// <summary>
        /// Holds the test object
        /// </summary>
        public WGBasicValidation BasicValidation { get; set; }

        /// <summary>
        /// Construct the test suite object and inject a mock object that implements
        /// IWGValidationImplementation
        /// </summary>
        public WGBasicValidationShould()
        {
            var mock = new Mock<IWGValidationImplementation>();
            BasicValidation = new WGBasicValidation(mock.Object);
        }

        /// <summary>
        /// Test that a <see cref="WGBasicValidation"/> object created with null 
        /// throws an InvalidTypeException
        /// </summary>
        [Fact]
        public void ThrowInvalidTypeExceptionWhenConstructedWithNull()
        {
            Assert.Throws<ArgumentException>(() => new WGBasicValidation(null));
        }

        /// <summary>
        /// Test that a <see cref="WGBasicValidation"/> object can be created
        /// </summary>
        [Fact]
        public void CreateWhenPassedAnIWGValidationImplementationObject()
        {
            Assert.NotNull(new WGBasicValidation(new WGAspNetCore2Validation()));
        }

        /// <summary>
        /// Test that ArgumentNullException is thrown when validation is attempted on a null object
        /// </summary>
        [Fact]
        public void ReturnFalseWhenPassedNull()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() => BasicValidation.TryValidateObject(null));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }
    }
}
