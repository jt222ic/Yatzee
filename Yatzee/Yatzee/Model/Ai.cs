﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.View;

namespace Yatzee.Model
{
    class Ai
    {
        private int TotalScore;
        Player Player;
        List<int> ComputerRoll;
        DiceRule Rule;
        Dice Roll;
        int computervalue;
        Random random;
        ViewStatus Show;
        int computerPickDice;
        bool reroll = false;
        int max;
        int count;
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

            }
            return false;
        }
        public bool ComputerWin()
        {
            if (TotalScore > Player.TOTALSCORE)
            {
                return true;
            }
            return false;
        }
        public void RollDice(Dice Roll)
        
        {
            count = 0;
            List<int> AiRoll = Roll.Roll();
            List<int> storedDiceValues = new List<int>();    
            List<int> ValuesNew = new List<int>();
            int computervalue = random.Next(1, 6);
            int[] AiArray = new int[5];

            for (int i = 0; i<AiRoll.Count;i++ )
            {
                AiArray[i] = AiRoll[i];
               
                if (AiArray[i] == 1)
                {
                    storedDiceValues.Add(1);
                    
                }
            }
            foreach (int lista in AiArray)
            {
                Console.WriteLine("DICE {0}", lista);
            }
            System.Threading.Thread.Sleep(1000);
            if (storedDiceValues.Count <2)
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
                max = AiArray.Max();
                Rule.AddUpDice(ValuesNew, max);
            }
            else
            {
                Console.WriteLine("BIG");
                Rule.Yatzee(AiRoll);
                Rule.FourOfAKind(AiRoll);
                Rule.ThreeOfAKind(AiRoll);
                Rule.LargeStraight(AiRoll);
                Rule.SmallStraight(AiRoll);
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
        }
    }

