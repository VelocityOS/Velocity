using System;
using System.Collections.Generic;

namespace WaffleScript
{
    class WaffleApp
    {
        WaffleObjectContainer objects = new WaffleObjectContainer();
        Boolean debug = false;

        public WaffleApp() {}

        protected void deb(String message)
        {
            if (debug) Console.WriteLine("[DEBUG] "+message);
        }

        protected void err(int line, String error)
        {
            Console.WriteLine("Interpreter error at line "+line);
            Console.WriteLine("Encountered an error: "+error);
        }

        void setObj(String key, String type, Object value)
        {
            deb("New object created, "+key+", with type, "+type+".");
            objects.set(key, type, value);
        }
		
		void appendObj(String key, String type, Object value)
		{
			if (objects.append(key, type, value))
			{
                deb("Appended object of type, "+type+", to object, "+key+".");
			}
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
                deb("Length: "+l.Length);
                if (l.Length>0)
                {
                    var OP = l[0];
                    deb("OP: " + OP);
                    if (OP=="WFL")
                    {
                        if (l.Length>1)
                        {
                            if (l[1]=="debug")
                            {
                                if (debug)
                                {
                                    debug = false;
                                    Console.WriteLine("Disabled debug mode.");
                                }
                                else
                                {
                                    Console.WriteLine("Enabled debug mode.");
                                    debug = true;
                                }
                            }
                            else if (l[1]=="objects")
                            {
                                var arr = objects.obj.ToArray();
                                for (var y=0;y<arr.Length;y++)
                                {
                                    Console.WriteLine("["+arr[y].key+"] {"+arr[y].type+"}: "+arr[y].obj);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Unknown operand.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Running WaffleScript v1.1.2");
                        }
                    }
					else if (OP=="REF")
					{
						if (l.Length>2)
						{
							//setObj();
						}
						else
						{
							err(i, "Missing operand.");
						}
					}
                    else if (OP=="SET")
                    {
                        if (l.Length>4)
                        {
                            var dest = l[1];
							var type = l[3];
                            if (l[2]=="=")
                            {
								Object value = l[4];
								if (type=="string" && l.Length>5)
								{
									for (var y=5;y<l.Length;y++)
									{
										value += " "+l[y];
									}
								}
                                setObj(dest, type, value);
                            }
                            else
                            {
                                err(i, "Unknown OP Code.");
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
