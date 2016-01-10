using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BowlingGameV2.Models;
using BowlingGameV2.ViewModel;
using BowlingGameV2.Helpers;

namespace BowlingGameV2.Controllers
{
    public class GameScoreController : Controller
    {
        [HttpPost]
        public JsonResult Frames(List<FrameViewModel> frames)
        {
            var game = new Game();
            game.Rolls(frames);
            return Json(new {score= game.Score});
        }
    }
}