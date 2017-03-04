
using Patterns.Creational;

namespace Patterns {
    class Program {
        static void Main(string[] args) {
            Factory_Method fact = new Factory_Method();
            fact.Run();

            Abstract_Factory afact = new Abstract_Factory();
            afact.Run();

            Singleton singleton = new Singleton();
            singleton.Run();

            Protorype prototype = new Protorype();
            prototype.Run();
        }
    }
}
