using RockPaperScissors.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players
{
    public interface IPlayer : IMakeGesture
    {
        public string Name { get; set; }
        public int Wins { get; set; }

    }
}
