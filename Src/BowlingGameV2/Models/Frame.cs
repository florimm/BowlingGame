using System.Linq;

namespace BowlingGameV2.Models
{
    public class Frame
    {
        private readonly int frameNr;

        public Frame(int frameNr)
        {
            this.frameNr = frameNr;
            Rolls = new RollCollection(frameNr < 10 ? 2 : 3);// if is frame less then 10 then 2 rolles else 3 rolles can be added
        }

        public RollCollection Rolls { get; set; }

        public Mark Mark
        {
            get
            {
                if (frameNr < 10)
                {
                    if (Rolls.Count == 1 && Rolls.PinsDown == 10)
                        return Mark.Strike;
                }
                else
                {
                    if((Rolls.Count == 1 && Rolls.PinsDown == 10) ||
                        Rolls.Any() && Rolls.Last() == 10)
                        return Mark.Strike;
                }
                if (Rolls.Count == 2 && Rolls.PinsDown == 10)
                    return Mark.Spare;
                return Mark.Open;

            }
        }

        public bool IsDone
        {
            get
            {
                if (frameNr < 10 && Rolls.Count < 2 && Rolls.PinsDown < 10)
                {
                    return false;
                }
                if (frameNr == 10)
                {
                    if (Rolls.Count < 2 || (Rolls.Count < 3 && Rolls.PinsDown >= 10))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public int GameResult { get; set; }// this is updated when game score is executed (and hold real result of the Frame)
    }
}