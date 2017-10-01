using System;
using System.Collections.Generic;
using System.Text;

namespace WaffleScript
{
    class App
    {
        List<object> list = new List<object>();

        public App() {}

        private void exec_function(String[] args, int i)
        {
            switch (args[1])
            {
                case "log":
                    Console.WriteLine(args[2]);
                    break;
                default:
                    Console.WriteLine("Function not found, `"+args[1]+"` on line "+i);
                    break;
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
