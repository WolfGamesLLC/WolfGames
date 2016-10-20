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
    public class GameTests
    {
        Game testGame;
        PrivateObject pObject;

        #region Helper methods

        private long GetGameScore()
        {
            return (long)pObject.GetFieldOrProperty("score");
        }

        private Vector3 GetPlayerPreviousPosition()
        {
            return (Vector3)pObject.GetFieldOrProperty("playerPreviousPosition");
        }

        private System.Object GetMainMenu()
        {
            return pObject.GetFieldOrProperty("mainMenu");
        }

        private System.Object GetPlayer()
        {
            return pObject.GetFieldOrProperty("player");
        }

        private void SetPlayerPreviousPosition(Vector3 position)
        {
            pObject.SetFieldOrProperty("playerPreviousPosition", position);
        }

        #endregion

        [TestInitialize]
        public void InitializeGame()
        {
            MainMenuController menu = new MainMenuController();
            menu.SetScoreController(new MockMenuController());

            BallController ball = new BallController();
            ball.SetMovementController(new MockPlayerController());

            testGame = new Game(menu, ball);
            pObject = new PrivateObject(testGame);
        }

        [TestMethod()]
        public void GameTest()
        {
            Assert.IsInstanceOfType(GetMainMenu(), typeof(MainMenuController));
            Assert.IsInstanceOfType(GetPlayer(), typeof(BallController));
        }

        [TestMethod()]
        public void StartGameTest()
        {
            testGame.Start();
            Assert.AreEqual(0, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }

        [TestMethod()]
        public void NoMotionUpdateTest()
        {
            // players current position is Vector3.One
            SetPlayerPreviousPosition(Vector3.one);
            Assert.AreEqual(0L, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }

        [TestMethod()]
        public void NegativeMotionUpdateTest()
        {
            // players current position is Vector3.One
            SetPlayerPreviousPosition(new Vector3(1.9f, 1.9f, 1.9f));
            testGame.Update();
            Assert.AreEqual(18L, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }

        [TestMethod()]
        public void PositiveMotionUpdateTest()
        {
            // players current position is Vector3.One
            SetPlayerPreviousPosition(new Vector3(0.1f, 0.1f, 0.1f));
            testGame.Update();
            Assert.AreEqual(18L, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }
    }
}