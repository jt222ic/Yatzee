using System;
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
        private int TotalScore;
        private bool m_bHoldState = false;
        DateTime jan;


        public DateTime date
        {
            get
            {
                return jan;
            }
            set
            {
                jan = value;
            }
        }
        public Player(string name)
        {
            Name = name;
            jan = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            
            sendToMemberList(this);
        }

        public void sendToMemberList(Player member)
        {
            DAL.AddMemberToList(member);
        }
        public int GetTotalScore
        {
            get
            {
                return TotalScore;
            }
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
