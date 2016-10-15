using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class MainMenuControllerTests
    {
        MockMenuController testMenu = new MockMenuController();
        MainMenuController testMainMenuController = new MainMenuController();
        PrivateObject pObject;

        [TestInitialize()]
        public void SetControllers()
        {
            testMainMenuController.SetScoreController(testMenu);
            pObject = new PrivateObject(testMainMenuController);
        }

        [TestMethod()]
        public void SetScoreTextTest()
        {
            int expectedScore = 1;

            testMainMenuController.SetScoreText(expectedScore);
            Assert.AreEqual(expectedScore, testMenu.Score);
        }
    }
}