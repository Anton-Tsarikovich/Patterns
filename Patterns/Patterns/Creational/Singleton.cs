using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Patterns.Creational {
    class Singleton {
        public void Run() {
            (new Thread(() => {
                Computer comp = new Computer();
                comp.os = OS.GetInstance("Mint");
                Console.WriteLine(comp.os.Name);
            })).Start();

            Computer com2 = new Computer();
            com2.Launch("Win XP");
            Console.WriteLine(com2.os.Name);

        }
    }

    class Computer {
        public OS os { get; set; }
        public void Launch(string Name) {
            os = OS.GetInstance(Name);
        }
    }

    class OS {
        private static volatile OS instance;
        public string Name { get; private set; }
        private static object sync = new Object();
        static Mutex mutex = new Mutex();
        protected OS(string name) {
            Name = name;
        }

        public static OS GetInstance(string name) {
            if (instance == null) {
                mutex.WaitOne(); 
                    if (instance == null) {
                        instance = new OS(name);
                    }
                mutex.ReleaseMutex();
            }
            return instance;
        }
    }
}
