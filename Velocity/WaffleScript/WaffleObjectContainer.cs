using System;
using System.Collections.Generic;
using System.Text;

namespace WaffleScript
{
    class WaffleObjectContainer
    {
        public List<WaffleObject> obj = new List<WaffleObject>();
        public WaffleObjectContainer() {}
        public void set(String key, String type, Object value)
        {
            obj.Add(new WaffleObject(key, type, value));
        }
		public Boolean append(String key, String type, Object value)
		{
			if (type=="string" || type=="int")
			{
                return true;
			}
			else
			{
				return false;
			}
		}
    }
}
