using System;

namespace Patterns.Creational {
    class Factory_Method {
        public void Run() {
            Developer dev = new PanelDeveloper("No name");
            House house = dev.Create();

            dev = new WoodDeveloper("Second no name");
            House house2 = dev.Create();
        }

    }

    abstract class Developer {
        public string Name { get; set; }

        public Developer(string n) {
            Name = n;
        }

        abstract public House Create();
    }

    class PanelDeveloper : Developer{
        public PanelDeveloper(string n) : base(n) { }
        public override House Create() {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer {
        public WoodDeveloper(string n) : base(n) { }
        public override House Create() {
            return new WoodHouse();
        }
    }

    abstract class House { }
    
    class PanelHouse : House {
        public PanelHouse() {
            Console.WriteLine("Panel House has been created");
        }
    }

    class WoodHouse : House {
        public WoodHouse() {
            Console.WriteLine("Wood House has been created");
        }
    }

}
