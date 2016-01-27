using System;
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
            System.Console.WriteLine("0.Roll a dice  || roll only 1x here until you have set your points");
            System.Console.WriteLine("1. press to save or quit");
            System.Console.WriteLine("2. Set Points || need to roll first before setting");
            System.Console.WriteLine("3. Re-Roll");
            System.Console.WriteLine("4. Register");
            System.Console.WriteLine("5. CompactList: Name,TotalScore, Date");
            System.Console.WriteLine("6. FullList: Date, and FullScoring");
            System.Console.WriteLine("7. Player is Done, Computers turn || Require to create an CPU");
            System.Console.WriteLine("8. Score for comp");
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
            foreach (int dice in ListaOverDice)
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
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine(" ****Yatzee****||{0}               ||", member.GetName);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("============UpperSection=============");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Ones         ||{0}       ||", member.GetOne);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Twos         ||{0}       ||", member.GetTwo);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Threes       ||{0}       ||", member.GetThree);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Fours        ||{0}       ||", member.GetFour);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Five         ||{0}       ||", member.GetFive);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Sixes        ||{0}       ||", member.GetSix);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Sum          ||          ||");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Bonus        ||{0}       ||", member.GetBonus);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("============LowerSection=============");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Three of a Kind       ||{0}          ||", member.GetThreeOfAKind);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Four of a Kind        ||{0}          ||", member.GetFourOfAKind);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Full House            ||{0}          ||", member.GetFullHouse);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Small Straight        ||{0}          ||", member.GetSmallStraight);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Large Straight        ||{0}          ||", member.GetLargeStraight);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Chance                ||{0}          ||", member.GetChance);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("YAHTZEE               ||{0}          ||", member.GetYatzee);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("TOTALSCORE            ||{0}          ||", member.GetTotalScore);
            }
        }

        public void Register()
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("Press 0 to return to ");
            System.Console.WriteLine("1. Register Player");
            System.Console.WriteLine("2.  Register Comp");
            System.Console.WriteLine("3.  Change Player");
            System.Console.WriteLine("4.  Remove Player");
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
            int i = 1;
            Console.WriteLine("Player: ");
            foreach (Model.Player member in list)
            {
                System.Console.WriteLine("Name :{0}, Date {1}, TotalScore : {2}  MemberID : {3} ",
                member.GetName, member.date, member.GetTotalScore,i++);
            }
        }
        public void AiList(IReadOnlyCollection<Computer> list, Computer CompDice)  // spara in listan först
        {
            Console.WriteLine("Computer: ");
            foreach (Model.Computer computer in list)
            {
                System.Console.WriteLine("{0}",computer.GetTotalSum) ;
            }
            foreach (int AndroidDice in CompDice.AiRoll)
            {
                
                System.Console.WriteLine("Dice: {0}", AndroidDice);
            }
        }
    }
}
    
