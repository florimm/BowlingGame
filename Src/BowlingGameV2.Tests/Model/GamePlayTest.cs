using BowlingGameV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameV2.Tests.Model
{
    [TestClass]
    public class GamePlayTest
    {
        [TestMethod]
        public void When_Roll_Through_the_Game_Last_Frame_That_Is_Not_Done_Will_Be_Added_Pins()
        {
            Game g = new Game();
            g.Roll(10);//Frame 1
            g.Roll(2);//Frame 2
            g.Roll(2);//Frame 2
            g.Roll(5);//Frame 3

            var firstFrame = g.Frames[0];
            Assert.IsTrue(firstFrame.IsDone);
            Assert.AreEqual(Mark.Strike, firstFrame.Mark);

            var secondFrame = g.Frames[1];
            Assert.IsTrue(secondFrame.IsDone);
            Assert.AreEqual(Mark.Open, secondFrame.Mark);

            var thirdFrame = g.Frames[2];
            Assert.IsFalse(thirdFrame.IsDone);
            Assert.AreEqual(Mark.Open, secondFrame.Mark);
        }

        [TestMethod]
        public void Full_Game_With_Thre_Strikes_And_Spare()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(10);//1
                game.Roll(10);//2
                game.Roll(10);//3
                game.Roll(0); game.Roll(0);//4
                game.Roll(0); game.Roll(10);//5
                game.Roll(0); game.Roll(0);//6
                game.Roll(0); game.Roll(0);//7
                game.Roll(0); game.Roll(0);//8
                game.Roll(0); game.Roll(0);//9
                game.Roll(0); game.Roll(0);//10
            });
            Assert.AreEqual(70, result);
        }

        [TestMethod]
        public void Full_Game_With_Three_Strikes()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(10);//1
                game.Roll(10);//2
                game.Roll(10);//3
                game.Roll(0); game.Roll(0);//4
                game.Roll(0); game.Roll(0);//5
                game.Roll(0); game.Roll(0);//6
                game.Roll(0); game.Roll(0);//7
                game.Roll(0); game.Roll(0);//8
                game.Roll(0); game.Roll(0);//9
                game.Roll(0); game.Roll(0);//10
            });
            Assert.AreEqual(60, result);
        }

        [TestMethod]
        public void Full_Game_Real_Example()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(10);//1
                game.Roll(9); game.Roll(0);//2
                game.Roll(8); game.Roll(1);//3
                game.Roll(7); game.Roll(2);//4
                game.Roll(5); game.Roll(2);//5
                game.Roll(4); game.Roll(6);//6
                game.Roll(4); game.Roll(2);//7
                game.Roll(1); game.Roll(4);//8
                game.Roll(10);//9
                game.Roll(6); game.Roll(3);//10
            });
            Assert.AreEqual(106, result);
        }

        [TestMethod]
        public void Full_Game_Real_Example2()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(5); game.Roll(3);//1
                game.Roll(3); game.Roll(4);//2
                game.Roll(8); game.Roll(2);//3
                game.Roll(1); game.Roll(1);//4
                game.Roll(10);//5
                game.Roll(2);game.Roll(4);//6
                game.Roll(5);game.Roll(4);//7
                game.Roll(3); game.Roll(6);//8
                game.Roll(2);game.Roll(6);
            });
            Assert.AreEqual(76, result);
        }

        [TestMethod]
        public void Full_Game_Real_Example3()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(5); game.Roll(3);//1
                game.Roll(3); game.Roll(4);//2
                game.Roll(8); game.Roll(2);//3
                game.Roll(1); game.Roll(1);//4
                
            });
            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void Full_Game_All_Strike_Expect_One()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10);
                game.Roll(1); game.Roll(1);

            });
            Assert.AreEqual(245, result);
        }
        [TestMethod]
        public void Full_Game_All_Strike_Expect_One_With_Combination()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10);
                game.Roll(5);
                game.Roll(4);

            });
            Assert.AreEqual(263, result);
        }

        [TestMethod]
        public void Full_Game_Full_Strike()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10); game.Roll(10);
                game.Roll(10);
                game.Roll(10);
                game.Roll(10);
                game.Roll(10);

            });
            Assert.AreEqual(300, result);
        }

        [TestMethod]
        public void Full_Game_Full_Spare()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2); game.Roll(8);
                game.Roll(2);

            });
            Assert.AreEqual(120, result);
        }
    }
}