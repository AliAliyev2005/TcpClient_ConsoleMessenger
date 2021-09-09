using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Protocol
    {
        public int Type { get; set; }
        public object Data { get; set; }

        public Protocol() { }
        public Protocol(object data, int type)
        {
            Data = data;
            Type = type;
        }
    }
}
