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
            Assert.False(TryValidateObject(LoginViewModel));
            IList<ValidationResult> validationResults = GetResults();
            Assert.Equal(1, validationResults.Count);
            Assert.Equal("The Email field is required.", validationResults[0].ErrorMessage);
        }

        private bool TryValidateObject(Object loginViewModel)
        {
            ValidationContext validationContext = new ValidationContext(loginViewModel);
            IList<ValidationResult> validationResults = CollectionsFactory.CreateList<ValidationResult>();
            return Validator.TryValidateObject(loginViewModel, validationContext, validationResults));
        }

        private IList<ValidationResult> GetResults()
        {
            return validationResults;
        }
    }
}
