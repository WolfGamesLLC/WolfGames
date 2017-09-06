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
        public ExternalLoginViewModel LoginViewModel { get; set; }
        public WGGenericCollectionsFactory CollectionsFactory { get; set; }

        public ExterenalLoginViewModelTestSuite()
        {
            LoginViewModel = new ExternalLoginViewModel();
            CollectionsFactory = new WGGenericCollectionsFactory();
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
            LoginViewModel = new ExternalLoginViewModel() { Email = expectedEmail };
            Assert.Equal(expectedEmail, LoginViewModel.Email);
        }

        [Fact]
        public void ShouldFailValidationIfEmailIsEmpty()
        {
            LoginViewModel = new ExternalLoginViewModel();
            ValidationContext validationContext = new ValidationContext(LoginViewModel);
            IList<ValidationResult> validationResults = CollectionsFactory.CreateList<ValidationResult>();
            Assert.False(Validator.TryValidateObject(LoginViewModel, validationContext, validationResults));
            Assert.Equal(1, validationResults.Count);
            Assert.Equal("The Email field is required.", validationResults[0].ErrorMessage);
        }
    }
}
