using BowlingGameV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameV2.Tests.Model
{
    [TestClass]
    public class GameRulesTests
    {
        [TestMethod]
        public void A_Game_Consists_Of_Ten_Frames()
        {
            Game g = new Game();
            Assert.AreEqual(10, g.Frames.Count);
        }

        [TestMethod]
        public void A_Frame_Strike_Is_When_All_10_Pins_Where_Knocked_Down_With_The_First_Roll()
        {
            var frame = new Frame(1);
            frame.Rolls.Add(10);
            Assert.IsTrue(frame.IsDone);
            Assert.AreEqual((int)Mark.Strike, (int)frame.Mark);
        }

        [TestMethod]
        public void A_Frame_Spare_Is_When_All_10_Pins_Where_Knocked_Down_Using_Two_Rolls()
        {
            var frame = new Frame(1);
            frame.Rolls.Add(1);
            frame.Rolls.Add(9);
            Assert.IsTrue(frame.IsDone);
            Assert.AreEqual((int)Mark.Spare, (int)frame.Mark);
        }

        [TestMethod]
        public void A_Frame_Open_Is_When_Some_Pins_Where_Left_Standing_After_The_Frame_Was_CompletedRolls()
        {
            var frame = new Frame(1);
            frame.Rolls.Add(1);
            frame.Rolls.Add(8);
            Assert.IsTrue(frame.IsDone);
            Assert.AreEqual((int)Mark.Open, (int)frame.Mark);
        }

        [TestMethod]
        public void For_An_Open_Frame_The_Score_Is_The_Total_Number_Of_Pins_Knocked_Down()
        {
            Game game = new Game();
            game.Roll(1);
            game.Roll(2);
            var score = game.Score;
            Assert.AreEqual(3, score);
        }

        [TestMethod]
        public void First_Frame_with_Two_Rolles_6_2_Should_Return_8()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(6);
                game.Roll(2);
            });
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Second_Frame_with_Two_Rolles_7_1_Should_Return_16()
        {
            var result = Game.Calculate((game) =>
            {
                game.Roll(6);
                game.Roll(2);
                game.Roll(7);
                game.Roll(1);
            });
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void Bonus_Roll_If_is_A_Strike_In_10_Frame_Then_Additional_Role_Must_Be_Provide()
        {
            var frame = new Frame(10);
            frame.Rolls.Add(10);
            frame.Rolls.Add(10);
            Assert.IsFalse(frame.IsDone);
        }
        [TestMethod]
        public void Bonus_Roll_If_is_A_Strike_In_10_Frame()
        {
            var frame = new Frame(10);
            frame.Rolls.Add(10);
            frame.Rolls.Add(8);
            frame.Rolls.Add(1);
            Assert.IsTrue(frame.IsDone);
        }
        [TestMethod]
        public void Bonus_Roll_If_is_A_Spare_In_10_Frame()
        {
            var frame = new Frame(10);
            frame.Rolls.Add(2);
            frame.Rolls.Add(8);
            frame.Rolls.Add(1);
            Assert.IsTrue(frame.IsDone);
        }
        [TestMethod]
        public void Bonus_Roll_If_is_A_Spare_In_10_Frame_Then_Additional_Role_Must_Be_Provide()
        {
            var frame = new Frame(10);
            frame.Rolls.Add(2);
            frame.Rolls.Add(8);
            Assert.IsFalse(frame.IsDone);
        }
    }
}
