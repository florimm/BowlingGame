using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BowlingGameV2.Models;
using BowlingGameV2.ViewModel;

namespace BowlingGameV2.Helpers
{
    public static class ModelExtensions
    {
        public static void Rolls(this Game game, List<FrameViewModel> viewModels)
        {
            var counter = 1;
            foreach (var frame in viewModels)
            {
                game.Roll(frame.First);
                if (frame.First < 10)
                {
                    game.Roll(frame.Second);
                }
                else if (counter == 10 && frame.Third.HasValue)
                {
                    game.Roll(frame.Second);
                    game.Roll(frame.Third.Value);
                }
                counter++;
            }
        }
    }
}