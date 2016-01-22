using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    class Dice
    {
        Random random = new Random();
        private int i;
        public int RollNumber;
        List<int> unique = new List<int>();
        List<int> newDices = new List<int>();
        Player Prayer;
      public Dice(Player player)
        {
            Prayer = player;
        }
        public List<int> Roll()
        {
            for (i = 1; i < 6; i++)
            {
                unique.Add(RollNumber = random.Next(1, 6));
            }
            return unique;
        }
        public List<int> ReRoll(int whichdice,List<int>OldDice)    
        {
            if (!Prayer.HoldState)
            {
                OldDice[whichdice] = random.Next(1, 6);
            }
            
            return OldDice;
        }
    }
}
     




           
    

