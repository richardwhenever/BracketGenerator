using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BracketGenerator.Controllers
{
    public class TournamentController : Controller
    {
        #region Json Objects
        public struct SettingsResponse
        {
            public string BracketResultView;
            public int TotalMatchUpsCount;

        }
        #endregion

        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveSettings(string allPlayerNames)
        {
            SettingsResponse settingsResponse = new SettingsResponse();

            //List<string> playerNames = allPlayerNames.Split(',').ToList();
            //settingsResponse.PlayerNames = playerNames;

            var playerNames = allPlayerNames.Split(',');

            int currentIndex = 0;
            int oddAmountModifier = 0;

            if (playerNames.Count() % 2 == 1)
            {
                oddAmountModifier = 1;
            }

            List<string> allMatchUps = new List<string>();

            while (currentIndex < playerNames.Length / 2)
            {
                int opponentIndex = playerNames.Length - (currentIndex + 1);
                string currentMatchUp = playerNames[currentIndex + oddAmountModifier] + " VS " + playerNames[opponentIndex];

                allMatchUps.Add(currentMatchUp);

                currentIndex++;
            }
                        
            BracketMatchUpsViewModel viewModel = new BracketMatchUpsViewModel()
            {
                AllMatchUps = allMatchUps,
                IsOddAmountOfPlayer = true,
                TotalMatchUpCount = allMatchUps.Count
            };

            //var bracketResponse = PartialView("~/Views/Tournament/BracketMatchUps.cshtml", viewModel);
            var bracketResponse = Helpers.HtmlHelper.RenderPartialToString(this.ControllerContext, "~/Views/Tournament/BracketMatchUps.cshtml", viewModel);

            settingsResponse.BracketResultView = bracketResponse;
            settingsResponse.TotalMatchUpsCount = allMatchUps.Count;
            return Json(settingsResponse);
        }
    }
}