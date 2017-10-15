using System;
using System.Collections.Generic;
using System.Text;
using WolfGamesSite.DAL.Models.SimpleGameModels;
using Xunit;

namespace WolfGamesSite.DAL.XUnitTest.Models.SimpleGameModels
{
    /// <summary>
    /// Test suite for the Marble Motion base table
    /// </summary>
    public class MarbleMotionShould
    {
        /// <summary>
        /// Standard object under test
        /// </summary>
        public MarbleMotion marbleMotion { get; set; }

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public MarbleMotionShould()
        {
            marbleMotion = new MarbleMotion();
        }

        /// <summary>
        /// Verify the model can be created
        /// </summary>
        [Fact]
        public void ShouldCreateAMarbleMotionModel()
        {
            Assert.NotNull(new MarbleMotion());
        }

        /// <summary>
        /// The id should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetId()
        {
            long expected = 12345;
            marbleMotion.Id = expected;
            Assert.Equal(expected, marbleMotion.Id);
        }

        /// <summary>
        /// The score should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetScore()
        {
            long expected = 12345;
            marbleMotion.Score = expected;
            Assert.Equal(expected, marbleMotion.Score);
        }

        /// <summary>
        /// The X position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetXPosition()
        {
            int expected = 12345;
            marbleMotion.XPosition = expected;
            Assert.Equal(expected, marbleMotion.XPosition);
        }

        /// <summary>
        /// The Y position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetYPosition()
        {
            int expected = 12345;
            marbleMotion.ZPosition = expected;
            Assert.Equal(expected, marbleMotion.ZPosition);
        }
    }
}
