using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class MyLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Username} - {Password}";
        }
    }
}
