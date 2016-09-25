using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class BallControllerTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            Assert.Fail();
        }
        
        [TestMethod()]
        public void SetScoreTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetMovementControllerTest()
        {
            MockPlayerController testPlayer = new MockPlayerController();
            BallController testBallController = new BallController();

            testBallController.SetMovementController(testPlayer);

            PrivateObject pObject = new PrivateObject(testBallController);
            Assert.AreSame(testPlayer, pObject.GetFieldOrProperty("movementController"));
        }

        [TestMethod()]
        public void SetScoreControllerTest()
        {
            MockPlayerController testPlayer = new MockPlayerController();
            BallController testBallController = new BallController();

            testBallController.SetScoreController(testPlayer);

            PrivateObject pObject = new PrivateObject(testBallController);
            Assert.AreSame(testPlayer, pObject.GetFieldOrProperty("scoreController"));
        }

        private IMovementController GetMovementMock()
        {
            return new MockPlayerController();
        }
    }
}