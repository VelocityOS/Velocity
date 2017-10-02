using System;
using System.Collections.Generic;
using System.Text;

namespace WaffleScript
{
    public class WaffleShell
    {
        private WaffleApp waffleApp = new WaffleApp();
        public void join()
        {
            Boolean running = true;
            Console.WriteLine("WaffleScript v1.1\nType quit to exit WS.\n");
            while (running)
            {
                Console.Write("WS> ");
                var input = Console.ReadLine();
                if (input == "quit") running = false;
                else waffleApp.interpret(input);
            }
        }
    }
}
