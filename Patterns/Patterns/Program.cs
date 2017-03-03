using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Creational;

namespace Patterns {
    class Program {
        static void Main(string[] args) {
            Factory_Method fact = new Factory_Method();
            fact.Run();

            Abstract_Factory afact = new Abstract_Factory();
            afact.Run();
        }
    }
}
