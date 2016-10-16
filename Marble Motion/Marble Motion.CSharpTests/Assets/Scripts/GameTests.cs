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

        private long GetGameScore()
        {
            return (long)pObject.GetFieldOrProperty("score");
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
            MainMenuController menu = new MainMenuController();
            menu.SetScoreController(new MockMenuController());
            testGame = new Game(menu, new BallController());
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
        }

        [TestMethod()]
        public void UpdateTest()
        {
            testGame.Update();
            Assert.AreEqual(1l, pObject.GetFieldOrProperty("score"));
        }
    }
}