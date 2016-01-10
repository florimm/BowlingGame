using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameV2.Models
{
    public class Game
    {
        public Game()
        {
            Frames = new List<Frame>();
            Frames.AddRange(Enumerable.Range(1, 10).Select(t=> new Frame(t)));// Add 10 frames as Default.
        }
        public List<Frame> Frames { get; set; }
        public int Score
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < Frames.Count; i++)
                {
                    if (Frames[i].IsDone)
                    {
                        sum += GetScore(Frames[i], i);
                        Frames[i].GameResult = sum;//This will set real value of Frame after all the frames of a game are played.
                    }
                    else
                    {
                        return sum;
                    }
                }
                return sum;
            }
        }
        /// <summary>
        /// Roll will add rolls to the frame base on frame Mark
        /// </summary>
        /// <param name="pinsDown"></param>
        public void Roll(int pinsDown)
        {
            var currentElement = Frames.Select((frame, index)=> new { frame, index }).FirstOrDefault(t => t.frame.IsDone == false);
            if ((currentElement != null && currentElement.frame.Mark == Mark.Open) ||
                (currentElement.index == 9 && (currentElement.frame.Mark == Mark.Strike || currentElement.frame.Mark == Mark.Spare)))
            {
                Frames[currentElement.index].Rolls.Add(pinsDown);
            }
        }
        private int GetTwoRolls(Frame frame, int index)
        {
            if (frame.Mark == Mark.Strike)
            {
                if ((index + 1) < 10)
                {
                    return 10 + Frames[index + 1].Rolls[0];
                }
                return Frames[index].Rolls[1];
            }
            return frame.Rolls.PinsDown;
        }
        private int GetScore(Frame frame, int index)
        {
            int sum = frame.Rolls.PinsDown;
            if (index < 10)
            {
                if (frame.Mark == Mark.Strike)
                {
                    if (index + 1 < 10)
                    {
                        if (Frames[index + 1].IsDone)
                        {
                            sum += GetTwoRolls(Frames[index + 1], index + 1);
                        }
                    }
                    else
                    {
                        sum += frame.Rolls[2];
                    }

                }
                else if (frame.Mark == Mark.Spare)
                {
                    if (index + 1 < 10)
                    {
                        if (Frames[index + 1].IsDone)
                        {
                            sum += Frames[index + 1].Rolls[0];
                        }
                    }
                }
            }
            return sum;
        }
        public static int Calculate(Action<Game> action)// this method should be used as API because it calls SCORE. 
        {
            var game = new Game();
            action(game);
            return game.Score;
        }
    }
}