using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    public class CheckBox
    {
        public bool one;
        public bool two;
        public bool three;
        public bool four;
        public bool five;
        public bool six;
       
        public bool gapOne()
        {
            if (one)
            {
                return true;
            }
            return false;
        }
        public bool gapTwo()
        {
            if (two)
            {
                return true;
            }
            return false;
        }
        public bool gapThree()
        {
            if (three)
            {
                return true;
            }
            return false;
        }
        public bool gapFour()
        {
            if (four)
            {
                return true;
            }
            return false;
        }
        public bool gapFive()
        {
            if (five)
            {
                return true;
            }
            return false;
        }
        public bool gapSix()
        {
            if (six)
            {
                return true;
            }
            return false;
        }

        public void checkBox(int playerValue)
        {
            if (playerValue == 1)
            {
                one = true;
                gapOne();
            }
            if (playerValue == 2)
            {
                two = true;
                gapTwo();
            }
            if (playerValue == 3)
            {
                three = true;
                gapTwo();
            }
            if (playerValue == 4)
            {
                four = true;
                gapTwo();
            }
            if (playerValue == 5)
            {
                five = true;
                gapTwo();
            }
            if (playerValue == 6)
            {
                six = true;
                gapTwo();
            }
        }


    }
}

