using System;
using System.Collections.Generic;

namespace WaffleScript
{
    class WaffleApp
    {
        //IDictionary<string, WaffleObject> objects = new Dictionary<string, WaffleObject>();
        Boolean debug = false;

        public WaffleApp() {}

        protected void err(int line, String error)
        {
            Console.WriteLine("Interpreter error at line "+line);
            Console.WriteLine("Encountered an error: "+error);
        }

        void addObj(String key, String type, Object value)
        {
            if (debug) Console.WriteLine("New object created, "+key+", with type, "+type+".");
            //objects.Add(key, new WaffleObject(type, value));
        }

        /*
        SET myvar "text"
        REF SYS.UNIXTIME as time
	    LOG time.now()
	    LOG @myvar
        */
        
        public void interpret(String data)
        {
            var lines = data.Split('\n');
            for (var i=0;i<lines.Length;i++)
            {
                var l = lines[i].Split(' ');
                if (debug) Console.WriteLine("Length: "+l.Length);
                if (l.Length>0)
                {
                    var OP = l[0];
                    if (debug) Console.WriteLine("OP: " + OP);
                    if (OP=="WFL")
                    {
                        if (l.Length>1)
                        {
                            if (l[1]=="debug")
                            {
                                Console.WriteLine("Enabled debug.");
                                debug = true;
                            }
                            else
                            {
                                Console.WriteLine("Unknown operand.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Running WaffleScript v1.1");
                        }
                    }
                    else if (OP=="SET")
                    {
                        if (l.Length>1)
                        {
                            var dest = l[2];
                            if (l.Length > 2)
                            {
                                addObj(dest, "string", l[0]);
                            }
                            else
                            {
                                err(i, "Missing operand.");
                            }
                        }
                        else
                        {
                            err(i, "Missing operand.");
                        }
                    }
                }
            }
        }
    }
}
