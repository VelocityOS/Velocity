using System;
using System.Collections.Generic;
using System.Text;
using Hardware.Display;

namespace Velocity
{
    public class VelocityX
    {
        protected VelocityDisplayDriver display;

        public void Start()
        {
            BeforeRunX();
        }

        protected void BeforeRunX()
        {
            Console.WriteLine("Now entering GUI mode.. [to exit reboot]");
            display = new VelocityDisplayDriver();
            display.init();
            while (true)
            {
                RunX();
            }
        }

        int y = 0;
        protected void RunX()
        {
            y += 1;
            for (var i = 0; i < 100; i++)
            {
                display.setPixel(i, y, 63);
            }

            display.step();
        }
    }
}
