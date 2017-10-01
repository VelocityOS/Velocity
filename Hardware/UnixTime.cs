using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;

namespace Hardware
{
    public class UnixTime
    {
        public UnixTime() { }

        public int Hour()
        {
            return RTC.Hour;
        }

        public int Minute()
        {
            return RTC.Minute;
        }

        public int Second()
        {
            return RTC.Second;
        }
    }
}
