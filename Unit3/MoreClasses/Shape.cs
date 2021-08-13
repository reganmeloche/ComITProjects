using System;
using System.Collections.Generic;

namespace Unit3Examples
{
    public class ShapeExample {
        public static void Run() {
            var rect = new Rectangle(4.5, 2);
            var square = new Square(4.6);
            var rect2 = new Rectangle(5, 1);
            var rect3 = new Rectangle(1.9, 1.7);
            var square2 = new Square(2);
            var square3 = new Square(2.3);

            var shapes = new List<Shape2>();
            shapes.Add(rect);
            shapes.Add(rect2);
            shapes.Add(rect3);
            shapes.Add(square);
            shapes.Add(square2);
            shapes.Add(square3);

            // A bunch of more stuff happens here....


            // Suppose we want to sum all of the areas of the shapes
            double sumOfAreas = 0;

            for (int i = 0; i < shapes.Count; i++) {
                var nextShape = shapes[i];
                sumOfAreas += nextShape.GetArea();
            }

            Console.WriteLine(sumOfAreas);
        }
    }

    // Regular classes cannot have abstract methods
    public class Shape
    {
        //public abstract double GetArea();
    }


    // An abstract class can have a constructor as well as both abstract and non-abstract methods
    public abstract class Shape2 {
        public Shape2() {
            Console.WriteLine("Inside the abstract base constructor...");
        }

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public void Test() {
            Console.WriteLine("This is non-abstract");
        }
    }

    // A class that derives from an abstract class MUST implement all abstract methods (otherwise won't compile)
    public class Square : Shape2 {

        // Constructor (Calls the abstract base constructor)
        public Square(double length) : base() {
            _length = length;
        }

        // Data members
        private double _length;

        // Methods: Implementation of the abstract base methods
        public override double GetArea()
        {
            return _length * _length;
        }

        public override double GetPerimeter()
        {
            return 4 * _length;
        }
    }

    // Another class that derives from the abstract base class
    public class Rectangle : Shape2 {
        // Constructor
        public Rectangle(double length, double width) : base() {
            _length = length;
            _width = width;
        }

        // Data members
        private double _length;
        private double _width;


        // Methods
        public override double GetArea() {
            return _length * _width;
        }

        public override double GetPerimeter()
        {
            return (2 * _length) + (2 * _width);
        }
    }


    // An interface - very similar to an abstract class
    // Methods are public and abstract by default - no need to specify
    public interface IShapeInterface {
        double GetArea();
        double GetPerimeter();

        // Interfaces can also have non-abstract methods
        void TestNonAbstract() {
            Console.WriteLine("This is non-abstract");
        }
    }

    // Implementation of an interface - similar mechanism as abstract classes
    public class NewSquare : IShapeInterface
    {
        public NewSquare(double length) {
            _length = length;
        }

        // Data members
        private double _length;


        public double GetArea() {
            return 0;
        }

        public double GetPerimeter() {
            return 0;
        }

    }
}