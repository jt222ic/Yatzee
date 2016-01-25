﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model;

namespace Yatzee.View
{
    class ViewStatus
    {
        public void DisplayFirstPage(bool Reroll)
        {
            System.Console.Clear();
            System.Console.WriteLine(" :~, *   * ~,");
            System.Console.WriteLine(" : ~, *   * ~.");
            System.Console.WriteLine(" :  ~........~");
            System.Console.WriteLine("  : *:         :      ~'~,      ");
            System.Console.WriteLine(" :  :         :    ~'   *  ~,   ");
            System.Console.WriteLine(" ~* :    *    : ,~' *       * ~,");
            System.Console.WriteLine("  ~,:         :.~,*       *  ,~:");
            System.Console.WriteLine("  ~:.........::  ~,    *   ,~ : ");
            System.Console.WriteLine("              :  *     ~,,~  * : ");
            System.Console.WriteLine("              :* * *   :  *  : ");
            System.Console.WriteLine("                * ~    : *    ,~ ");
            System.Console.WriteLine("                    ~,  :  ,~   ");
            System.Console.WriteLine("                      ~,:,~     ");
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("        ****Yatzee****                      ");
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("0.Roll a dice");
            System.Console.WriteLine("1. press to save or quit");
            System.Console.WriteLine("2. Set Points");
            System.Console.WriteLine("3. Re-Roll");
            System.Console.WriteLine("4. Register");
            System.Console.WriteLine("5. CompactList: Name,TotalScore, Date");
           
         

            //if (Reroll)
            //{
            //    System.Console.Clear();
            //    System.Console.WriteLine("======================================================");
            //    System.Console.WriteLine("        ****Yatzee****                      ");
            //    System.Console.WriteLine("==========================================");
            //    System.Console.WriteLine("1. press to save or quit");
            //    System.Console.WriteLine("2. Set Points");
            //    System.Console.WriteLine("3. Re-Roll");
            //    System.Console.WriteLine("4. Register");
            //}
        }
        public void showDiceAlternative(bool hold)
        {
            if (!hold)
            {
                System.Console.WriteLine("============================");
                System.Console.WriteLine("Pick Dices to change");
                System.Console.WriteLine("=========================== ");
            }
            else
            {
                System.Console.WriteLine("YOU HAVE USED ALL YOUR CHANCE");
            }
        }

        public void DisplayRoll(List<int> ListaOverDice, bool Diceroll)
        {
            Console.Clear();
            foreach(int dice in ListaOverDice)
            {
                System.Console.WriteLine("Dice: {0}", dice);
            }
            if (Diceroll)
            {
                
                System.Console.WriteLine("======================================================");
                System.Console.WriteLine("Press 1- 5 to switch each Dices and press Enter");
                System.Console.WriteLine("Press 6 for first re-roll");
                System.Console.WriteLine("Press 0 to return to first page");
                System.Console.WriteLine("======================================================");
            }
        }
        public void DisplayScore(IReadOnlyCollection<Player> list)
        {
            foreach (Model.Player member in list)
            {
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("        ****Yatzee****||   You     ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("============UpperSection=============");
            System.Console.WriteLine("=====================================");

            System.Console.WriteLine("         Ones         || {0}           ||", member.GetAddup);
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("         Twos         ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("         Threes       ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("         Fours        ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("         Sixes        ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("         Sum          ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("         Bonus        ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("============LowerSection=============");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("Three of a Kind       ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("Four of a Kind        ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("Full House            ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("Small Straight        ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("Large Straight        ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("Chance                ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("YAHTZEE               ||           ||");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("TOTALSCORE            ||           ||");
            }
            
          
        }

        public void Register()
        {
            System.Console.Clear();

            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("Press 0 to return to ");
            System.Console.WriteLine("1. Register Player");
            System.Console.WriteLine("2  Register Comp");
            System.Console.WriteLine("======================================================");
        }

        public string ReturnInfo()
        {
            System.Console.Clear();
            System.Console.WriteLine("==============PLease write your name down===========================");
            return System.Console.ReadLine();
        }

        public void CompactList(IReadOnlyCollection<Player> list)  // spara in listan först
        {

            Console.WriteLine("Player: ");
            foreach (Model.Player member in list)
            {
                System.Console.WriteLine("Name :{0}, Date {1}, AddupScore : {2} ",

                member.GetName, member.date, member.GetAddup

                );
                
               
            }
        }

        
    }
}
