using System;
using System.Collections.Generic;

namespace Kata.Refactor.After
{
    public class NewKeysFilter
    {
        public List<string> Filter(IList<string> marks)
        {
            if (marks == null)
            {
                throw new ArgumentNullException();
            }
            
            return new List<string>();
        }
    }
}