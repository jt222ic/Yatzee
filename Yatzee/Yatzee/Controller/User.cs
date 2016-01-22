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
        Dice roll;
        Computer Ai;
        DateTime time;
        List<int> ListaAvRoll = new List<int>();
        bool perforReRoll = false;
        bool RerollView = false;
        int Tossthree = 0;
        public User()
        {
            player = new Player("");
            show = new ViewStatus();
            roll = new Dice(player);
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
                    player = new Player(show.ReturnInfo());
                    
                   
                    break;
                case 2:
                    Ai = new Computer();
                    break;
            }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void ChoiceOfReRoll(ViewStatus show)
        {
            Tossthree = 0;
            bool RerollView = true;
            
            show.DisplayRoll(ListaAvRoll, RerollView);
          
            do{
              show.showDiceAlternative(player.HoldState);
              string NewReRoll = System.Console.ReadLine();
              int dicenumber;
              int DiceChoice = int.Parse(NewReRoll);
              
               
                    switch (DiceChoice)
                    {
                        case 0:
                            return;
                        case 1:
                            dicenumber = 0;
                            roll.ReRoll(dicenumber, ListaAvRoll);
                            continue;
                        case 2:
                            dicenumber = 1;
                            roll.ReRoll(dicenumber, ListaAvRoll);
                            break;
                        case 3:
                            dicenumber = 2;
                            roll.ReRoll(dicenumber, ListaAvRoll);
                            break;
                        case 4:
                            dicenumber = 3;
                            roll.ReRoll(dicenumber, ListaAvRoll);
                            break;
                        case 5:
                            dicenumber = 4;
                            roll.ReRoll(dicenumber, ListaAvRoll);
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
            DiceRule Rules = new DiceRule(roll);
            show.DisplayScore(Rules);

            do
            {
                string choices = System.Console.ReadLine();
                int PlayerValue;
                int RuleChoice = int.Parse(choices);
                Tossthree = 0;
                perforReRoll = false;
            
            switch(RuleChoice)
            {

                case 0:
                    return;
               case 1:
               PlayerValue = 1;
               Rules.AddUpDice(ListaAvRoll, PlayerValue);  // work
               Console.WriteLine("Mark on 1");
              
               break;
                case 2:
               PlayerValue = 2;
               Rules.AddUpDice(ListaAvRoll, PlayerValue);
               Console.WriteLine("Mark on 2");
               
              
               break;
                case 3:
               PlayerValue = 3;
               Rules.AddUpDice(ListaAvRoll, PlayerValue);
               Console.WriteLine("Mark on 3");
              
              
               break;
                case 4:
               PlayerValue = 4;
               Rules.AddUpDice(ListaAvRoll, PlayerValue);
               Console.WriteLine("Mark on 4");
               
              
               break;
                case 5:
               PlayerValue = 5;
               Rules.AddUpDice(ListaAvRoll, PlayerValue);
               Console.WriteLine("Mark on 5");
               
               
               break;
                case 6:
               PlayerValue = 6;
               Rules.AddUpDice(ListaAvRoll, PlayerValue);
               Console.WriteLine("Mark on 6");
               
               break;
                case 7:
               //Rules.ThreeOfAKind(ListaAvRoll);
               Console.WriteLine("Three of a Kind");
               
               break;

                case 8:
               Console.WriteLine("Large Straight");   // work
               Rules.LargeStraight(ListaAvRoll);
               break;

                case 9:
               Console.WriteLine("FULL HOUSE");   // work
               Rules.FullHouse(ListaAvRoll);
               break;
            }

            }
            while
            (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
