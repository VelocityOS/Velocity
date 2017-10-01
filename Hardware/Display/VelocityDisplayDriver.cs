using Cosmos.HAL;
using Sys = Cosmos.System;
namespace Hardware.Display
{
    public class VelocityDisplayDriver: BasicDisplayDriver
    {
        protected byte[] lastBuffer = new byte[320 * 200];
        protected byte[] currentBuffer = new byte[320 * 200];

        public VelocityDisplayDriver():base() {}

        override public void setPixel(int x, int y, int c)
        {
            currentBuffer[x + (y * 320)] = (byte)c;
            //if (screen.GetPixel320x200x8((uint)x, (uint)y) != (uint)c)
            //    screen.SetPixel320x200x8((uint)x, (uint)y, (uint)c);
        }

        override public void clear()
        {
            clear(0);
        }

        override public void clear(int c)
        {
            for (var x = 0; x < base.getWidth(); x++)
            {
                for (var y = 0; y < base.getHeight(); y++)
                {
                    setPixel(x, y, c);
                }
            }
        }

        override public void step()
        {
            for (var x=0;x<base.getWidth();x++)
            {
                for (var y=0;y<base.getHeight();y++)
                {
                    if (lastBuffer[x + (y * 320)]!=currentBuffer[x + (y * 320)])
                    {
                        base.setPixel(x, y, currentBuffer[x + (y * 320)]);
                    }
                }
            }
            lastBuffer = currentBuffer;
        }
    }
}
