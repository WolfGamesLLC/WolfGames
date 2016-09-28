﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize()]
        public void SetControllers()
        {
            testBallController.SetMovementController(testPlayer);
            testBallController.SetScoreController(testPlayer);

            pObject = new PrivateObject(testBallController);
            expectedSpeed = Convert.ToSingle(pObject.GetFieldOrProperty("speed"));
        }

        [TestMethod()]
        public void MoveTest()
        {
            Vector3 appliedForce = new Vector3(10, 0 , 10);

            testBallController.Move(1, 1);
            Assert.AreEqual(appliedForce, testPlayer.Force);
        }
        
        [TestMethod()]
        public void SetScoreTest()
        {
            float expectedScore = Convert.ToSingle(pObject.GetFieldOrProperty("speed")) *
                                    Convert.ToSingle(pObject.GetFieldOrProperty("scoreModifier"));

            testBallController.SetScore();

            Assert.AreEqual(expectedScore, testPlayer.Score);
            Assert.AreEqual(expectedScore.ToString(), testPlayer.ScoreText);
        }

        [TestMethod()]
        public void SetSpeedNoInputTest()
        {
            testBallController.SetSpeed(0, 0);
            Assert.AreEqual(expectedSpeed - 1, Convert.ToSingle(pObject.GetFieldOrProperty("speed")));
        }

        [TestMethod()]
        public void SetSpeedHorizontalInputTest()
        {
            testBallController.SetSpeed(0.1f, 0);
            Assert.AreEqual(expectedSpeed + 1, Convert.ToSingle(pObject.GetFieldOrProperty("speed")));
        }

        [TestMethod()]
        public void SetSpeedVerticalInputTest()
        {
            testBallController.SetSpeed(0, 0.1f);
            Assert.AreEqual(expectedSpeed + 1, Convert.ToSingle(pObject.GetFieldOrProperty("speed")));
        }

        [TestMethod()]
        public void SetSpeedBothAxisInputTest()
        {
            testBallController.SetSpeed(0.1f, 0.1f);
            Assert.AreEqual(expectedSpeed + 1, Convert.ToSingle(pObject.GetFieldOrProperty("speed")));
        }

        [TestMethod()]
        public void ReduceSpeedAtMinValue()
        {
            expectedSpeed = 1.0f;
            pObject.SetFieldOrProperty("speed", expectedSpeed);

            testBallController.SetSpeed(0, 0);
            Assert.AreEqual(expectedSpeed, Convert.ToSingle(pObject.GetFieldOrProperty("speed")));
        }

        [TestMethod()]
        public void IncreaseSpeedAtMaxValue()
        {
            expectedSpeed = 10.0f;
            pObject.SetFieldOrProperty("speed", expectedSpeed);

            testBallController.SetSpeed(0, 0);
            Assert.AreEqual(expectedSpeed, Convert.ToSingle(pObject.GetFieldOrProperty("speed")));
        }
    }
}