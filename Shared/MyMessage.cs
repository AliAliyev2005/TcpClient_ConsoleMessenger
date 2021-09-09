using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class MyMessage
    {
        public int IntProperty { get; set; }
        public string StringProperty { get; set; }

        public override string ToString()
        {
            return $"{IntProperty} - {StringProperty}";
        }
    }
}
