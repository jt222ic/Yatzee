using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    public class Computer
    {
    

       // Dice AiDice;
       // DiceRule AiRule;
       // private int Sum = 0;
       // int k;
       // int u;
       //public List<int> AiRoll;
       // Random random;
       // public Computer()
       // {
       //     AiDice = new Dice();
       //     //AiRule = new DiceRule();
       //     //sendToMemberList(this);
       // }
       // //public void sendToMemberList(Computer comber)
       // //{
       // //    DAL.AddCompList(comber);
       // //}
       // public int GetTotalSum
       // {
       //     get
       //     {
       //         return Sum;
       //     }
       //     set
       //     {
       //         Sum = value;
       //     }
       // }
       // public int TestingAI(bool playerdone)
       // {
            
       //     AiRoll = new List<int>();
       //     random = new Random();
       //     if (playerdone)
       //     {
       //         System.Threading.Thread.Sleep(700);
       //         Console.WriteLine("Computer Cast");
       //         AiRoll = AiDice.Roll();

       //         bool Yatzee = false;
       //         bool FourOfAKind = false;
       //         bool threeOfAKind = false;


       //         for (int t = 1; t <=6; t++)
       //         {
       //             int Count = 0;
       //             for (int j = 0; j < AiRoll.Count; j++)
       //             {
       //                 if (AiRoll[j] == t)
       //                 {
       //                     Count++;
       //                 }
       //                 if (Count > 4)
       //                 {
       //                     Console.WriteLine("YATZEEAAAAAAAAAAAAAAAAAAAAAA");
       //                     Yatzee = true;
       //                 }
       //                 else if (Count > 3)
       //                 {
       //                     FourOfAKind = true;
       //                     Console.WriteLine("PLZ dont stop the music");
                           
       //                 }else if (Count> 2 && Count<=3)
       //                 {
       //                     threeOfAKind = true;
       //                     Console.WriteLine("LET IT GO!");
       //                 }
       //             }
       //             if (Yatzee)
       //             {
       //                 Console.WriteLine("YATZEEAAAAAAAAAAAAAAAAAAAAAA");
       //                 Sum = 50;
       //                 return Sum;
       //             }
       //             else if(FourOfAKind)
       //             {
       //                     for (k = 0; k < 5; k++)
       //                     {
       //                         Sum += AiRoll[t];
       //                         Console.WriteLine("FOUROf A Kind {0}", Sum);
       //                     }
       //                 return Sum;

       //             }
       //             else if(threeOfAKind)
       //             {
       //                 if (FourOfAKind)
       //                     for (u = 0; u < 5; u++)
       //                     {
       //                         Sum += AiRoll[t];
       //                         Console.WriteLine("Three of A Kind {0}", Sum);
       //                     }
       //                 return Sum;

       //             }
       //             else
       //             {
                        
       //                 int[] ao = new int[5];
       //                 for (int k = 0; k < AiRoll.Count; k++)
       //                 {
       //                     ao[0] = AiRoll[0];
       //                     ao[1] = AiRoll[1];
       //                     ao[2] = AiRoll[2];
       //                     ao[3] = AiRoll[3];
       //                     ao[4] = AiRoll[4];
       //                 }
       //                 Array.Sort(ao);

       //                 if (((ao[0] == 1) &&
       //          (ao[1] == 2) &&
       //          (ao[2] == 3) &&
       //          (ao[3] == 4) &&
       //          (ao[4] == 5)) ||
       //          ((ao[0] == 2) &&
       //          (ao[1] == 3) &&
       //          (ao[2] == 4) &&
       //          (ao[3] == 5) &&
       //          (ao[4] == 6)))
       //                 {

       //                     Sum = 40;
       //                     Console.WriteLine("Large STRAIGHT {0}", Sum);
       //                     return Sum;
                            
       //                 }
       //                 else if ((AiRoll[0] == 1) &&
       //                      (ao[1] == 2) &&
       //                      (ao[2] == 3) &&
       //                      (ao[3] == 4) ||
       //                      ((ao[0] == 2) &&
       //                      (ao[1] == 3) &&
       //                      (ao[2] == 4) &&
       //                      (ao[3] == 5) ||
       //                      (ao[0] == 3) &&
       //                      (ao[1] == 4) &&
       //                      (ao[2] == 5) &&
       //                      (ao[3] == 6))
       //                      )
       //                 {
       //                     Sum = 30;
       //                     Console.WriteLine("REACH SMALL sTRAIGHT");
       //                     return Sum;
       //                 }
       //             }

       //         }

       //         Console.WriteLine("Nothing Else MAtters!");
                
       //     }
       //     return Sum;

       // }
    }
}


