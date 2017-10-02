using System;
using System.Collections.Generic;
using System.Text;

namespace WaffleScript
{
    class WaffleObject
    {
        public String type;
        public Object obj;
        public WaffleObject(String type, Object obj)
        {
            this.type = type;
            this.obj = obj;
        }
    }
}