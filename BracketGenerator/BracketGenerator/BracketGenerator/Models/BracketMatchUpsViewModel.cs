using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BracketGenerator.Models
{
    public class BracketMatchUpsViewModel
    {
        public List<string> AllMatchUps { get; set; }
        public bool IsOddAmountOfPlayer { get; set; }
        public int TotalMatchUpCount { get; set; }
    }
}