using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WGSystem.ComponentModel.DataAnnotations;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the <see cref="WGBasicValidation"/> implementation of the model validation client interface
    /// </summary>
    public class WGBasicValidationShould : IClassFixture<IWGValidationImplementation>
    {
        /// <summary>
        /// Holds the test object
        /// </summary>
        public WGBasicValidation BasicValidation { get; set; }

        /// <summary>
        /// Construct the test suite object and inject an object that implements
        /// IWGValidationImplementation
        /// </summary>
        /// <param name="validationImplementation">The validation implementation to use for testing</param>
        public WGBasicValidationShould(IWGValidationImplementation validationImplementation)
        {
            BasicValidation = new WGBasicValidation(validationImplementation);
        }

        /// <summary>
        /// Test that a <see cref="WGBasicValidation"/> object created with null 
        /// throws an InvalidTypeException
        /// </summary>
        [Fact]
        public void ShouldThrowInvalidTypeExceptionWhenConstructedWithNull()
        {
            Assert.Throws<ArgumentException>(() => new WGBasicValidation(null));
        }

        /// <summary>
        /// Test that a <see cref="WGBasicValidation"/> object can be created
        /// </summary>
        [Fact]
        public void ShouldCreateWGBasicValidation()
        {
            Assert.NotNull(new WGBasicValidation(new WGAspNetCore2Validation()));
        }

        [Fact]
        public void ValidationShouldReturnFalseWhenPassedABadModel()
        {
            Assert.False()
        }
    }
}
