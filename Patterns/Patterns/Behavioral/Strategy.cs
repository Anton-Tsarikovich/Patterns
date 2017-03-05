using System;

namespace Patterns.Behavioral {
    class Strategy {
        public void Run() {
            Car auto = new Car(4, "Korito", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

        }

    }

    interface IMovable {
        void Move();
    }

    class PetrolMove :IMovable {
        public void Move() {
            Console.WriteLine("vzhzhzhzhzh");
        }
    }

    class ElectricMove : IMovable {
        public void Move() {
            Console.WriteLine("yyyyyyyyy");
        }
    }

    class Car {
        protected int passengers;
        protected string model;

        public IMovable Movable { private get; set; }

        public Car(int num, string model, IMovable move) {
            passengers = num;
            this.model = model;
            Movable = move;
        }

        public void Move() {
            Movable.Move();
        }
    }
}
