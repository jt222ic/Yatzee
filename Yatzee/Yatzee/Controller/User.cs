using System;
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
        Ai Ai;
        DiceRule Rules;
        List<int> ListaAvRoll;
        IReadOnlyCollection<Player> ListOfPlayers;
        CheckBox box;
        bool perforReRoll = false;
        bool RerollView = false;
        int Tossthree = 0;
        int dicenumber;
        public bool playerDone;

        int choice;
        public User()
        {
            box = new CheckBox();
            roll = new Dice();
            show = new ViewStatus();
            Rules = new DiceRule(box,show);
            PlayerList.Add(player = new Player("Human", ListaAvRoll, box));    // upstart of the game , so people dont make mistake by throwing without adding player
        }
        public void MainMenu()
        {
            do
            {
                show.DisplayFirstPage(perforReRoll);
                string choices = System.Console.ReadLine();
                int Choice = int.Parse(choices);

                switch (Choice)
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
                        ChoiceOfReRoll();
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
                    case 7:                             // weird bug when used 7 u register the same char twice
                     PlayerList = DAL.Initialize();   // load the list so you have to pick the right character by pressing switch and the right number id
                     break;
                    case 8:

                     Ai.AiTurn(playerDone);
                        break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public void Register()
        {
            do
            {
                show.Register();
                string Registration = System.Console.ReadLine();
                
                
                int RegisterAlt = int.Parse(Registration);

                switch (RegisterAlt)
                {
                    case 0:
                        return;
                    case 1:
                      PlayerList.Add(player = new Player(show.ReturnInfo(), ListaAvRoll, box));
                        break;
                    case 2:
                        Ai = new Ai(player,new DiceRule(box,show), new Dice(), show);
                        break;
                    case 3:
                        ChangePlayer();
                        break;
                    case 4:
                        RemovePlayer();
                        break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void RemovePlayer()
        {
            
            ListOfPlayers = DAL.getMemberList();
            show.CompactList(ListOfPlayers);
            choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            choice--;
            player = ListOfPlayers.ElementAt(choice);
            DAL.removeMember(choice);
        }

        public void ChangePlayer()
        {
            
            ListOfPlayers = DAL.getMemberList();
            show.CompactList(ListOfPlayers);
            choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            choice--;
            player.Update(box);
            player = PlayerList.ElementAt(choice);
        }

        public void ChoiceOfReRoll()
        {
            Tossthree = 0;
            bool RerollView = true;
            show.DisplayRoll(ListaAvRoll, RerollView);
            do
            {
                try
                {
                    show.showDiceAlternative(player.HoldState);
                    string NewReRoll = System.Console.ReadLine();
                    int DiceChoice = int.Parse(NewReRoll);

                    switch (DiceChoice)
                    {
                        case 0:
                            return;
                        case 1:
                            dicenumber = 0;
                            roll.ReRoll(dicenumber, ListaAvRoll, player);
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
                            if (Tossthree < 2)
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
                catch
                {
                    show.Catch();
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
                    player.TOTALSCORE = Rules.TotalScore;
                    player.GetBonus = Rules.Bonus();
                
                    switch (RuleChoice)
                    {

                        case 0:
                            return;

                        case 1:
                            PlayerValue = 1;
                            if (!box.gapOne())
                            {
                                player.GetOne = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            }
                            break;

                        case 2:
                            PlayerValue = 2;
                            if (!box.gapTwo())
                            {
                                player.GetTwo = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            }
                            break;

                        case 3:
                            PlayerValue = 3;
                            if (!box.gapThree())
                            {
                                player.GetThree = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            }
                            break;

                        case 4:
                            if (!box.gapFour())
                            {
                                PlayerValue = 4;
                                player.GetFour = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            }
                            break;

                        case 5:
                            if (!box.gapFive())
                            {
                                PlayerValue = 5;
                                player.GetFive = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            }
                            break;

                        case 6:
                            if (!box.gapSix())
                            {
                                PlayerValue = 6;
                                player.GetSix = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            }
                            break;

                        case 7:
                            show.showLowerSection();
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
                        break;

                    case 2:
                        player.GetFourOfAKind = Rules.FourOfAKind(ListaAvRoll);  
                        break;

                    case 3:
                        player.GetFullHouse = Rules.FullHouse(ListaAvRoll); 
                        break;

                    case 4:
                        player.GetSmallStraight = Rules.SmallStraight(ListaAvRoll); 
                        break;
                    case 5:
                        player.GetLargeStraight = Rules.LargeStraight(ListaAvRoll);
                        break;

                    case 6:
                        player.GetChance = Rules.Chance(ListaAvRoll); 
                        break;

                    case 7:
                        player.GetYatzee = Rules.Yatzee(ListaAvRoll); 
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
