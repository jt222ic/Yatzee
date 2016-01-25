﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    [Serializable]
    class Player
    {

        private string Name;
        private bool m_bHoldState = false;
        public int Addup;
        DateTime Datum;
        DiceRule Rules;
        List<int> test;

        public int GetAddup
        {

            get
            {
                
                
                return Addup;
            }
            set
            {
                    Addup = value;
            }
          
        }
        public DateTime date
        {
            get
            {
                return Datum;
            }
            set
            {
                Datum = value;
            }
        }
        public Player(string name,List<int>roll)
        {
            test = roll;
            Name = name;
            Dice sliceNDice = new Dice();
            Rules = new DiceRule();
            Datum = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //Addup = Rules.Sum;
            sendToMemberList(this);
        }
      

        public void sendToMemberList(Player member)
        {
            DAL.AddMemberToList(member);
        }
      
        public bool HoldState
        {
            get { return m_bHoldState ; }
            set { m_bHoldState = value; }
        }

        public string GetName
        {
            get
            {
                return Name;
            }
            set
            {
                if(Name.Length<=0)
                {
                    throw new ArgumentException("Character needs to be more than 1 char");
                }
                Name = value;
            }
        }
    }
}
