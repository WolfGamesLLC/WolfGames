using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests
{
    [TestClass()]
    public class BallControllerTests
    {
        MockPlayerController testPlayer = new MockPlayerController();
        BallController testBallController = new BallController();

        [TestMethod()]
        public void MoveTest()
        {
            testBallController.SetMovementController(testPlayer);
            testBallController.SetScoreController(testPlayer);

            Vector3 appliedForce = new Vector3(10, 0 , 10);

            testBallController.Move(1, 1);
            Assert.AreEqual(appliedForce, testPlayer.Force);
        }
        
        [TestMethod()]
        public void SetScoreTest()
        {
            float score = 1.0f;
            testBallController.SetMovementController(testPlayer);
            testBallController.SetScoreController(testPlayer);

            testBallController.SetScore();
            Assert.AreEqual(score, testPlayer.Score);
            Assert.AreEqual(score.ToString(), testPlayer.ScoreText);
        }

        [TestMethod()]
        public void SetMovementControllerTest()
        {
            testBallController.SetMovementController(testPlayer);

            PrivateObject pObject = new PrivateObject(testBallController);
            Assert.AreSame(testPlayer, pObject.GetFieldOrProperty("movementController"));
        }

        [TestMethod()]
        public void SetScoreControllerTest()
        {
            testBallController.SetScoreController(testPlayer);

            PrivateObject pObject = new PrivateObject(testBallController);
            Assert.AreSame(testPlayer, pObject.GetFieldOrProperty("scoreController"));
        }
    }
}