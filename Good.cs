using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask02
{
    public class Good
    {
        private readonly string _name;
        public Good(string name) 
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
