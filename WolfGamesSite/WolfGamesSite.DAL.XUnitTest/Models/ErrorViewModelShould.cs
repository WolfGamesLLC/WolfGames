﻿using System;
using System.Collections.Generic;
using System.Text;
using WolfGamesSite.DAL.Models;
using Xunit;

namespace WolfGamesSite.DAL.XUnitTest.Models
{
    public class ErrorViewModelShould
    {
        public ErrorViewModel errorViewModel { get; set; }

        public ErrorViewModelShould()
        {
            errorViewModel = new ErrorViewModel();
        }

        [Fact]
        public void ShouldCreateAnErrorViewModel()
        {
            Assert.NotNull(new ErrorViewModel());
        }

        [Fact]
        public void ShouldSetRequestId()
        {
            string expected = "RequestId";
            errorViewModel.RequestId = expected;
            Assert.Equal(expected, errorViewModel.RequestId );
        }

        [Fact]
        public void ShowRequestIdShouldBeFalseWhenRequestIdIsNull()
        {
            Assert.False(errorViewModel.ShowRequestId);
        }

        [Fact]
        public void ShowRequestIdShouldBeFalseWhenRequestIdIsEmpty()
        {
            errorViewModel.RequestId = "";
            Assert.False(errorViewModel.ShowRequestId);
        }

        [Fact]
        public void ShowRequestIdShouldBeTrueWhenRequestIdIsSpace()
        {
            errorViewModel.RequestId = " ";
            Assert.True(errorViewModel.ShowRequestId);
        }

        [Fact]
        public void ShowRequestIdShouldBeTrueWhenRequestIdIsA()
        {
            errorViewModel.RequestId = "a";
            Assert.True(errorViewModel.ShowRequestId);
        }
    }
}