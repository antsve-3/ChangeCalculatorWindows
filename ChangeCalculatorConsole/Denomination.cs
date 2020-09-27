using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ChangeCalculatorConsole
{
    class Denomination
    {
        private String _name;
        private String _namePlural;
        private int _amount;
        private int _count;

        public Denomination(String name, String namePlural, int amount)
        {
            _name = name;
            _namePlural = namePlural;
            _amount = amount;
            _count = 0;
        }

        public String GetName()
        {
            return _name;
        }
        public String GetNamePlural()
        {
            return _namePlural;
        }
        public int GetAmount()
        {
            return _amount;
        }

        public String GetCountAndName()
        {
            String returnString;
            if (_count > 1)
            {
                returnString = _count + " " + _namePlural;
            }
            else
            {
                returnString = _count + " " + _name;
            }
            return returnString;
        }

        public int SetAndReturnCount(int change)
        {
            _count = change / _amount;
            return _count;
        }

        public int UpdateCountReturnRemainder(int change)
        {
            _count = change / _amount;
            int remainder = change % _amount;
            return remainder;
        }

    }
}
