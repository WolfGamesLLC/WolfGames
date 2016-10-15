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
            testMainMenuController.SetGameController(testMenu);

            pObject = new PrivateObject(testMainMenuController);
        }

        [TestMethod()]
        public void StartGameTest()
        {
            testMainMenuController.StartGame();
            Assert.Fail();
        }
    }
}