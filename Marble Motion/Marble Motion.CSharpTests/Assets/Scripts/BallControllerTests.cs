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
        PrivateObject pObject;
        float expectedSpeed;

        #region Helper functions

        private float GetBallControllerScoreModifier()
        {
            return Convert.ToSingle(pObject.GetFieldOrProperty("scoreModifier"));
        }

        private float GetBallControllerSpeed()
        {
            return Convert.ToSingle(pObject.GetFieldOrProperty("speed"));
        }

        #endregion

        [TestInitialize()]
        public void SetControllers()
        {
            testBallController.SetMovementController(testPlayer);
            testBallController.SetScoreController(testPlayer);

            pObject = new PrivateObject(testBallController);
            expectedSpeed = GetBallControllerSpeed();
        }

        [TestMethod()]
        public void MoveTest()
        {
            Vector3 appliedForce = new Vector3(1, 0, 1) * GetBallControllerSpeed();

            testBallController.Move(1, 1);

            Assert.AreEqual(appliedForce, testPlayer.Force);
        }

        [TestMethod()]
        public void SetScoreTest()
        {
            float expectedScore = GetBallControllerSpeed() *
                                    GetBallControllerScoreModifier();

            testBallController.SetScore();

            Assert.AreEqual(expectedScore, testPlayer.Score);
            Assert.AreEqual(expectedScore.ToString(), testPlayer.ScoreText);
        }

        [TestMethod()]
        public void SetSpeedNoInputTest()
        {
            testBallController.SetSpeed(0, 0);
            Assert.AreEqual(BallController.MIN_SPEED, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void SetSpeedHorizontalInputTest()
        {
            testBallController.SetSpeed(0.1f, 0);
            Assert.AreEqual(expectedSpeed + 1, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void SetSpeedVerticalInputTest()
        {
            testBallController.SetSpeed(0, 0.1f);
            Assert.AreEqual(expectedSpeed + 1, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void SetSpeedBothAxisInputTest()
        {
            testBallController.SetSpeed(0.1f, 0.1f);
            Assert.AreEqual(expectedSpeed + 1, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void ReduceSpeedAtMinValue()
        {
            expectedSpeed = BallController.MIN_SPEED;
            pObject.SetFieldOrProperty("speed", expectedSpeed);

            testBallController.SetSpeed(0, 0);
            Assert.AreEqual(expectedSpeed, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void IncreaseSpeedAtMaxValue()
        {
            expectedSpeed = BallController.MAX_SPEED;
            pObject.SetFieldOrProperty("speed", expectedSpeed);

            testBallController.SetSpeed(0.1f, 0);
            Assert.AreEqual(expectedSpeed, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void BallControllerTest()
        {
            Assert.AreEqual(BallController.MIN_SPEED, GetBallControllerSpeed());
        }
    }
}