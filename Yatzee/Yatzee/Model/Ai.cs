using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    class Ai
    {
        int TotalScore;
        Dice Roll;
        DiceRule Rule;
      

        public bool AiTurn(bool playerdone)
        {
            if(playerdone)
            {
                RollDice(Roll);
            }
            return false;
        }
        public bool ComputerWin(Player jan)
        {
            if (TotalScore > jan.TOTALSCORE)
            {
                return true;
            }

            return false;
        }
        public void RollDice(Dice Roll)
        {
            Roll.Roll();
        }
    }
}
