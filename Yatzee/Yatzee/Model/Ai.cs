﻿using System;
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
      
 

        int[] SmallStraight1;
        int[] SmallStraight2;
        int[] SmallStraight3;

        int[] LargeStraight1;
        int[] LargeStraight2;
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
            List<int> AiRoll = Roll.Roll();
            List<int> storedDiceValues = new List<int>();    
            List<int> ValuesNew = new List<int>();
            int computervalue = random.Next(1, 6);
            int[] AiArray = new int[5];
            int sum = 0;
            LargeStraight1 = new int[]{2,3,4,5,6};
            LargeStraight2 = new int[]{1,2,3,4,5};
           

            for (int i = 0; i<AiRoll.Count;i++ )
            {
               
                AiArray[i] = AiRoll[i];

                    SmallStraight1 = new int[] { 1, 2, 3, 4, i };
                    SmallStraight2 = new int[] { 2, 3, 4, 5, i };
                    SmallStraight3 = new int[] { 3, 4, 5, 6, i };
            }
             Array.Sort(AiArray);
             AiLowerSection(AiArray, AiRoll, storedDiceValues);
            foreach (int lista in AiArray)
            {
                Console.WriteLine("DICE {0}", lista);
            }
            foreach (int plista in storedDiceValues)
            {
                Console.WriteLine("Storage {0}", plista);
            }
            System.Threading.Thread.Sleep(1000);
            if (storedDiceValues.Count <3)
            {
                for (int j = 0; j < storedDiceValues.Count; j++)
                {
                    AiRoll.RemoveAt(j);
                }
                Roll.BotReRoll(AiRoll);
                ValuesNew = Storage(storedDiceValues, AiRoll, AiArray);
                for (int j = 5; j < ValuesNew.Count; j--)
                {
                    AiRoll.RemoveAt(j);
                }
                foreach (int p in ValuesNew)
                {
                    Console.WriteLine("End Result from Storage {0}", p);
                }
                sum= storedDiceValues.Max();
                Rule.AddUpDice(ValuesNew, sum);
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

        public void AiLowerSection(int[] AiArray, List<int> AiRoll, List<int> storedDiceValues)
        {
            if (storedDiceValues.Count>4)
            {
                GetYatzee = Rule.Yatzee(AiRoll);
            }
            else if (storedDiceValues.Count>3)
            {
                GetFourOfAKind = Rule.FourOfAKind(AiRoll);
            }
            else if (storedDiceValues.Count>2)
            {
                GetThreeOfAKind = Rule.ThreeOfAKind(AiRoll);
            }

            if (AiArray == SmallStraight1 || AiArray == SmallStraight2 || AiArray == SmallStraight3)  // works
            {
              GetSmallStraight= Rule.SmallStraight(AiRoll);
                Console.WriteLine("Small Straight for bot");
            }
            Array.Sort(AiArray);
           
            if (AiArray == LargeStraight1 || AiArray == LargeStraight2)   // works
            {
              GetLargeStraight= Rule.LargeStraight(AiRoll);
                Console.WriteLine("LArgeStraight for bot");
            }
        
        }
        }
    }

