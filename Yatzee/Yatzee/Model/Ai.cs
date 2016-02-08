using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.View;

namespace Yatzee.Model
{
    
    class Ai : Computer
    {
        Player Player;
        DiceRule Rule;
        Dice Roll;
        Random random;
        ViewStatus Show;
        bool small;
        List<int> Regel = new List<int>();
        int[] LargeStraight1;
        int[] LargeStraight2;
        bool LowerExist;
        public Ai(Player player, DiceRule rule, Dice roll, ViewStatus show)
        {
            Player = player;
            Roll = roll;
            Rule = rule;
            random = new Random();
            Show = show;
        }
        public bool AiTurn(bool playerdone)
        {
            if (!playerdone)
            {
                RollDice(Roll);
                return true;
            }
            return false;
        }
        public bool ComputerWin()
        {
            if (TOTALSCORE > Player.TOTALSCORE)
            {
                return true;
            }
            return false;
        }
        public void RollDice(Dice Roll)
        
        {

            LowerExist = false;
            List<int> AiRoll = Roll.Roll();
            List<int> storedDiceValues = new List<int>();    
            List<int> ValuesNew = new List<int>();

            
            int computervalue = random.Next(1, 6);
            int[] AiArray = AiRoll.ToArray();
            int sum = 0;
            LargeStraight1 = new int[]{2,3,4,5,6};
            LargeStraight2 = new int[]{1,2,3,4,5};


            int[] values = new int[6];
            Dictionary<int, int> finalValues = new Dictionary<int, int>();

            foreach (int diceValue in AiRoll)
            {
                if (!finalValues.ContainsKey(diceValue))
                {
                    finalValues.Add(diceValue, 0);
                }
                finalValues[diceValue]++;
            }
            foreach (KeyValuePair<int, int> storage in finalValues)
            {
             Console.WriteLine("STORAGE {0} x{1}", storage.Key, storage.Value);
            }
            small = finalValues.ContainsKey(1) && finalValues.ContainsKey(2) && finalValues.ContainsKey(3) && finalValues.ContainsKey(4);
            AiLowerSection(AiArray, AiRoll, finalValues);

            if (finalValues.Values.Max() <3 &&!LowerExist)
            {
                if (!LowerExist)
                {
                    for (int k = finalValues.Values.Max(); k > 0; k--)
                    {
                        AiRoll.RemoveAt(k);
                    }
                    AiLowerSection(AiArray, AiRoll, finalValues);
                    Roll.BotReRoll(AiRoll);
                    ValuesNew = Storage(storedDiceValues, AiRoll, AiArray);
                }
                if (!LowerExist)
                {
                    foreach (int situation in AiRoll)
                    {
                        Console.WriteLine(" second reroll{0}", situation);
                    }
                    ValuesNew = Storage(storedDiceValues, AiRoll, AiArray);

                    sum = finalValues.Values.Max();
                    Roll.BotReRoll(AiRoll);
                    Rule.AddUpDice(AiRoll, sum);
                }
            }
        }
        public List<int> Storage(List<int> storedDiceValues, List<int> Airoll, int[] AiArray)
        {
            for (int i = 0; i < Airoll.Count; i++)
            {
                storedDiceValues.Add(AiArray[i]);
            }
            return storedDiceValues;
        }
        public void AiLowerSection(int[] AiArray, List<int> AiRoll, Dictionary<int,int> Final)
        {

            foreach (KeyValuePair<int, int> final in Final)
            {
                if (final.Value > 4)
                {
                    GetYatzee = Rule.Yatzee(AiRoll);
                    LowerExist = true;
                }
                else if (final.Value > 3)
                {
                    GetFourOfAKind = Rule.FourOfAKind(AiRoll);
                    LowerExist = true;
                }
                else if (final.Value > 2)
                {
                    GetThreeOfAKind = Rule.ThreeOfAKind(AiRoll);
                    LowerExist = true;
                }
            }
            Array.Sort(AiArray);
            if (AiArray == LargeStraight1 || AiArray == LargeStraight2)   // works ??
            {
               
                GetLargeStraight = Rule.LargeStraight(AiRoll);
                LowerExist = true;
            }
            else if(small)
            {
                  // works
                GetLargeStraight = Rule.LargeStraight(AiRoll);
                LowerExist = true;
            }
        }

        }
    }

