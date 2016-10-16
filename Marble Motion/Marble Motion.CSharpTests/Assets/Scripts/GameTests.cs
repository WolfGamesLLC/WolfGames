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
        public void UpdateTest()
        {
            testGame.Update();
            Assert.AreEqual(1L, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }
    }
}