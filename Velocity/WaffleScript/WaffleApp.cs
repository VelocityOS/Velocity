using System;
using System.Collections.Generic;
using System.Text;

namespace WaffleScript
{
    class WaffleApp
    {
        List<object> list = new List<object>();

        public WaffleApp() {}

        private void exec_function(String[] args, int i)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No function specified.");
            }
            else
            {
                switch (args[1])
                {
                    case "log":
                        if (args.Length > 2) Console.WriteLine(args[2]);
                        else Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("Function not found, `" + args[1] + "` on line " + i);
                        break;
                }
            }
        }

        /*
         * Running a function:
         * ! function_name "argument" 5 "another_arg"
         */
        private void interpret_line(String line, int i)
        {
            var args = line.Split(' ');
            switch (args[0])
            {
                case "!":
                    exec_function(args, i);
                    break;
                default:
                    Console.WriteLine("Invalid opcode at line "+(i+1));
                    break;
            }
        }
        
        public void interpret(String data)
        {
            var lines = data.Split('\n');
            for (var i=0;i<lines.Length;i++)
            {
                var line = lines[i];
                interpret_line(line, i);
            }
        }
    }
}
