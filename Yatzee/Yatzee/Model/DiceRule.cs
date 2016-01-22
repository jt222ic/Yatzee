using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    class DiceRule
    {

        Dice Dices;
        List<int> ListOfDice;
     
       public int Sum = 0;
       public DiceRule(Dice dice)
        {
            Dices = dice;
        }
        public int AddUpDice(List<int> ListOfDice, int PlayerSelectValues)
        {
            Sum = 0;
            this.ListOfDice = ListOfDice;
                for (int i = 0; i < ListOfDice.Count; i++ )
                {
                    if (ListOfDice[i] == PlayerSelectValues )
                    {
                        Sum += PlayerSelectValues;
                    }
            }
                Console.WriteLine("Position {0}", Sum);
                return Sum;
        }
        
        //public int ThreeOfAKind(List<int> Dice)
        //{
        //     Sum = 0;
        //    bool ThreeOfAKind = false;

        //    for (int i = 0; i <= 4; i++)
        //    {
        //        int Count = 0;
        //        for (int j = 0; j < 4; j++)
        //        {
        //            if (Dice[j] == i)
        //                Count++;

        //            if (Count > 2)
        //                ThreeOfAKind = true;
        //        }
        //    }

        //    if (ThreeOfAKind)
        //    {
        //        for (int k = 0; k < 5; k++)
        //        {
        //            Sum += Dices.RollNumber;
        //        }
        //        Console.Write("THree of a kind : {0}", Sum);
        //    }

        //    return Sum;
        //}

        public int LargeStraight(List<int>ListOfDice)    // work
        {
            Sum = 0;
            int[] ArrayLarge = new int[5];

            for (int i = 0; i < ListOfDice.Count; i++)
            {
                ArrayLarge[0] = ListOfDice[0];
                ArrayLarge[1] = ListOfDice[1];
                ArrayLarge[2] = ListOfDice[2];
                ArrayLarge[3] = ListOfDice[3];
                ArrayLarge[4] = ListOfDice[4];
            }
            Array.Sort(ArrayLarge); 

                if (((ArrayLarge[0] == 1) &&       
                     (ArrayLarge[1] == 2) &&
                     (ArrayLarge[2] == 3) &&
                     (ArrayLarge[3] == 4) &&
                     (ArrayLarge[4] == 5))||
                     ((ArrayLarge[0] == 2) &&
                     (ArrayLarge[1] == 3) &&
                     (ArrayLarge[2] == 4) &&
                     (ArrayLarge[3] == 5) &&
                     (ArrayLarge[4] == 6)))
            {
                Sum = 40;
                Console.WriteLine("Large STRAIGHT {0}", Sum);
            }
                
            return Sum;
        }

        public int FullHouse(List<int>ListOfDice)
        {
            Sum = 0;
            int[] ArrayHouse = new int[5];

            for (int i = 0; i < ListOfDice.Count; i++)
            {
                ArrayHouse[0] = ListOfDice[0];
                ArrayHouse[1] = ListOfDice[1];
                ArrayHouse[2] = ListOfDice[2];
                ArrayHouse[3] = ListOfDice[3];
                ArrayHouse[4] = ListOfDice[4];
            }
            Array.Sort(ArrayHouse);
                if ((((ArrayHouse[0] == ArrayHouse[1]) && (ArrayHouse[1] == ArrayHouse[2])) &&
                     (ArrayHouse[3] == ArrayHouse[4]) &&
                     (ArrayHouse[2] != ArrayHouse[3])) ||
                    ((ArrayHouse[0] == ArrayHouse[1]) &&
                     ((ArrayHouse[2] == ArrayHouse[3]) && (ArrayHouse[3] == ArrayHouse[4])) &&
                     (ArrayHouse[1] != ArrayHouse[2])))
                {
                    Sum = 25;
                    Console.WriteLine(" FULL HOUSE {0}", Sum);
                }
            
            return Sum;
        }


    }
}
