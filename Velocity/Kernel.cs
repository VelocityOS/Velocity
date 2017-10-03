using System;
using Sys = Cosmos.System;
using Hardware;
using Hardware.Display;
using WaffleScript;

namespace Velocity
{
    public class Kernel : Sys.Kernel
    {
        public VelocityX velocityX = new VelocityX();
        public UnixTime time = new UnixTime();
        public String version = "1.0.0";
        protected override void BeforeRun()
        {
            Console.WriteLine("\n\n\nInitialising Filesystem!");
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine("Initialised Filesystem!\n\n\n");
            Console.Clear();
            Console.WriteLine("Welcome to Velocity [v" + version + "].\n");
            Console.WriteLine("Current time: "+time.Hour()+":"+time.Minute()+":"+time.Second()+"\n");
            Console.WriteLine("Velocity/Cosmos comes with ABSOLUTELY NO WARRANTY,\nto the extent permitted by applicable law.\n");
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
                    Console.WriteLine("> time");
                    Console.WriteLine("> waffle");
                    Console.WriteLine("> reboot");
                    Console.WriteLine("===== ==== =====");
                    break;
                case "benchx":
                    BasicDisplayDriver driver = new BasicDisplayDriver();
                    driver.init();
                    for (var y = 0; y < 100; y++)
                    {
                        driver.setPixel(y, y, 25);
                    }
                    break;
                case "startx":
                    velocityX.Start();
                    break;
                case "time":
                    Console.WriteLine("The time now is: "+time.Hour()+":"+time.Minute()+":"+time.Second());
                    break;
                case "waffle":
                    WaffleShell waffleShell = new WaffleShell();
                    waffleShell.join();
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
