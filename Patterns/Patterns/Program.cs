using Patterns.Creational;
using Patterns.Behavioral;
using System;

namespace Patterns {
    class Program {
        static void Main(string[] args) {
            Factory_Method fact = new Factory_Method();
            fact.Run();
            Console.WriteLine();

            Abstract_Factory afact = new Abstract_Factory();
            afact.Run();
            Console.WriteLine();

            Singleton singleton = new Singleton();
            singleton.Run();
            Console.WriteLine();

            Protorype prototype = new Protorype();
            prototype.Run();
            Console.WriteLine();

            Strategy strategy = new Strategy();
            strategy.Run();
            Console.WriteLine();

            Observer obs = new Observer();
            obs.Run();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
