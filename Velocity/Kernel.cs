using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Velocity
{
    public class Kernel : Sys.Kernel
    {
        public String version = "1.0.0";
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Velocity [v" + version + "].\n");
            Console.WriteLine("Velocity/Cosmos comes with ABSOLUTELY NO WARRANTY,\nto the extent permitted by applicable law.\n");
        }

        protected void BeforeRunX()
        {
            Console.WriteLine("Now entering GUI mode.. [to exit reboot]");
        }

        protected void RunX()
        {

        }

        protected override void Run()
        {
            Console.Write("$ > ");
            var input = Console.ReadLine();
            var args = input.Split(' ');
            var cmd = args[0];
            switch (cmd)
            {
                case "help":
                    Console.WriteLine("===== HELP =====");
                    Console.WriteLine("Velocity is a port of a Cosmos OS from 2016.");
                    Console.WriteLine("Please contact Hey It's Paul!#0751 / @mcrocks999 for help and support.");
                    Console.WriteLine("Commands:");
                    Console.WriteLine("> help");
                    Console.WriteLine("> startx");
                    Console.WriteLine("> reboot");
                    Console.WriteLine("===== ==== =====");
                    break;
                case "startx":
                    RunX();
                    break;
                case "reboot":
                    Sys.Power.Reboot();
                    break;
                default:
                    Console.WriteLine("Invalid command: " + cmd);
                    break;
            }
        }
    }
}
