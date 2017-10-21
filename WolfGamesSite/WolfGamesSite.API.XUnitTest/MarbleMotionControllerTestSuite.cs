using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WolfGamesSite.API.Controllers;
using WolfGamesSite.DAL.Data;
using WolfGamesSite.DAL.Models.SimpleGameModels;
using Xunit;

namespace WolfGamesSite.API.XUnitTest
{
    /// <summary>
    /// Test suite for the Marble Motion API controller
    /// </summary>
    public class MarbleMotionControllerShould
    {
        private string MARBLE_MOTION_TEST_DB = "MarbleMotionTestDB";
        MarbleMotionController _controller;
        MarbleMotionDBContext _context;

        /// <summary>
        /// The test initializer for the suite
        /// </summary>
        public MarbleMotionControllerShould()
        {
            var options = new DbContextOptionsBuilder<MarbleMotionDBContext>();
            options.UseInMemoryDatabase(MARBLE_MOTION_TEST_DB);

            _context = new MarbleMotionDBContext(options.Options);

            _controller = new MarbleMotionController(_context);

            if (_context.MarbleMotionRecords.Count() == 0)
            {
                _context.MarbleMotionRecords.Add(new MarbleMotion { Score = 1 });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// The get action should return a list
        /// </summary>
        [Fact]
        public void GetReturnsMarbleMotionList()
        {
            Assert.IsType<List<MarbleMotion>>(_controller.Get());
        }

        /// <summary>
        /// The get action should return a NotFoundResult
        /// </summary>
        [Fact]
        public void GetReturnsNotFoundWhenNonIdRequested()
        {
            Assert.IsType<NotFoundResult>(_controller.Get(5));
        }

        /// <summary>
        /// The get action should return an IActionResult
        /// </summary>
        [Fact]
        public void GetReturnsMarbleMotionIdRequested()
        {
            Assert.IsType<ObjectResult>(_controller.Get(1));
        }

        /// <summary>
        /// The post action should create a MarbleMotion record
        /// </summary>
        [Fact]
        public void PostCreatesMarbleMotionRecord()
        {
            var newMarble = new MarbleMotion { Id = 2, Score = 10, XPosition = 20, ZPosition = 30 };
            _controller.Create(newMarble);
            Assert.True(_context.MarbleMotionRecords.Any(x => x == newMarble));
        }
    }
}
