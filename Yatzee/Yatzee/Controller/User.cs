﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model;
using Yatzee.View;

namespace Yatzee.Controller
{
    class User
    {
        ViewStatus show;
        Player player;
        List<Player> PlayerList = new List<Player>();
        Dice roll;
        Computer Ai;
        DiceRule Rules;
        List<int> ListaAvRoll;
        IReadOnlyCollection<Player> ListOfPlayers;
        bool perforReRoll = false;
        bool RerollView = false;
        int Tossthree = 0;
        int dicenumber;
        public bool playerDone;
        public User()
        {
            roll = new Dice();
            Rules = new DiceRule();
            PlayerList.Add(player = new Player("Human", ListaAvRoll));
            show = new ViewStatus();
        }
        public void MainMenu()
        {
            do {

                show.DisplayFirstPage(perforReRoll);
                string choices = System.Console.ReadLine();
                int Choice = int.Parse(choices);

                switch(Choice)
                {
                    case 0:
                      ListaAvRoll = roll.Roll();
                      perforReRoll = true;
                        
                      show.DisplayRoll(ListaAvRoll, RerollView);
                        break;

                    case 1:
                        DAL.SaveToFile();
                        break;
                    case 2:
                        FillTheGap();
                        break;
                        
                    case 3:
                        ChoiceOfReRoll(show);

                        break;  
                    case 4:
                        Register();
                        break;
                    case 5:
                        show.CompactList(DAL.getMemberList());
                        break;
                    case 6:
                        show.DisplayScore(DAL.getMemberList());
                        break;
                    case 7:
                        playerDone = true;
                        Ai.TestingAI(playerDone);
                        break;
                    case 8:
                        //show.AiList(DAL.GetComputerList(),Ai);
                        break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public void Register()
        {
            do{
                show.Register();
                string Registration = System.Console.ReadLine();
                int RegisterAlt = int.Parse(Registration);

            switch(RegisterAlt)
            {
                case 0:
                   return;
                case 1:
                  PlayerList.Add(player = new Player(show.ReturnInfo(), ListaAvRoll));
                    break;
                case 2:
                    Ai = new Computer();
                    break;
                case 3:
                    ChangePlayer();
                    break;
            }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void ChangePlayer()
        {
            
            ListOfPlayers = DAL.getMemberList();
            show.CompactList(ListOfPlayers);
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            choice--;
            player = PlayerList.ElementAt(choice);

        }

        public void ChoiceOfReRoll(ViewStatus show)
        {
            Tossthree = 0;
            bool RerollView = true;
            show.DisplayRoll(ListaAvRoll, RerollView);
            do{
              show.showDiceAlternative(player.HoldState);
              string NewReRoll = System.Console.ReadLine();
              int DiceChoice = int.Parse(NewReRoll);

                    switch (DiceChoice)
                    {
                        case 0:
                            return;
                        case 1:
                            dicenumber = 0;
                            roll.ReRoll(dicenumber, ListaAvRoll, player);  // WORKS
                            continue;
                        case 2:
                            dicenumber = 1;
                            roll.ReRoll(dicenumber, ListaAvRoll, player);
                            break;
                        case 3:
                            dicenumber = 2;
                            roll.ReRoll(dicenumber, ListaAvRoll, player);
                            break;
                        case 4:
                            dicenumber = 3;
                            roll.ReRoll(dicenumber, ListaAvRoll, player);
                            break;
                        case 5:
                            dicenumber = 4;
                            roll.ReRoll(dicenumber, ListaAvRoll, player);
                            break;

                        case 6:
                            if (Tossthree <2)
                            {
                                show.DisplayRoll(ListaAvRoll, perforReRoll);
                                Tossthree++;
                            }
                            else 
                            {
                                player.HoldState = true;
                                
                            }
                              break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public void FillTheGap()
        {

            show.DisplayScore(DAL.getMemberList());
           
            do
            {
                string choices = System.Console.ReadLine();
                int PlayerValue;
                int RuleChoice = int.Parse(choices);
                Tossthree = 0;
                perforReRoll = false;
                player.GetTotalScore = Rules.TotalScore;
                player.GetBonus = Rules.Bonus();
            
            switch(RuleChoice)
            {

               case 0:
                    return;

               case 1:
               PlayerValue = 1;
               Console.WriteLine("Mark on 1");
               player.GetOne = Rules.AddUpDice(ListaAvRoll, PlayerValue);  //works
               break;

                case 2:
               PlayerValue = 2;
               Console.WriteLine("Mark on 2");
               player.GetTwo = Rules.AddUpDice(ListaAvRoll, PlayerValue);  //works
               break;

                case 3:
               PlayerValue = 3;
               player.GetThree = Rules.AddUpDice(ListaAvRoll, PlayerValue);  //works
               Console.WriteLine("Mark on 3");
               break;

                case 4:
               PlayerValue = 4;
               player.GetFour = Rules.AddUpDice(ListaAvRoll, PlayerValue);  //works
               break;

                case 5:
               PlayerValue = 5;
               player.GetFive = Rules.AddUpDice(ListaAvRoll, PlayerValue);  // works
               Console.WriteLine("Mark on 5");
               break;

                case 6:
               PlayerValue = 6;
               player.GetSix = Rules.AddUpDice(ListaAvRoll, PlayerValue);
               Console.WriteLine("Mark on 6");
               break;

                case 7:
               LowerSection();
               break;
            }

            }
            while
            (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        public void LowerSection()
        {  
            do
            {
                string lowerchoices = System.Console.ReadLine();
                int LowerChoice = int.Parse(lowerchoices);
                perforReRoll = false;
                player.GetBonus = Rules.Bonus();

                switch (LowerChoice)
                {
                    case 0:
                        return;
                    case 1: 
                       player.GetThreeOfAKind = Rules.ThreeOfAKind(ListaAvRoll);
                      Console.WriteLine("Three of a Kind");   // works
                      break;

                    case 2:
                      player.GetFourOfAKind = Rules.FourOfAKind(ListaAvRoll);  //works
                      Console.WriteLine("Four of a Kind");
                      break;

                    case 3:
                      player.GetFullHouse = Rules.FullHouse(ListaAvRoll); // works
                        Console.WriteLine("FULL HOUSE");
                        break;

                    case 4:
                        player.GetSmallStraight = Rules.SmallStraight(ListaAvRoll); // works
                        Console.WriteLine("SMALL straight");
                        break;
                    case 5:
                        player.GetLargeStraight = Rules.LargeStraight(ListaAvRoll);  // works
                        Console.WriteLine("LARGESTRAIGHT");
                        break;

                    case 6:
                        player.GetChance = Rules.Chance(ListaAvRoll); // works
                        Console.WriteLine("Chance!");
                        break;

                    case 7:
                        player.GetYatzee = Rules.Yatzee(ListaAvRoll); // works
                        Console.WriteLine("YATZEEE");
                        break;

                    default:
                        return;
                }
            }
            while
            (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
