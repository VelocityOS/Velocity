using System;
using System.Collections.Generic;
using System.Text;

namespace WaffleScript
{
    class WaffleObject
    {
        public String key;
        public String type;
        public Object obj;
        public WaffleObject(String key, String type, Object obj)
        {
            this.key = key;
            this.type = type;
            this.obj = obj;
        }
    }
}