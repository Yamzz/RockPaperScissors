using RockPaperScissors.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.GameLogic
{
    public interface IMakeGesture
    {
        public Guesture GetPlayerGuesture();
    }
}
