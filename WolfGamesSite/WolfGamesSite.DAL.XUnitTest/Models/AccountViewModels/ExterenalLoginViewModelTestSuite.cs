using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WolfGamesSite.DAL.Models.AccountViewModels;
using Xunit;
using Xunit.Abstractions;
using WGSystem.Collections.Generic;

namespace WolfGamesSite.DAL.XUnitTest.Models.AccountViewModels
{
    public class ExterenalLoginViewModelTestSuite
    {
//        private readonly ITestOutputHelper output;
        public ExternalLoginViewModel externalLoginViewModel { get; set; }
        public WGGenericCollectionsFactory wGGenericCollectionsFactory { get; set; }

        public ExterenalLoginViewModelTestSuite()
        {
            externalLoginViewModel = new ExternalLoginViewModel();
            wGGenericCollectionsFactory = new WGGenericCollectionsFactory();
        }

        [Fact]
        public void ShouldCreateAnExternalLoginViewModel()
        {
            Assert.NotNull(new ExternalLoginViewModel());
        }

        [Fact]
        public void ShouldSetEmail()
        {
            string expectedEmail = "some@email.com";
            externalLoginViewModel = new ExternalLoginViewModel() { Email = expectedEmail };
            Assert.Equal(expectedEmail, externalLoginViewModel.Email);
        }

        [Fact]
        public void ShouldFailValidationIfEmailIsEmpty()
        {
            externalLoginViewModel = new ExternalLoginViewModel();
            ValidationContext validationContext = new ValidationContext(externalLoginViewModel);
            IList<ValidationResult> validationResults = wGGenericCollectionsFactory.CreateList<ValidationResult>();
            Assert.False(Validator.TryValidateObject(externalLoginViewModel, validationContext, validationResults));
            Assert.Equal(1, validationResults.Count);
            Assert.Equal("The Email field is required.", validationResults[0].ErrorMessage);
        }
    }
}
