using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class GameTests
    {
        Game testGame;
        PrivateObject pObject;

        #region Helper methods

        private int GetGameScore()
        {
            return (int)pObject.GetFieldOrProperty("score");
        }

        private Object GetMainMenu()
        {
            return pObject.GetFieldOrProperty("mainMenu");
        }

        private Object GetPlayer()
        {
            return pObject.GetFieldOrProperty("player");
        }

        #endregion

        [TestInitialize]
        public void InitializeGame()
        {
            testGame = new Game(new MainMenuController(), new BallController());
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
            testGame.StartGame();
            Assert.AreEqual(0, GetGameScore());
        }
    }
}