using System.Collections.Generic;
using System.Web.Mvc;
using BowlingGameV2.Controllers;
using BowlingGameV2.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameV2.Tests.Controllers
{
    [TestClass]
    public class GameScoreControllerTest
    {
        [TestMethod]
        public void Real_Example_Through_Web()
        {
            GameScoreController controller = new GameScoreController();
            var data = new List<FrameViewModel>
            {
                new FrameViewModel {First = 5, Second = 3},
                new FrameViewModel {First = 3, Second = 4},
                new FrameViewModel {First = 8, Second = 2},
                new FrameViewModel {First = 1, Second = 1},
                new FrameViewModel {First = 10, Second = 0},
                new FrameViewModel {First = 2, Second = 4},
                new FrameViewModel {First = 5, Second = 4},
                new FrameViewModel {First = 3, Second = 6},
                new FrameViewModel {First = 2, Second = 6}
            };
            JsonResult result = controller.Frames(data);
            Assert.AreEqual("{ score = 76 }", result.Data.ToString());
        }

        [TestMethod]
        public void Real_Example_Through_Web2()
        {
            GameScoreController controller = new GameScoreController();
            var data = new List<FrameViewModel>
            {
                new FrameViewModel {First = 5, Second = 3},
                new FrameViewModel {First = 3, Second = 4},
                new FrameViewModel {First = 8, Second = 2},
                new FrameViewModel {First = 1, Second = 1},
                new FrameViewModel {First = 10, Second = 0},
                new FrameViewModel {First = 2, Second = 4},
                new FrameViewModel {First = 5, Second = 4},
                new FrameViewModel {First = 3, Second = 6},
                new FrameViewModel {First = 2, Second = 6},
                new FrameViewModel {First = 10, Second = 2, Third = 2}
            };
            JsonResult result = controller.Frames(data);
            Assert.AreEqual("{ score = 90 }", result.Data.ToString());
        }
    }
}
