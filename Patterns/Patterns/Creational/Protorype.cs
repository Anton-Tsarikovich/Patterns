using System;

namespace Patterns.Creational {
    class Protorype {
        public void Run() {
            IFigure figure = new Rectangle(22, 44);
            IFigure clonedFif = figure.Clone();
            figure.GetInfo();
            clonedFif.GetInfo();

            figure = new Circle(4122);
            clonedFif = figure.Clone();
            figure.GetInfo();
            clonedFif.GetInfo();
        }
    }

    interface IFigure {
        IFigure Clone();
        void GetInfo();
    }
    class Rectangle : IFigure {
        int width;
        int height;

        public Rectangle(int w, int h) {
            width = w;
            height = h;
        }

        public IFigure Clone() {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo() {
            Console.WriteLine("Rectangle with width {0}, height {1}", width, height);
        }
    }

    class Circle : IFigure {
        int radius;
        public Circle(int r) {
            radius = r;
        }
        public IFigure Clone() {
            return new Circle(this.radius);
        }
        public void GetInfo() {
            Console.WriteLine("Circle with radius {0}", radius);
        }
    }


}
