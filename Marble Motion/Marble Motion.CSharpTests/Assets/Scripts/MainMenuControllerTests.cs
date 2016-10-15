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
        MockMenuController mockMenuController = new MockMenuController();
        MainMenuController testMainMenuController = new MainMenuController();
        PrivateObject pObject;

        [TestMethod()]
        public void SetGameControllerTest()
        {
            testMainMenuController.SetGameController(mockMenuController);
            pObject = new PrivateObject(testMainMenuController);
            Assert.AreSame(mockMenuController, pObject.GetFieldOrProperty("gameController"));
        }
    }
}