using System;
using System.Collections.Generic;
using System.Text;
using Hardware.Display;

namespace Velocity
{
    public class VelocityX
    {
        protected DisplayDriver display;

        public void Start()
        {
            BeforeRunX();
        }

        protected void BeforeRunX()
        {
            Console.WriteLine("Now entering GUI mode.. [to exit reboot]");
            display = new DisplayDriver();
            display.init();
            while (true)
            {
                RunX();
            }
        }

        protected void RunX()
        {
            display.clear(63);

            for (var i = 0; i < 100; i++)
            {
                display.setPixel(i, i, 5);
            }

            display.step();
        }
    }
}
